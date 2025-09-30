using UnityEngine;
namespace MyDefence
{
    /// <summary>
    /// 타워를 관리하는 클래스
    /// </summary>
    public class Tower : MonoBehaviour
    {
        #region Variables
        //공격 범위
        public float attackRange = 7f;

        //공격타겟 Enemy - 가장 가까운 적
        private GameObject target;

        //회전
        public Transform partToRotate;  //회전을 관리하는 오브젝트
        public float rotateSpeed = 10f; //회전 속도

        //찾기 타이머
        private float countdown = 0f;
        public float searchTimer = 0.2f;

        //
        #endregion

        #region Unity Event Method
        private void OnDrawGizmosSelected()
        {
            //타워 중심에 attackRange 범위 확인
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }

        private void Start()
        {
            //초기화
            countdown = searchTimer;
        }
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
            
            //타겟을 향해서 partToRotate 회전
            //방향을 구하기
            Vector3 dir = target.transform.position - this.transform.position;

            //방향에 회전값을 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Quaternion lerpRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed);
            Vector3 eulerValue = lerpRotation.eulerAngles;

            //euler 값(x,y,z)에서 회전값(x,y,z,w) 얻어오기 - y축 값만 회전에 적용 
            partToRotate.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);
            
        }
        #endregion

        #region Custom Me
        //타워에서 가장 가까운 적 찾기
        void UpdateTarget()
        {
            //맴 위에 있는 모든 enemy 게임오브젝트 가져오기
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

            //최소거리 변수 초기화
            float minDistance = float.MaxValue;

            //최소 거리에 있는 게임오브젝트 변수
            GameObject nearEnemy = null;

            foreach (GameObject enemy in enemys)
            {
                //enemy과의 거리 구하기
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if(distance<minDistance)
                {
                    minDistance = distance;
                    nearEnemy= enemy;
                }
            }

            //가장 가까운 적을 찾았다
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
