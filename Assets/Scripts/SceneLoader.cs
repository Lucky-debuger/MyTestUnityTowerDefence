using UnityEngine.SceneManagement;
using Loading;
using System;

public class SceneLoader : ISceneLoader
{
    /// <summary>
    /// Store methods related to loading individual scenes
    /// </summary>
    public event Action OnReloadStarted;

    public void LoadNextLevel()
    {
        LoadingSceneLoader.LoadLoadingScene();
    }

    public void ReloadLevel(string sceneName)
    {
        OnReloadStarted?.Invoke();
        LoadingSceneLoader.LoadLoadingScene();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
