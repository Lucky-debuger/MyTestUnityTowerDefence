using UnityEngine;
using GameConstant;
using UnityEngine.SceneManagement;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private WaveSpawner waveSpawner;
    [SerializeField] private GameView gameView;
    [SerializeField] private LevelManager levelManager;

    private void Awake()
    {
        gameView.Initialize(waveSpawner);
        waveSpawner.OnWavesFinished += levelManager.OnLevelCompleted;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        waveSpawner.OnWavesFinished -= levelManager.OnLevelCompleted;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelController levelController = FindAnyObjectByType<LevelController>(); // TODO Study Zenject. Do I have to search anyway?
        if (levelController != null)
        {
            levelController.Initialize(waveSpawner);
        }
    }
}
