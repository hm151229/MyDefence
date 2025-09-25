using UnityEngine;
namespace Sample
{
    public class ChairMove : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //의자를 이동하라 
            Debug.Log("앞으로 이동하기");
        }
        public float speed = 5f;
        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
