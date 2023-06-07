using DefaultNamespace;
using UnityEngine;

namespace DataBase
{
    public static class Preferences
    {
        public static readonly string DifficultyKey = "Difficulty";
        public static readonly string VolumeKey = "Volume";
        
        public static Difficulty GetDifficulty()
        {
            if (PlayerPrefs.HasKey(DifficultyKey))
            {
                return Difficulties.GetDifficulty((DifficultyEnum) PlayerPrefs.GetInt(DifficultyKey));
            }

            PlayerPrefs.SetInt(DifficultyKey, (int) DifficultyEnum.NORMAL);
            return Difficulties.Normal;
        }
        
        public static void SetDifficulty(Difficulty difficulty)
        {
            PlayerPrefs.SetInt(DifficultyKey, (int) difficulty.DifficultyEnum);
        }
        
        public static float GetVolume()
        {
            if (PlayerPrefs.HasKey(VolumeKey))
            {
                return PlayerPrefs.GetFloat(VolumeKey);
            }

            PlayerPrefs.SetFloat(VolumeKey, 0.5f);
            return 0.5f;
        }
        
        public static void SetVolume(float volume)
        {
            PlayerPrefs.SetFloat(VolumeKey, volume);
        }
    }
}