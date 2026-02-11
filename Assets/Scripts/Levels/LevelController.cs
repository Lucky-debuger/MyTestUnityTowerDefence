using levels;
using UnityEngine;

public class LevelController : MonoBehaviour
{
/// <summary>
/// Responsible for transferring level data
/// to the WaveSpawner

    [SerializeField] private LevelConfig config;
    [SerializeField] private Transform spawnPoint;

    private WaveSpawner waveSpawner;

    private void Start()
    {
        waveSpawner = FindAnyObjectByType<WaveSpawner>(); // [ ] Should I leave find? Yes
        waveSpawner.waves = config.Waves;
        waveSpawner.spawnPoint = spawnPoint;
        waveSpawner.isWorking = true; // [ ] Лучше сделать через метод? Yes you should refactor this
    }
}
