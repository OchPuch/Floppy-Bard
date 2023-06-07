using UnityEngine;

namespace PrefabsLogic
{
    public class PillarsDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("wall"))
            {
                Destroy(other.gameObject.transform.parent.gameObject);
            }
        
            if (other.CompareTag("start"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
