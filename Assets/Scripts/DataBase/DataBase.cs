using DefaultNamespace;
using UnityEngine;

namespace DataBase
{
    
    public static class DataBase
    {
        public static readonly string HighScoreKey = "HighScore";

        
        public static int GetHighScore(Difficulty difficulty)
        {
            if (PlayerPrefs.HasKey(HighScoreKey + difficulty.Name))
            {
                return PlayerPrefs.GetInt(HighScoreKey + difficulty.Name);
            }

            PlayerPrefs.SetInt(HighScoreKey + difficulty.Name, 0);
            return 0;
        }
        
        public static int GetHighScore()
        {
            var difficulty = GameManager.Instance.CurrentDifficulty;
            if (PlayerPrefs.HasKey(HighScoreKey + difficulty.Name))
            {
                return PlayerPrefs.GetInt(HighScoreKey + difficulty.Name);
            }

            PlayerPrefs.SetInt(HighScoreKey + difficulty.Name, 0);
            return 0;
        }

        public static void SetHighScore(int score)
        {
            PlayerPrefs.SetInt(HighScoreKey + GameManager.Instance.CurrentDifficulty.Name, score);
        }
    }
}