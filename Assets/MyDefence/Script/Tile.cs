using UnityEngine;
using UnityEngine.EventSystems;
namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variable
        //BuildManager(싱글톤) 객체선언
        private BuildManager buildManager;

        //타일에 설치된 타워 오브젝트 인스턴스
        private GameObject tower;

        //타일에 설치된 타워 오브젝트 blueprint 정보 객체(프리팹, 가격, 설치조정위치...)
        private TowerBlueprint blueprint;

        //렌더러 인스턴스 변수 선언
        private Renderer renderer;

        //마우스가 들어가면 바뀌는 컬러
        public Color hoverColor;

        //타일의 원래 색깔
        private Color startColor;

        //마우스가 들어가면 바뀌는 메터리얼
        public Material hoverMaterial;
        //타일의 원래 메터리얼
        private Material startMaterial;

        #endregion

        #region Unity Envent Method
        private void Start()
        {
            //참조 (this.transform 생략 가능)
            renderer = this.transform.GetComponent<Renderer>();
            buildManager = BuildManager.Instance;

            //초기화
            startColor = renderer.material.color;
            startMaterial = renderer.material;
        }
        private void OnMouseDown()
        {
            //UI로 가려져 있으면 설치 못한다
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //만약 타워를 선택하지 않았으면 설치하지 못한다
            if (buildManager.CannotBuild)
            {
                Debug.Log("설치할 타워가 없습니다");
                return;
            }

            //만약 타일에 타워 오브젝트가 있으면 설치하지 못한다
            if (tower != null)
            {
                Debug.Log("타워를 설치하지 못합니다");
                return;
            }

            blueprint = buildManager.GetTurretToBuild();

            //Debug.Log("마우스가 좌클릭하여 타일 선택 - 여기에 타워 건설");
            BuildTower();
        }

        private void OnMouseEnter() 
        {
            //UI로 가려져 있으면 변경되지 않는다
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //만약 타워를 선택하지 않았으면 변경되지 않는다
            if (buildManager.CannotBuild)
            {
                return;
            }
            //renderer.material.color = hoverColor;
            renderer.material = hoverMaterial;
        }

        private void OnMouseExit()
        {
            //renderer.material.color = startColor;
            renderer.material = startMaterial;
        }
        #endregion

        #region Costom Method
        //타워 건설
        private void BuildTower()
        {
            //건설 비용 체크
            if (buildManager.HasBuildCost == false)
            {
                Debug.Log("건설 비용이 부족합니다");
                return;
            }

            //건설 비용 지불
            PlayerStats.UseMoney(blueprint.cost);

            tower = Instantiate(blueprint.prefab, this.transform.position + blueprint.offsetPos, Quaternion.identity);

            //towerToBuild = null; 건설 후 다시 건설하지 못하게 한다
            buildManager.SetTrurretToBuild(null);

            Debug.Log($"건설하고 남은 소지금: {PlayerStats.Money}");
        }
        
        #endregion

    }
}
