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
        [SerializeField] private ViewCountdown viewCountdown;
        [SerializeField] private View_PanelLevelCompleted view_PanelLevelCompleted;

        // private void Awake() // [ ] Need I here Awake and OnEnable? What better to use and when?
        // {
        //     gameView.Initialize(waveSpawner);
        // }

        private void OnEnable()
        {
            waveSpawner.OnWavesFinished += levelManager.LevelCopleted;
            waveSpawner.OnCountdown += viewCountdown.SetTextCountdown;
            SceneManager.sceneLoaded += OnSceneLoaded;
            levelManager.OnLevelCompleted += playerStats.ResetLivesMoney;
            levelManager.OnLevelCompleted += gameView.SwitchCanvasLevelCompleted;
            view_PanelLevelCompleted.OnButtonNextClicked += levelManager.NextLevel;
        }

        private void OnDisable()
        {
            waveSpawner.OnWavesFinished -= levelManager.LevelCopleted;
            waveSpawner.OnCountdown -= viewCountdown.SetTextCountdown;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            levelManager.OnLevelCompleted -= playerStats.ResetLivesMoney;
            levelManager.OnLevelCompleted -= gameView.SwitchCanvasLevelCompleted;
            view_PanelLevelCompleted.OnButtonNextClicked -= levelManager.NextLevel;
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
