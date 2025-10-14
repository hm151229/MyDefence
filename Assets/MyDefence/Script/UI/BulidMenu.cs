using UnityEngine;
namespace MyDefence
{
    /// <summary>
    /// 타워 선택 UI를 관리하는 클래스
    /// </summary>
    public class BulidMenu : MonoBehaviour
    {
        #region Custom Method 
        //머신건 버튼 선택 시 호출되는 함수
        public void SelectMachineGun()
        {
            //Debug.Log("머신건 타워를 선택 하였습니다!!");
            BuildManager.Instance.SetTrurretToBuild(BuildManager.Instance.machineGunPrefab);
        }

        //미사일 버튼 선택 시 호출되는 함수
        public void SelectRocketTower()
        {
            //Debug.Log("미사일 타워를 선택 하였습니다!!");
            BuildManager.Instance.SetTrurretToBuild(BuildManager.Instance.RocketPrefab);
        }
        #endregion
    }
}
