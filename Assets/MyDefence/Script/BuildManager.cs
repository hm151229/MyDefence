using Unity.VisualScripting;
using UnityEngine;
namespace MyDefence
{
    /// <summary>
    ///  타워의 건설을 관리하는 싱글톤 클래스 
    /// </summary>
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get
            {
                return instance;
            }
        }
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;

            //DontDestroyOnLoad(this.gameObject);
        }
        #endregion

        #region Variables
        //타일에 설치할 타워 blueprint(프리팹, 비용, 위치조정...)를 저장하는 변수 
        //여러 개의 타워 blueprint 중 선택된 타워 blueprint을 저장하는 변수
        private TowerBlueprint towerToBuild;
        #endregion

        #region Property
        //건설 불가능 여부 체크 : 선택되지 않았으면
        public bool CannotBuild
        {
            get { return towerToBuild == null; }
        }

        //건설 비용 부족 체크
        public bool HasBuildCost
        {
            get
            {
                //선택되지 않았으면 
                if (towerToBuild == null)
                    return false;
                return PlayerStats.HasMoney(towerToBuild.cost);
            }
        }
        #endregion

        #region Unity Event Method
        #endregion

        #region Costom Method
        public TowerBlueprint GetTurretToBuild()
        {
            return towerToBuild;
        }

        public void SetTrurretToBuild(TowerBlueprint tower)
        {
            towerToBuild = tower;
        }
        #endregion
    }
}
