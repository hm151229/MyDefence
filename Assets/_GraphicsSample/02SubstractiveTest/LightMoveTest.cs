using UnityEngine;
namespace Sample
{
    public class LightMoveTest : MonoBehaviour
    {
        #region Variables
        public float speed = 5f;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            Vector3 dir = Vector3.right* moveX + Vector3.forward* moveY;

            transform.Translate(dir * speed * Time.deltaTime, Space.World);
        }
        #endregion
    }
}
