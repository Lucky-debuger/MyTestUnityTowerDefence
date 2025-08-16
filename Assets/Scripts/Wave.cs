using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "CreateWave")]


public class Wave : ScriptableObject
{
    // public GameObject enemy;
    // public int count;
    // public float rate;
    [System.Serializable]
    public class EnemyGroup
    {
        public GameObject enemyPrefab;
        public int count;
        public int rate;
    }
    public EnemyGroup[] enemyGroups;
 }
