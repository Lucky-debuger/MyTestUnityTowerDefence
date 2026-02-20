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
        [SerializeField] private PlayerStats playerStats;

        private void Awake() // [ ] Need I here Awake and OnEnable?
        {
            gameView.Initialize(waveSpawner);
            waveSpawner.OnWavesFinished += levelManager.NextLevel;
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            levelManager.OnLevelCompleted += playerStats.ResetLivesMoney;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            levelManager.OnLevelCompleted += playerStats.ResetLivesMoney;
            waveSpawner.OnWavesFinished -= levelManager.NextLevel;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            BuildSystem.Instance.SetLevelManager(levelManager);
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
        }
    }
}
