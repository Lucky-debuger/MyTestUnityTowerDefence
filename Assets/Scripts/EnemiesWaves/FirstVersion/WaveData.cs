using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "TD/Wave Data")]
public class WaveData : ScriptableObject
{
    [System.Serializable]
    public class WaveEnemy
    {
        public GameObject enemyPrefab;
        public int enemyCount;
        public float delayBetween;
    }
    public WaveEnemy[] enemies;
    public float delayAfterWave;

}

