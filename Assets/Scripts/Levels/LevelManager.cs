using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string[] levels;
    private string _loadedLevelName;

    private int _currentLevelIndex = -1;

    public void StartLevel(string levelName)
    {
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
        }

        if (_currentLevelIndex + 1 < levels.Length)
        {
            string nextLevel = levels[_currentLevelIndex + 1];
            SceneManager.LoadSceneAsync(nextLevel, LoadSceneMode.Additive);
            _loadedLevelName = nextLevel;
        }
        else
        {
            Debug.Log("All levels completed!");
        }
    }
}
