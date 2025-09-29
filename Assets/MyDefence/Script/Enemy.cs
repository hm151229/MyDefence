using Unity.VisualScripting;
using UnityEngine;
namespace MyDefence
{
    /// <summary> Enemy 를 관리하는 클래스
    public class Enemy : MonoBehaviour
    {
        #region Variables
        //이동 목표 위치를 가지고 있는 오브젝트
        private Transform target;

        //이동 속도
        public float speed = 5f;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
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
        }
        #endregion

        #region Custom Method
        private void Arrive()
        {
            Destroy(this.gameObject);
            Debug.Log("도착했다");
        }
        #endregion
    }
}
