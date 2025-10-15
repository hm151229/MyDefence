using UnityEngine;
namespace MyDefence
{
    /// <summary>
    /// 타워 선택 UI를 관리하는 클래스
    /// </summary>
    public class BulidMenu : MonoBehaviour
    {
        #region Variables
        //BuildManager(싱글톤) 객체선언
        private BuildManager buildManager;

        //타워 리스트
        public TowerBlueprint machineGun;
        public TowerBlueprint rocketTower;


        #endregion

        #region Unity Event Method
        private void Start()
        {
            buildManager = BuildManager.Instance;
        }
        #endregion
        #region Custom Method 
        //머신건 버튼 선택 시 호출되는 함수
        public void SelectMachineGun()
        {
            //Debug.Log("머신건 타워를 선택 하였습니다!!");
            buildManager.SetTrurretToBuild(machineGun);
        }

        //미사일 버튼 선택 시 호출되는 함수
        public void SelectRocketTower()
        {
            //Debug.Log("미사일 타워를 선택 하였습니다!!");
            buildManager.SetTrurretToBuild(rocketTower);
        }
        #endregion
    }
}
