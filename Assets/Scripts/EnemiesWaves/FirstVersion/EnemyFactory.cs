using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory Instance { get; private set; }

    [System.Serializable]
    public class EnemyPool
    {
        public string key; // Тип врага (например, "Fast", "Tank")
        public GameObject prefab;
        public int poolSize = 10;
    }

    public EnemyPool[] pools;
    private Dictionary<string, Queue<GameObject>> _poolDictionary;

    private void Awake()
    {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            var objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            _poolDictionary.Add(pool.key, objectPool);
        }
    }

    public GameObject GetEnemy(string enemyType, Vector3 position)
    {
        if (!_poolDictionary.ContainsKey(enemyType))
        {
            Debug.LogError($"Нет пула для {enemyType}");
            return null;
        }

        if (_poolDictionary[enemyType].Count == 0)
        {
            ExpandPool(enemyType);
        }

        GameObject enemy = _poolDictionary[enemyType].Dequeue();
        enemy.transform.position = position;
        enemy.SetActive(true);
        return enemy;
    }

    private void ExpandPool(string enemyType)
    {
        var pool = pools.First(p => p.key == enemyType);
        var newObj = Instantiate(pool.prefab);
        newObj.SetActive(false);
        _poolDictionary[enemyType].Enqueue(newObj);
    }

    public void ReturnToPool(GameObject enemy, string enemyType)
    {
        enemy.SetActive(false);
        _poolDictionary[enemyType].Enqueue(enemy);
    }
}
