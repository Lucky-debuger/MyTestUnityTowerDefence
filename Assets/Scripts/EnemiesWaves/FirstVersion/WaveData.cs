using UnityEngine;

// [CreateAssetMenu(fileName = "NewWave", menuName = "TD/Wave Data")]
public class WaveData : ScriptableObject
{
    [System.Serializable]
    public class WaveEnemy
    {
        public GameObject enemyPrefab;
        public int enemyCount = 10;
        public float delayBetween = 1f;
    }
    public WaveEnemy[] enemies;
    public float delayAfterWave = 5f;

}

