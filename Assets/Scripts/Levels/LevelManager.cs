using System;
using Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string[] levels;
    // [SerializeField] private Scene menuScene;
    [SerializeField] private GameState gameState;

    private int _currentLevelIndex = -1;

    public string CurrentLevelName { get; private set; }

    public event Action OnLevelCompleted;

    private void Start()
    {
        StartLevel(gameState.SelectedLevel);
    }

    public void StartLevel(string levelName)
    {
        CurrentLevelName = levelName;
        _currentLevelIndex = Array.IndexOf(levels, levelName);
        // SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        LoadingSceneLoader.LoadLoadingScene();
    }

    public void LoadNextLevel()
    {
        // if (!string.IsNullOrEmpty(CurrentLevelName))
        // {
        //     SceneManager.UnloadSceneAsync(CurrentLevelName);
        // }

        if (_currentLevelIndex+1 < levels.Length)
        {
            string nextLevel = levels[_currentLevelIndex+1];
            // SceneManager.LoadSceneAsync(nextLevel, LoadSceneMode.Additive);
            _currentLevelIndex = _currentLevelIndex+1;
            CurrentLevelName = nextLevel;
            gameState.SetLevel(CurrentLevelName);

            LoadingSceneLoader.LoadLoadingScene();
        }
    }

    public void ReturnToMenu()
    {
        Debug.Log("1");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.UnloadSceneAsync(CurrentLevelName);
        SceneManager.LoadSceneAsync(CurrentLevelName, LoadSceneMode.Additive);
    }

    public void LevelCompleted()
    {
        OnLevelCompleted?.Invoke();
    }
}
