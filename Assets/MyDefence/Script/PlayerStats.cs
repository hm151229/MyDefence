using UnityEngine;
namespace MyDefence
{
    /// <summary>
    /// 플레이어 속성, 게임데이터 변수를 관리하는 클래스
    /// </summary>
    public class PlayerStats : MonoBehaviour
    {
        #region Variables
        //소지금
        private static int money;

        public static int Money
        {
            get { return money; }
        }

        //초기소지금
        [SerializeField]
        private int startMoney = 400;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            money = startMoney;
            Debug.Log($"초기소지금 {startMoney}골드를 지급하였습니다");
        }
        #endregion

        #region Costom Method

        //돈 벌기
        public static void AddMoney(int amount)
        {
            money += amount;
        }
        //돈 쓰기
        public static bool UseMoney(int amount)
        {
            //소지금 체크
            if (money < amount)
            {
                Debug.Log("돈이 부족합니다");
                return false;
            }
            money -= amount;
            return true;
        }
        //소지금 체크, 잔고 확인
        public static bool HasMoney(int amount)
        {
            return money >= amount;
        }
        #endregion

        
    }
}
