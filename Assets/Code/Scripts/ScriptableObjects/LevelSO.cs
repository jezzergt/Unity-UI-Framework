using UnityEngine;

namespace ProjectTemplate
{
    [CreateAssetMenu(fileName = "Assets/Resources/GameData/Levels/LevelData", menuName = "ProjectTemplate/Level", order = 11)]
    public class LevelSO : ScriptableObject
    {
        public int levelNumber;
        public string levelLabel;
        public string sceneName;
    }
}

