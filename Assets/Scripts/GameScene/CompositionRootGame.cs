using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameConstant
{
    public class CompositionRootGame : MonoBehaviour
    {
        [SerializeField] private WaveSpawner waveSpawner;
        [SerializeField] private GameView gameView;
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private ViewCountdown viewCountdown;
        [SerializeField] private ViewLevelCompleted viewLevelCompleted;
        [SerializeField] private ViewGameOver viewGameOver;

        private void Awake()
        {
            BuildSystem.Instance.SetLevelManager(levelManager);
        }

        private void OnEnable()
        {
            waveSpawner.OnWavesFinished += levelManager.LevelCompleted;
            waveSpawner.OnCountdown += viewCountdown.SetTextCountdown;

            SceneManager.sceneLoaded += OnSceneLoaded;

            levelManager.OnLevelCompleted += playerStats.ResetLivesMoney;
            levelManager.OnLevelCompleted += gameView.ShowCanvasLevelCompleted;

            viewLevelCompleted.OnButtonNextClicked += levelManager.LoadNextLevel;
            viewLevelCompleted.OnButtonMenuClicked += levelManager.ReturnToMenu;
            viewLevelCompleted.OnButtonRestartClicked += levelManager.ReloadCurrentScene;

            viewGameOver.OnButtonMenuClicked += levelManager.ReturnToMenu;
            viewGameOver.OnButtonRestartClicked += levelManager.ReloadCurrentScene;

            PlayerStats.OnLivesOver += gameView.ShowCanvasGameOver;
        }

        private void OnDisable()
        {
            waveSpawner.OnWavesFinished -= levelManager.LevelCompleted;
            waveSpawner.OnCountdown -= viewCountdown.SetTextCountdown;

            SceneManager.sceneLoaded -= OnSceneLoaded;

            levelManager.OnLevelCompleted -= playerStats.ResetLivesMoney;
            levelManager.OnLevelCompleted -= gameView.ShowCanvasLevelCompleted;

            viewLevelCompleted.OnButtonNextClicked -= levelManager.LoadNextLevel;
            viewLevelCompleted.OnButtonMenuClicked -= levelManager.ReturnToMenu;
            viewLevelCompleted.OnButtonRestartClicked -= levelManager.ReloadCurrentScene;

            viewGameOver.OnButtonMenuClicked -= levelManager.ReturnToMenu;
            viewGameOver.OnButtonRestartClicked -= levelManager.ReloadCurrentScene;

            PlayerStats.OnLivesOver -= gameView.ShowCanvasGameOver;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            LevelController levelController = FindAnyObjectByType<LevelController>(); // TODO Study Zenject. Do I have to search anyway?
            TurretManager turretManager = FindAnyObjectByType<TurretManager>();
            gameView.HideCanvasLevelCompleted();
            
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
