using DefaultNamespace;
using TMPro;
using UnityEngine;

namespace GUI
{
    public class DifficultyGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI difficultyText;
        [SerializeField] private Color easyColor;
        [SerializeField] private Color mediumColor;
        [SerializeField] private Color hardColor;
        void Start()
        {
            if (!difficultyText) difficultyText = GetComponent<TextMeshProUGUI>();
            difficultyText.text = GameManager.Instance.CurrentDifficulty.Name;
            UpdateColor(GameManager.Instance.CurrentDifficulty);
        }
        

        private void UpdateColor(Difficulty difficulty)
        {
            switch (difficulty.DifficultyEnum)
            {
                case DifficultyEnum.EASY:
                    difficultyText.color = easyColor;
                    break;
                case DifficultyEnum.NORMAL:
                    difficultyText.color = mediumColor;
                    break;
                case DifficultyEnum.HARD:
                    difficultyText.color = hardColor;
                    break;
                
            }
        }
    }
}
