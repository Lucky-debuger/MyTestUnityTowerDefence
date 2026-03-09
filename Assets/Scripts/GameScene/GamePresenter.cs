using System;
using GameConstant;

public class GamePresentor : IDisposable // [ ] Why we need this interface?
{
    // [ ] Write summery

    private readonly WaveSpawner _waveSpawner; // [ ] Why readonly?
    private readonly GameView _gameView;
    private readonly LevelManager _levelManager;
    private readonly PlayerStats _playerStats;
    private readonly ViewCountdown _viewCountdown;
    private readonly ViewLevelCompleted _viewLevelCompleted;
    private readonly ViewGameOver _viewGameOver;

    public GamePresentor(
        WaveSpawner waveSpawner,
        GameView gameView,
        LevelManager levelManager,
        PlayerStats playerStats,
        ViewCountdown viewCountdown,
        ViewLevelCompleted viewLevelCompleted,
        ViewGameOver viewGameOver
    )
    {
        _waveSpawner = waveSpawner;
        _gameView = gameView;
        _levelManager = levelManager;
        _playerStats = playerStats;
        _viewCountdown = viewCountdown;
        _viewLevelCompleted = viewLevelCompleted;
        _viewGameOver = viewGameOver;
    }

    public void Initialize() // [ ] Why do we sometimes write init and sometimes initialize?
    {
        _waveSpawner.OnWavesFinished += _levelManager.LevelCompleted;
        _waveSpawner.OnCountdown += _viewCountdown.SetTextCountdown;

        // SceneManager.sceneLoaded += OnSceneLoaded; // [ ] Why did we remove it?

        _levelManager.OnLevelCompleted += _playerStats.ResetLivesMoney;
        _levelManager.OnLevelCompleted += _gameView.ShowCanvasLevelCompleted;

        _viewGameOver.OnButtonMenuClicked += _levelManager.ReturnToMenu;
        _viewGameOver.OnButtonRestartClicked += _levelManager.ReloadCurrentScene;

        _viewLevelCompleted.Init();
        _viewLevelCompleted.OnAction += HandleLevelCompletedAction;

        PlayerStats.OnLivesOver += _gameView.ShowCanvasGameOver;
    }

    private void HandleLevelCompletedAction(LevelCompletedAction action)
    {
        switch (action)
        {
            case LevelCompletedAction.Next:
                _levelManager.LoadNextLevel();
                break;

            case LevelCompletedAction.Menu:
                _levelManager.ReturnToMenu();
                break;

            case LevelCompletedAction.Restart:
                _levelManager.ReloadCurrentScene();
                break;
        }
    }

    public void Dispose()
    {
        _waveSpawner.OnWavesFinished -= _levelManager.LevelCompleted;
        _waveSpawner.OnCountdown -= _viewCountdown.SetTextCountdown;

        _levelManager.OnLevelCompleted -= _playerStats.ResetLivesMoney;
        _levelManager.OnLevelCompleted -= _gameView.ShowCanvasLevelCompleted;

        _viewGameOver.OnButtonMenuClicked -= _levelManager.ReturnToMenu;
        _viewGameOver.OnButtonRestartClicked -= _levelManager.ReloadCurrentScene;

        _viewLevelCompleted.OnAction -= HandleLevelCompletedAction;
        _viewLevelCompleted.Dispose();

        PlayerStats.OnLivesOver -= _gameView.ShowCanvasGameOver;
    }
}
