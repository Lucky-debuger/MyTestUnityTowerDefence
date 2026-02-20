using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string[] levels;
    [SerializeField] private GameState gameState;

    private int _currentLevelIndex = -1;

    public string CurrentLevelName { get; private set; }

    public event Action OnLevelCompleted;

    private void Start()
    {
        StartLevel(gameState.selectedLevel);
    }

    public void StartLevel(string levelName)
    {
        CurrentLevelName = levelName;
        _currentLevelIndex = Array.IndexOf(levels, levelName);
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        CurrentLevelName = levelName;
    }

    public void NextLevel()
    {
        if (!string.IsNullOrEmpty(CurrentLevelName))
        {
            SceneManager.UnloadSceneAsync(CurrentLevelName);
        }

        if (_currentLevelIndex + 1 < levels.Length)
        {
            string nextLevel = levels[_currentLevelIndex + 1];
            SceneManager.LoadSceneAsync(nextLevel, LoadSceneMode.Additive);
            CurrentLevelName = nextLevel;
            CurrentLevelName = nextLevel;
        }

        OnLevelCompleted?.Invoke();
    }
}
