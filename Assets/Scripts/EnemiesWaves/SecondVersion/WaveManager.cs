using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    
    public EnemyWave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;

    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    // void Start()
    // {
    //     StartCoroutine(StartWaves());
    // }

    // IEnumerator StartWaves()
    // {
    //     while (currentWaveIndex < waves.Length)
    //     {
    //         EnemyWave wave = waves[currentWaveIndex];
    //         yield return StartCoroutine(SpawnWave(wave));

    //         yield return new WaitForSeconds(wave.timeBeforeNextWave);
    //         currentWaveIndex++;
    //     }
    // }

    // IEnumerator SpawnWave(EnemyWave wave)
    // {
    //     isSpawning = true;
    //     foreach (var entry in wave.enemies)
    //     {
    //         for (int i = 0; i < entry.count; i++)
    //         {
    //             Instantiate(entry.enemyPrefab, spawnPoint.position, Quaternion.identity);
    //             yield return new WaitForSeconds(entry.spawnDelay);
    //         }
    //     }
    //     isSpawning = false;
    // }
}
