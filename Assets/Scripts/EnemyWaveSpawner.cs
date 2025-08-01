using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public WaveData[] waves;
    public Transform spawnPoint;
    // public Transform[] path; // Путь для врагов

    private int _currentWaveIndex = -1;
    private bool _isSpawning = false;

    public event Action OnWaveStarted;
    public event Action OnWaveCompleted;
    public event Action OnAllWavesCompleted;

    void Start()
    {

    }

    public void StartNextWave()
    {
        if (_isSpawning || _currentWaveIndex >= waves.Length - 1)
        {
            return;
        }

        _currentWaveIndex++;
        StartCoroutine(SpawnWaveRoutine(waves[_currentWaveIndex]));
    }

    private IEnumerator SpawnWaveRoutine(WaveData wave)
    {
        _isSpawning = true;

        foreach (var enemy in wave.enemies)
        {
            for (int i = 0; i < enemy.enemyCount; i++)
            {
                SpawnEnemy(enemy.enemyPrefab);
                yield return new WaitForSeconds(enemy.delayBetween);
            }
        }

        _isSpawning = false;
        OnWaveCompleted?.Invoke();

        if (_currentWaveIndex == waves.Length - 1)
        {
            OnAllWavesCompleted?.Invoke();
        }
        else
        {
            yield return new WaitForSeconds(wave.delayAfterWave);
            StartNextWave();
        }
    }

    private void SpawnEnemy(GameObject prefab)
    {
        var enemy = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        if (enemy.TryGetComponent<Enemy>(out var enemyComponent))
        {
            enemyComponent.Initialize(); // enemyComponent.Initialize(path);
        }
    }
}
