using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "TD/Wave Data")]
public class WaveData : ScriptableObject
{
    [System.Serializable]
    public class EnemyWave
    {
        public GameObject enemyPrefab;
        public int enemyCount;
        public float delayBetween;
    }
    public EnemyWave[] enemies;
    public float delayAfterWave;

}

