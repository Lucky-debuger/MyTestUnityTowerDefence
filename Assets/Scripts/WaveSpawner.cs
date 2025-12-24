using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public bool isWorking = true;
    public static bool isSpawning = true;
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float _countdown = 2f; // Time before start the first wave
    private int _waveIndex = 0;
    
    public TextMeshProUGUI waveCountdownText;

    void Awake()
    {
        ResetStaticVariables();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetStaticVariables();
    }

    private void ResetStaticVariables()
    {
        isSpawning = true;
        EnemiesAlive = 0;
    }

    void Update()
    {
        if (!isWorking) return;
        
        if (EnemiesAlive > 0 || !isSpawning)
        {
            return;
        }

        if (_countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }
        _countdown -= Time.deltaTime;
        waveCountdownText.text = "New wave in: " + Math.Round(_countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[_waveIndex];
        // Debug.Log(waves[0].enemyGroups[1].enemyPrefab.name);
        for (int j = 0; j < wave.enemyGroups.Length; j++)
        {
            for (int i = 0; i < wave.enemyGroups[j].count; i++)
            {
                SpawnEnemy(wave.enemyGroups[j].enemyPrefab);
                yield return new WaitForSeconds(1f / waves[0].enemyGroups[j].rate);
            }
        }

        _waveIndex++;

        if (_waveIndex == waves.Length)
        {
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
