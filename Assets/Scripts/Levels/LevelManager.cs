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

    public void NextLevel() // [ ] What difference between level controller and level manager?
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
    }

    public void LevelCopleted() // [ ] What better name? Should I create this method?
    {
        OnLevelCompleted?.Invoke();
    }
}
