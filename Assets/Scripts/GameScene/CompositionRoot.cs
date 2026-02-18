using UnityEngine;
using GameConstant;
using UnityEngine.SceneManagement;

namespace GameConstant
{
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
            TurretManager turretManager = FindAnyObjectByType<TurretManager>();
            
            if (levelController != null)
            {
                levelController.Initialize(waveSpawner);
            }

            if (turretManager != null)
            {
                BuildSystem.Instance.Initialize(turretManager);
            }

            if (levelManager != null)
            {
                BuildSystem.Instance.SetLevelManager(levelManager);
            }

        }
    }
}
