using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameConstant
{
    public class CompositionRootGame : MonoBehaviour
    {
        // [ ] Write summary

        [SerializeField] private WaveSpawner waveSpawner;
        [SerializeField] private GameView gameView;
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private ViewCountdown viewCountdown;
        [SerializeField] private ViewLevelCompleted viewLevelCompleted;
        [SerializeField] private ViewGameOver viewGameOver;

        private GamePresentor _presenter;

        private void Awake()
        {
            BuildSystem.Instance.SetLevelManager(levelManager);

            _presenter = new GamePresentor(
                waveSpawner,
                gameView,
                levelManager,
                playerStats,
                viewCountdown,
                viewLevelCompleted,
                viewGameOver
            );
        }

        private void OnEnable()
        {
            _presenter.Initialize();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }


        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            _presenter.Dispose();
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
