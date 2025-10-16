using UnityEngine;
using TMPro;
namespace MyDefence
{
    /// <summary>
    /// 게임 중 가지고 있는 Life 갯수를 그리는 UI 클래스
    /// </summary>
    public class DrawLivesUI : MonoBehaviour
    {
        #region Variables
        //Life UI : 생명 갯수
        public TextMeshProUGUI lifeText;

        #endregion

        #region
        private void Update()
        {
            //Lives 데이터 UI적용
            lifeText.text = PlayerStats.Lives.ToString();
        }
        #endregion
    }
}

