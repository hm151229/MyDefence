using UnityEngine;
namespace MyDefence
{
    public class EnemyMove : MonoBehaviour
    {
        public Transform target;   // 도착할 목표 지점 (빈 오브젝트 넣으면 됨)
        public float speed = 5f;   // 이동 속도

        void Update()
        {
            if (target != null)
            {
                // 목표 위치로 이동
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.position,
                    speed * Time.deltaTime
                );

                // 목표 지점에 거의 도착하면 오브젝트 삭제
                if (Vector3.Distance(transform.position, target.position) < 0.01f)
                {
                    Destroy(gameObject); // 이 스크립트가 붙은 오브젝트 삭제
                    Debug.Log("종점 도착!!!");
                }
            }
        }
    }
}
