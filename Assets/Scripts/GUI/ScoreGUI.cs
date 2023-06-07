using UnityEngine;

namespace GUI
{
    public class ScoreGUI : MonoBehaviour
    {
        [SerializeField]
        private TMPro.TextMeshPro scoreText;
        [SerializeField]
        private TMPro.TextMeshProUGUI scoreTextGUI;
        void Start()
        {
            if (!scoreText) scoreText = GetComponent<TMPro.TextMeshPro>();
            if (!scoreTextGUI) scoreTextGUI = GetComponent<TMPro.TextMeshProUGUI>();
            
            OnScore();
            
            GameManager.Instance.OnScore += OnScore;
        }
        private void OnScore()
        {
            if (scoreText) scoreText.text = GameManager.Instance.score.ToString();
            if (scoreTextGUI) scoreTextGUI.text = GameManager.Instance.score.ToString();
        }
    }
}
