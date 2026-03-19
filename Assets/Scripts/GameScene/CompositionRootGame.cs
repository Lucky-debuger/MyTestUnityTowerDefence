using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameConstant
{
    public class CompositionRootGame : MonoBehaviour
    {
        /// <summary>
        /// Composition Root of the scene. Responsible for creating all game services, configuring
        /// dependencies, and launching the main Presenter
        /// </summary>

        [SerializeField] private WaveSpawner waveSpawner;
        [SerializeField] private GameView gameView;
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private ViewCountdown viewCountdown;
        [SerializeField] private ViewLevelCompleted viewLevelCompleted;
        [SerializeField] private ViewGameOver viewGameOver;
        [SerializeField] private GameState gameState;

        private SceneLoader _sceneLoader;
        private GamePresentor _presenter;

        private void Awake()
        {
            BuildSystem.Instance.SetLevelManager(levelManager);
            _sceneLoader = new SceneLoader();

            _presenter = new GamePresentor(
                waveSpawner,
                gameView,
                levelManager,
                playerStats,
                viewCountdown,
                viewLevelCompleted,
                viewGameOver
            );

            levelManager.Construct(_sceneLoader);
            waveSpawner.Init(levelManager);
        }

        private void OnEnable()
        {
            _presenter.Initialize();
            SceneManager.sceneLoaded += OnSceneLoaded;
            _sceneLoader.OnReloadStarted += waveSpawner.ResetSpawner;
            _sceneLoader.OnReloadStarted += playerStats.ResetLivesMoney;
        }


        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            _presenter.Dispose();
             _sceneLoader.OnReloadStarted -= waveSpawner.ResetSpawner;
             _sceneLoader.OnReloadStarted -= playerStats.ResetLivesMoney;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            LevelController levelController = FindAnyObjectByType<LevelController>(); // TODO Study Zenject. Do I have to search anyway?
            TurretManager turretManager = FindAnyObjectByType<TurretManager>();
            gameView.HideCanvasLevelCompleted();
            gameView.HideCanvasGameOver();
            
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
