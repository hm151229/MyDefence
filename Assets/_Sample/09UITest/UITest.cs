using UnityEngine;
namespace Sample
{
    /// <summary>
    /// UI 버튼 호출 함수 구현
    /// </summary>
    public class UITest : MonoBehaviour
    {
        #region Custom Method
        //Fire 버튼 클릭 시 호출 되는 함수 
        //Fire 버튼에 등록되는 함수
        public void Fire()
        {
            Debug.Log("발사 하였습니다.");
        }

        //Jump 버튼 클릭 시 호출 되는 함수 
        public void Jump()
        {
            Debug.Log("플레이어가 점프하였습니다");
        }
        #endregion
    }
}
