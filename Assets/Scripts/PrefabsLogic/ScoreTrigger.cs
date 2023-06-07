using UnityEngine;

namespace PrefabsLogic
{
    public class ScoreTrigger : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (GameManager.Instance.isGameOver) return;
                GameManager.Instance.OnScore?.Invoke();
            }
        }
    }
}
