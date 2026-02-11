using UnityEngine;

namespace levels
{
    [CreateAssetMenu(menuName = "TD/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private Wave[] waves;
        public Wave[] Waves => waves;
    }
}


