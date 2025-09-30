using UnityEngine;
namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        #region Variablse
        //축 회전 누적 값을 저장하는 변수
        float x = 0f;

        //회전속도
        public float rotateSpeed = 10f;
        #endregion

        //이동속도
        public float moveSpeed = 5f;

        //타겟
        public Transform target;

        #region Unity Event Method
        private void Start()
        {
            //회전값 설정
            //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        private void Update()
        {
            //x축, y축, z축으로 회전 구현
            x += 1;
            //this.transform.rotation = Quaternion.Euler(x, 0, 0);  //x축
            //this.transform.rotation = Quaternion.Euler(0, x, 0);  //y축
            //this.transform.rotation = Quaternion.Euler(0, 0, x);  //z축

            //[1] Rotate(자전)
            //this.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
            //[1-2] RotateAround (타겟 기준으로 공전)
            //this.transform.RotateAround(target.position, Vector3.up, Time.deltaTime * 20f);

            /*//타겟을 향해 회전
            //타겟을 향한 방향을 구한다 : 타겟 위치 - 현재위치
            Vector3 dir = target.position - this.transform.position;
            //타겟 방향에 대한 회전값 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Quaternion lerpRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
            
            //회전값(x,y,z,w)에서 euler 값(x,y,z) 얻어오기
            Vector3 eulerValue = lerpRotation.eulerAngles;

            //euler 값(x,y,z)에서 회전값(x,y,z,w) 얻어오기 - y축 값만 회전에 적용 
            this.transform.rotation = Quaternion.Euler(0f, eulerValue.y , 0f);

            //this.transform.rotation = lookRotation;*/


            //타겟을 향해 이동 
            Vector3 dir = target.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(dir);

            //방향을 구한 것은(dir) 셀프 기준이 아니다 따라서 dir 방향으로 움직이려면 월드 기준으로 해야된다 
            //transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.Self);
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);


        }
        #endregion
    }
}