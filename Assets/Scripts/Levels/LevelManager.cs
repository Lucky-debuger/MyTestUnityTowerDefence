using System;
using Loading;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private string[] levels;
    // [SerializeField] private Scene menuScene;
    [SerializeField] private GameState gameState;

    private int _currentLevelIndex = -1;
    private ISceneLoader _sceneLoader;

    public string CurrentLevelName { get; private set; }

    public event Action OnLevelCompleted;

    public void Construct(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void Start()
    {
        StartLevel(gameState.SelectedLevel);
    }

    public void StartLevel(string levelName)
    {
        CurrentLevelName = levelName;
        _currentLevelIndex = Array.IndexOf(levels, levelName);
        LoadingSceneLoader.LoadLoadingScene();
    }

    public void LoadNextLevel()
    {
        if (_currentLevelIndex+1 < levels.Length)
        {
            string nextLevel = levels[_currentLevelIndex+1];
            _currentLevelIndex = _currentLevelIndex+1;
            CurrentLevelName = nextLevel;
            gameState.SetLevel(CurrentLevelName);

            _sceneLoader.LoadNextLevel();
        }
    }

    public void ReturnToMenu()
    {
        _sceneLoader.LoadMenu();
    }

    public void ReloadCurrentScene()
    {
        _sceneLoader.ReloadLevel(CurrentLevelName);
    }

    public void LevelCompleted()
    {
        OnLevelCompleted?.Invoke();
    }
}
