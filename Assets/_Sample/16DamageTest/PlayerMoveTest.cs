using MyDefence;
using UnityEngine;
namespace Sample
{
    /// <summary>
    /// wasd 키 누르면 앞뒤좌우 이동, F키 누르면 불렛 발사 구현
    /// </summary>
    public class PlayerMoveTest : MonoBehaviour
    {
        #region Variables
        public float attackRange = 7f;

        public float speed = 5f;
        public GameObject target;

        //총알 프리팹 오브젝트
        public GameObject bulletPrefab;
        public Transform firePoint;

        //찾기 타이머
        protected float countdown = 0f;
        public float searchTimer = 0.2f;

        //발사 타이머 
        public float fireTimer = 1f;
        private float fireCountdown = 0f;
        #endregion

        #region Unity Event Method
        private void Update()
        {

            //0.2초마다 가장 가까운 적 찾기
            if (countdown <= 0f)
            {
                //타이머 기능 - 가장 가까운 적 찾기
                UpdateTarget();

                //타이머 초기화
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;

            if (target == null)
                return;

            //이동
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            Vector3 dir = Vector3.right * moveX + Vector3.forward * moveY;

            transform.Translate(dir * speed * Time.deltaTime, Space.World);

            //회전
            /*Vector3 vector3 = target.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(vector3);*/

            transform.LookAt(target.transform);

            //발사 버튼
            if (Input.GetKeyDown(KeyCode.F))
            {
                Fire();
            }


        }
            #endregion

        #region Custom Method
        private void Fire()
        {
            Debug.Log("Shoot!!!");
            //총구(firePoint) 위치에 탄환 객체 생성하기
            GameObject bullotGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            BulletTest bullet = bullotGo.GetComponent<BulletTest>();
            if (bullet != null)
            {
                bullet.SetTarget(target.transform);
            }

            Destroy(bullotGo, 3f);
        }

        //타워에서 가장 가까운 적 찾기
        protected void UpdateTarget()
        {
            //맵 위에 있는 모든 enemy 게임오브젝트 가져오기
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

            //최소거리 변수 초기화
            float minDistance = float.MaxValue;

            //최소 거리에 있는 게임오브젝트 변수
            GameObject nearEnemy = null;

            foreach (GameObject enemy in enemys)
            {
                //enemy과의 거리 구하기
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }

            //가장 가까운 적을 찾았다, 이때 최소거리는 
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy;
            }
            else
            {
                target = null;
            }
        }
        #endregion
    }
}
