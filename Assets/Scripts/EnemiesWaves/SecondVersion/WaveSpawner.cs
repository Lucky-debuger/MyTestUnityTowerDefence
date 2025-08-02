using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float _countdown = 2f; // Time before start the first wave
    private int _waveIndex = 0;

    void Update()
    {
        if (_countdown <= 0)
        {
            _countdown = timeBetweenWaves;
            SpawnWave();
        }
        _countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        _waveIndex++;

        // for (int i = 0; i < _waveIndex; i++)
        // {
        //     SpawnEnemy();
        // }
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
