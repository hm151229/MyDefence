using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace MyDefence
{
    /// <summary>
    /// 레이저를 쏘는 타워를 관리하는 클래스, Tower를 상속 받는다
    /// </summary>
    public class LaserTower : Tower
    {
        #region Variables
        
        //레이저 빔
        private LineRenderer lineRenderer;

        //레이저 빔 타격 이펙트 
        public ParticleSystem laserImpact;

        //타격 레이저 빔 라이팅
        public Light impactLight;

        //1초당 30 데미지
        [SerializeField]    
        private float laserDamage = 30f;

        //40% 감속
        [SerializeField]
        private float slowRate = 0.4f;
        #endregion

        #region Unity Event Method
        protected override void Start()
        {
            //부모 클래스(Tower) start() 실행
            base.Start();

            lineRenderer =this.transform.GetComponent<LineRenderer>();
        }

        protected override void Update()
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
            {
                //레이저를 그리지 않는다, 타격 이펙트도 정지
                if (lineRenderer.enabled == true)
                {
                    lineRenderer.enabled = false;
                    laserImpact.Stop();
                    impactLight.enabled = false;

                }
                return;
            }

            //타겟을 향해서 partToRotate 회전
            LockOn();

            //레이저 빔 쏘기
            ShootLaser();
        }
        #endregion

        #region Custom Method
        private void ShootLaser()
        {
            //데미지 주기
            float frameDamage = Time.deltaTime * laserDamage; //프레임당 데미지
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(frameDamage);
                //이동속도
                enemy.Slow(slowRate);
            }
            /*damageCountdown += Time.deltaTime;
            if (damageCountdown >= damageTimer)
            {
                //타이머 기능 - 30데미지
                Enemy enemy = target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(laserDamage);
                }
                //타이머 초기화
                damageTimer = 0f;
            }*/
            //라인 렌더를 그린다, 레이저 타격 효과 그리기
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
                laserImpact.Play();
                impactLight.enabled = true ;
            }

            //라인 렌더러의 시작, 끝 지점 지정
            lineRenderer.SetPosition(0, firePoint.position);        //시점
            lineRenderer.SetPosition(1, target.transform.position); //종점

            //레이저 타격 이펙트
            //타격 이펙트가 파이어포인트를 바라보는 방향
            Vector3 dir = firePoint.position - laserImpact.transform.position; 
            laserImpact.transform.position = target.transform.position + dir.normalized/2;
            laserImpact.transform.rotation = Quaternion.LookRotation(dir);
        }
        #endregion
    }
}