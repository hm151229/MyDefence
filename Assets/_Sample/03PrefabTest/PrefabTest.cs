using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;
using System.Collections;

namespace Sample
{
    public class PrefabTest : MonoBehaviour
    {
        #region Variables
        //프리팹 오브젝트
        public GameObject prefab;
        //맵 타입들의 부모 오브젝트
        //public Transform parent;

        //맵 타일 생성 체크
        bool isCreate = false;
        #endregion

        #region Unity Event Method
        void Start()
        {
            //[1]
            //Instantiate(prefab);
            //위치: (5f, 0f, 8f) 맵타일 생성하기 
            //Instantiate(prefab, 위치, 방향);
            //Vector3 position = new Vector3(5f, 0f, 8f);
            //Instantiate(prefab, position, Quaternion.identity);
            //Instantiate(prefab, new Vector3(5f, 0f, 8f), Quaternion.identity);

            //row(10)행 x column(10)열 타일맵 찍기
            //GenerateMap(10, 10);
            //GenerateMapTile(10,10);

            //랜덤 타일 찍기
            //GenerateRandomMapTile();

            //랜덤 타일을 1초 간격으로 10개 찍는다 
            //타일 하나 찍고 -> 1초 딜레이 -> 타일 하나 찍고 -> 1초 딜레이
            /*Debug.Log("[0] 코루틴 시작");

            StartCoroutine(CreateMapTile());

            Debug.Log("[4] 타일 생성 완료");*/
        }
        void Update()
        {
            if (isCreate == false)
            {
                //랜덤 타일을 1초 간격으로 10개 찍는다 
                //타일 하나 찍고 -> 1초 딜레이 -> 타일 하나 찍고 -> 1초 딜레이
                Debug.Log("[0] 코루틴 시작");
                StartCoroutine(CreateMapTile());
                isCreate = true;
                Debug.Log($"[4] 타일 생성 완료: {isCreate}");
            }
            Debug.Log($"[99] 업데이트 내용 실행");
        }
        #endregion

        #region Custom Method
        void GenerateMap(int row, int colum)
        {
            //row(10)행 x column(10)열 타일맵 찍기, 타일간 간격은 1이다

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    Vector3 position = new Vector3(i * 5f, 0f, j * -5f);
                    Instantiate(prefab, position, Quaternion.identity);
                }
                
            }
        }

        //맵 제네레이터를 부모로 지정하며 맵 타일 찍기
        void GenerateMapTile(int row, int colum)
        {
            //row(10)행 x column(10)열 타일맵 찍기, 타일간 간격은 1이다

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    //인스턴스 시 위치 지정
                    //Vector3 position = new Vector3(i * 5f, 0f, j * -5f);
                    //Instantiate(prefab, position, Quaternion.identity, this.transform);

                    //인스턴스 후 위치 지정 - 생성된 게임오브젝트의(Transform)객체 가져오기
                    GameObject go = Instantiate(prefab, this.transform);
                    go.transform.position = new Vector3(i * 5f, 0f, j * -5f);

                }

            }
        }

        //row(10)행 x column(10)열 중에 랜덤한 위치에 타일 하나 찍기
        void GenerateRandomMapTile()
        {
            //int row = Random.Range(0, 10);
            // column = Random.Range(0, 10);

            // 0, 1, 2, 3, ... => r: 0, c: 0~9
            // 10, 11, 12, 13, ... => r: 1, c: 0~9
            // 20, 21, 22, 23, ... => r: 2, c: 0~9
            int randNumber = Random.Range(0, 100);
            int row = randNumber / 10;
            int column = randNumber % 10;

            Vector3 position = new Vector3(row * 5f, 0f, column * -5f);
            Instantiate(prefab, position, Quaternion.identity);
        
        }

        //랜덤 타일을 1초 간격으로 10개 찍는다 
        IEnumerator CreateMapTile()
        {
            /*GenerateRandomMapTile();
            Debug.Log("[1] 첫번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("[2] 두번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("[3] 세번째 타일 생성");
            yield return new WaitForSeconds(1.0f);*/
            for(int i = 0;i < 10;i++)
            {
                GenerateRandomMapTile();
                Debug.Log($"{i+1}첫번째 타일 생성");
                yield return new WaitForSeconds(1.0f);
            }
        }
        #endregion

    }
}
/*
코루틴 함수 : 지연 함수 
- 하나 이상의 yield return 문이 꼭 있어야 한다
- yield return 문에서 지연 시간을 지정한다
- 시간(초) 지연: yield return new WaitForSeconds(지연시간(초));

형식
IEnumerator 함수이름()
{
    //...
    yield return... //하나 이상의 yield return 문이 꼭 있어야 한다
}

코루틴 함수 호출
StartCoroutine(코루틴함수이름);
 */
