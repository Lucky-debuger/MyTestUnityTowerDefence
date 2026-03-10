using System;
using GameConstant;

public class GamePresentor : IDisposable
{
    /// <summary>
    /// GamePresentor. Initializes the connections between the logic of the layer and the UI,
    /// subscribes to the necessary events and releases them in Dispose
    /// </summary>

    private readonly WaveSpawner _waveSpawner;
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

    public void Initialize()
    {
        _waveSpawner.OnWavesFinished += _levelManager.LevelCompleted;
        _waveSpawner.OnCountdown += _viewCountdown.SetTextCountdown;

        _levelManager.OnLevelCompleted += _playerStats.ResetLivesMoney;
        _levelManager.OnLevelCompleted += _gameView.ShowCanvasLevelCompleted;

        _viewLevelCompleted.Init();
        _viewLevelCompleted.OnAction += HandleLevelCompletedAction;

        _viewGameOver.Init();
        _viewGameOver.OnAction += HandleGameOverAction;

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

    private void HandleGameOverAction(GameOverAction action)
    {
        switch (action)
        {
            case GameOverAction.Restart:
                _levelManager.ReloadCurrentScene();
                break;
            
            case GameOverAction.Menu:
                _levelManager.ReturnToMenu();
                break;
        }
    }

    public void Dispose()
    {
        _waveSpawner.OnWavesFinished -= _levelManager.LevelCompleted;
        _waveSpawner.OnCountdown -= _viewCountdown.SetTextCountdown;

        _levelManager.OnLevelCompleted -= _playerStats.ResetLivesMoney;
        _levelManager.OnLevelCompleted -= _gameView.ShowCanvasLevelCompleted;

        _viewLevelCompleted.OnAction -= HandleLevelCompletedAction;
        _viewLevelCompleted.Dispose();

        _viewGameOver.OnAction -= HandleGameOverAction;
        _viewGameOver.Dispose();

        PlayerStats.OnLivesOver -= _gameView.ShowCanvasGameOver;
    }
}
