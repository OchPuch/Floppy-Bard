using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace GUI
{
    public class HighScoreGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI highScoreText;
        [SerializeField] private Color colorBase;
        [SerializeField] private Color colorHighScoreBeat;
        void Start()
        {
            if (!highScoreText) highScoreText = GetComponent<TextMeshProUGUI>();
            GameManager.Instance.OnScore += OnScore;
            GameManager.Instance.OnHighScoreBeaten += OnHighScoreBeat;
            highScoreText.color = colorBase;
            highScoreText.text = DataBase.DataBase.GetHighScore().ToString();
            
        }
        
        
        private void OnScore()
        {
            if (GameManager.Instance.score >= DataBase.DataBase.GetHighScore())
            {
                highScoreText.text = GameManager.Instance.score.ToString();
            }
        }
        
        
        private void OnHighScoreBeat()
        {
            highScoreText.color = colorHighScoreBeat;
        }
        
    }
}
