using UnityEngine;
namespace Sample
{
    //직렬화된 구조체
    [System.Serializable]
    public struct TestStrut
    {
        public float value1;
        public int value2;
    }
    /// <summary>
    /// 직렬화 예제, unity에서 직렬화: 인스펙터창에서 편집 가능하게 하는 것
    /// </summary>
    public class SerialTest : MonoBehaviour
    {
        
        public int number = 10;

        [SerializeField]
        private string name = "Tom";

        public TestStrut testStrut;
    }
}
