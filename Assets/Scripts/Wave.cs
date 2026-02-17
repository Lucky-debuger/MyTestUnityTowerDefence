using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "CreateWave")]

public class Wave : ScriptableObject
{
    [System.Serializable]
    public class EnemyGroup
    {
        public GameObject enemyPrefab;
        public int count;
        public float spawnRate;
    }
    public EnemyGroup[] enemyGroups;
}
