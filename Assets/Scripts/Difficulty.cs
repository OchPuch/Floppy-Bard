using System;

namespace DefaultNamespace
{
    public struct Difficulty
    {
        public float PillarSpeed;
        public float PillarSpawnTime;
        public float PillarSpace;
        public float PillarHeightRange;
        public String Name;
        public DifficultyEnum DifficultyEnum;
    }
    
    public enum DifficultyEnum
    {
        EASY,
        NORMAL,
        HARD
    }

    public static class Difficulties
    {
        public static readonly Difficulty Easy = new Difficulty()
        {
            PillarSpeed = 1f,
            PillarSpawnTime = 5f,
            PillarSpace = 1.5f,
            PillarHeightRange = 2f,
            Name = "Crybaby",
            DifficultyEnum = DifficultyEnum.EASY

        };

        public static readonly Difficulty Normal = new Difficulty()
        {
            PillarSpeed = 1.5f,
            PillarSpawnTime = 3f,
            PillarSpace = 1.2f,
            PillarHeightRange = 3f,
            Name = "Normal",
            DifficultyEnum = DifficultyEnum.NORMAL
        };

        public static readonly Difficulty Hard = new Difficulty()
        {
            PillarSpeed = 3.5f,
            PillarSpawnTime = 2f,
            PillarSpace = 1f,
            PillarHeightRange = 5f,
            Name = "Violent",
            DifficultyEnum = DifficultyEnum.HARD
        };

        public static Difficulty GetDifficulty(DifficultyEnum difficultyEnum)
        {
            switch (difficultyEnum)
            {
                case DifficultyEnum.EASY:
                    return Easy;
                case DifficultyEnum.NORMAL:
                    return Normal;
                case DifficultyEnum.HARD:
                    return Hard;
                default:
                    return Easy;
            }
        }
    }
}