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

    public void Initialize(WaveSpawner waveSpawner)
    {
        this.waveSpawner = waveSpawner;
        waveSpawner.StartSpawning(config.Waves, spawnPoint);
    }
}
