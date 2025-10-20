using Unity.VisualScripting;
using UnityEngine;
namespace MyDefence
{
    /// <summary> Enemy 를 관리하는 클래스
    public class Enemy : MonoBehaviour, IDamageable
    {
        #region Variables
        //이동 목표 위치를 가지고 있는 오브젝트
        private Transform target;

        //이동 속도
        [SerializeField]
        private float speed = 10f;

        //이동 속도 초기화
        [SerializeField]
        private float startSpeed = 4f;

        //죽음 효과 프리팹 오브젝트
        public GameObject deathEffectPrefab;
        //체력
        private float health;
        [SerializeField]
        private float startHealth = 100f;   //체력 초기값

        //죽음 체크
        private bool isDeath = false;

        //죽음 보상
        [SerializeField]
        private int rewardMoney = 50;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            health = startHealth;
            target = WayPoints.points[0];
        }

        void Update()
        {
            //타겟을 향해 이동
            Vector3 dir = target.position - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed);

            //도착 판정
            //타겟과 Eenmy와 거리를 구해서 일정거리 안에 들어오면 도착이라고 판정한다
            //Distance(a, b) = (a-b).magnitude(백터의 길이, 크기) => a, b의 거리를 구해주는 함수
            float distance = Vector3.Distance(transform.position, target.position);
            if(distance<0.5f)
            {
                Arrive();
            }

            //이동속도 초기 속도로 복원
            speed = startSpeed;
        }
        #endregion

        #region Custom Method
        private void Arrive()
        {
            //생명 사용
            PlayerStats.UseLives(1);
            //Enemy 킬
            Destroy(this.gameObject);
        }

        //매개변수로 들어온 만큼 데미지를 입는다 
        public void TakeDamage(float damage)
        {
            health -= damage; 
            //Debug.Log($"Enemy Health: {health}");

            //죽음체크
            if (health <= 0 && isDeath == false)
            {
                health = 0;
                Die();
            }
        }

        private void Die()
        {
            //죽음 체크
            isDeath = true;

            //죽음처리
            //죽음 효과(vfx, sfx)
            GameObject effectGo = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);
            
            //보상 처리(골드, 경험치, 아이템)
            PlayerStats.AddMoney(rewardMoney);

            //Enemy Kill
            Destroy(this.gameObject);
        }

        //이동속도 느리게 하기
        public void Slow (float rate)   //40% 감속
        {
            speed = startSpeed * (1 -rate);  //10*0.4 = 4 -> 10*(1-0.4) = 6
        }
        #endregion
    }
}
