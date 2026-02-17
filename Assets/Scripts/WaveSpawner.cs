using System.Collections;
using UnityEngine;
using TMPro;
using System;
public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private TextMeshProUGUI waveCountdownText;
    
    private float _countdown = 2f; // Time before start the first wave
    private int _waveIndex = 0;
    private bool _isWorking = false;
    private Wave[] _waves;
    private Transform _spawnPoint;

    public static bool isSpawning = true; // TODO remove static
    public static int EnemiesAlive = 0;

    public event Action<float> OnCountdown; // [ ] Is it a good name?
    public event Action OnWavesFinished;

    private void Update()
    {
        if (!_isWorking) return;
        
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
        OnCountdown?.Invoke(_countdown);
    }

    private IEnumerator SpawnWave()
    {
        Wave wave = _waves[_waveIndex];

        for (int j = 0; j < wave.enemyGroups.Length; j++)
        {
            for (int i = 0; i < wave.enemyGroups[j].count; i++)
            {
                SpawnEnemy(wave.enemyGroups[j].enemyPrefab);
                yield return new WaitForSeconds(wave.enemyGroups[j].spawnRate);
            }
        }

        _waveIndex++;

        if (_waveIndex == _waves.Length)
        {
            OnWavesFinished?.Invoke();
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, _spawnPoint.position, _spawnPoint.rotation);
        EnemiesAlive++;
    }

    public void Run()
    {
        if (_isWorking) return;

        _isWorking = true;
    }

    public void StartSpawning(Wave[] waves, Transform spawnPoint)
    {
        this._waves = waves;
        this._spawnPoint = spawnPoint;
        this._isWorking = true;
    }
}
