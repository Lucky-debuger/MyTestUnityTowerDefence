using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float _countdown = 2f; // Time before start the first wave
    private int _waveIndex = 0;
    public TextMeshProUGUI waveCountdownText;

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (_countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
            return;
        }
        _countdown -= Time.deltaTime;
        waveCountdownText.text = "New wave in: " + Mathf.Round(_countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[_waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        _waveIndex++;

        if (_waveIndex == waves.Length)
        {
            Debug.Log("You win!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
