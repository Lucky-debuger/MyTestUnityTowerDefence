using UnityEngine;

[System.Serializable]
public class EnemyWave
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public float delayBetween;
    public float timeBeforeNextWave = 5f;
}

[CreateAssetMenu(fileName = "NewWave", menuName = "TD/Wave Data")]
public class WaveData : ScriptableObject
{
    public EnemyWave[] enemies;
    public float delayAfterWave;
    

}

