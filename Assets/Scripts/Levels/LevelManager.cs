using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string[] levels;
    private string _loadedLevelName;
    private int _currentLevelIndex = -1;

    public string CurrentLevelName { get; private set; } // [ ] Do we need CurrentLevelName? 

    private void Start()
    {
        StartLevel("Level_01");
    }

    public void StartLevel(string levelName)
    {
        CurrentLevelName = levelName;
        _currentLevelIndex = Array.IndexOf(levels, levelName);
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        _loadedLevelName = levelName;
    }

    public void OnLevelCompleted()
    {
        Debug.Log("Level completed!");

        if (!string.IsNullOrEmpty(_loadedLevelName))
        {
            SceneManager.UnloadSceneAsync(_loadedLevelName);
            Debug.Log($"Unload: {_loadedLevelName}");
        }

        if (_currentLevelIndex + 1 < levels.Length)
        {
            string nextLevel = levels[_currentLevelIndex + 1];
            SceneManager.LoadSceneAsync(nextLevel, LoadSceneMode.Additive);
            _loadedLevelName = nextLevel;
            Debug.Log($"Load scene: {_loadedLevelName}");
        }
        else
        {
            Debug.Log("All levels completed!");
        }
    }
}
