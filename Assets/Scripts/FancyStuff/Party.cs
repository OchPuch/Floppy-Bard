using UnityEngine;

namespace FancyStuff
{
    public class Party : MonoBehaviour
    {
        [SerializeField] private GameObject confetti;
    
        void Start()
        {
            GameManager.Instance.OnHighScoreBeaten += OnHighScore;
        }

        private void OnHighScore()
        {
            if (GameManager.Instance.isGameOver) return;
            Instantiate(confetti, transform.position, Quaternion.identity);
        }
    }
}
