using UnityEngine;
using UnityEngine.InputSystem;
namespace MyDefence
{
    /// <summary>
    /// 게임의 전체를 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임오버 체크 변수
        private bool isGameOver = false;
        #endregion

        #region Unity Event Method

        private void Update()
        {
            if (isGameOver)
                return;
            //게임 종료 체크
            if(PlayerStats.Lives <= 0)
            {
                GameOver();
            }

            //치트키
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
        }
        #endregion

        #region Custom Method
        //게임 오버 처리
        private void GameOver()
        {
            Debug.Log("Game Over!");
            isGameOver = true;
        }

        //치트키
        private void ShowMeTheMoney()
        {
            PlayerStats.AddMoney(100000);
        }
        #endregion
    }
}
