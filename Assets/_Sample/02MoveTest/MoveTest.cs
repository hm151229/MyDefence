using UnityEngine;

public class MoveTest : MonoBehaviour
{
    //이동 목표 지점 변수 선언 및 초기화
    //private Vector3 targetPosition = new Vector3(7f, 1f, 8f);

    //이동 목표 위치에 있는 오브젝트의 트랜스폼 인스턴스
    //유니티에서는 new로 인스턴스를 가져오지 않는다.
    //MonoBehaviour가 붙어있는 컴포넌트 클래스는 게임 오브젝트에 붙으면 
    //유니티에서 알아서 인스턴스를 생성해준다
    //public으로 변수를 생성하고 인스펙터에 드래그로 끌고와서 설정할 있다
    public Transform target;

    //이동 속도를 저장하는 변수를 선언하고 초기화
    public float speed = 5f;   //1초에 가는 거리
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //"Player" 라는 gameObject에 스크립트가 붙어 있으면 this가 가리키는 건 Player의 객체
        //gameObject에는 무조건 Transform이 붙기 때문에 비슷한 역할을 한다
        //this.transform.position = new Vector3(7f, 1f, 8f);
        //Debug.Log(this.transform.position);

        //Debug.Log(this.target.position);
        //this.transform.position = target.position;   
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어의 위치를 앞으로 이동 : z축 값이 증가한다
        //this.transform.position 연산으로 구현 - Vector3
        //this.transform.position = transform.position + new Vector3(0f, 0f, 1f);
        //오른쪽으로 이동
        //this.transform.position += Vector3.forward;

        //앞, 뒤, 좌, 우, 위. 아래
        /*
        Vector3(1f, 0f, 0f);  > Vector3.right    //오른쪽
        Vector3(-1f, 0f, 0f); > Vector3.left     //왼쪽
        Vector3(0f, 1f, 0f);  > Vector3.up       //위쪽
        Vector3(0f, -1f, 0f); > Vector3.down     //아래쪽
        Vector3(0f, 0f, 1f);  > Vector3.forward  //앞쪽
        Vector3(0f, 0f, -1f); > Vector3.back     //뒷쪽

        Vector3(1f, 1f, 1f);  > Vector3.one      //단위백터
        Vector3(0f, 0f, 0f);  > Vector3.zero      
        */

        //앞 방향으로 1초에 1unit 만큼씩 이동하라
        //this.transform.position += Vector3.forward * Time.deltaTime;

        //앞 방향으로 1초에 5만큼씩 이동하라
        //this.transform.position += Vector3.forward * Time.deltaTime * speed;

        //Translate (누적연산식이 포함된 함수)
        //dir(방향) : 이동할 방향 지정
        //Time.deltaTime : 동일한 시간에 동일한 거리를 이동하게 해준다
        //speed : 이동의 빠르기 지정
        //dir * Time.deltaTime * speed => 연산의 결과는 Vector3
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //이동 방향 구하기 : (목표지점 - 현재지점), (도착위치 - 현재위치)
        Vector3 dir = target.position - this.transform.position;
        //dir.normalized : 단위백터, 길이가 1인 백터, 정규화된 백터
        //dir.magnitude  : 백터의 길이, 크기
        transform.Translate(dir.normalized * Time.deltaTime * speed);

        //Space.Self -> Local 기준, Space.World -> Glober 기준
        //transform.Translate()에 Space.Self가 디폴트로 생략되어 있다

    }
}
/*
n프레임 : 1초당 n번 실행
Time.deltaTime : 한 프레임 돌아오는데 걸리는 시간 

//this.transform.position += new Vector3(0f, 0f, 1f);

성능 좋은 컴
10프레임 - 1초에 10 unit 이동 (Time.deltaTime을 고려하지 않았을 때)
Time.deltaTime : 0.1초
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;    //0.1씩 증가 *10
10프레임 - 1초에 1 unit 이동 (Time.deltaTime을 고려)


성능 나쁜 컴
2프레임 - 1초에 2 unit 이동 (Time.deltaTime을 고려하지 않았을 때)
Time.deltaTime : 0.5초
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;    //0.5씩 증가 *2
2프레임 - 1초에 1 unit 이동 (Time.deltaTime을 고려)

*Time.deltaTime을 곱하면 성능에 상관없이 모든 컴퓨터에서 똑같이 1초에 1unit 움직인다
 */
