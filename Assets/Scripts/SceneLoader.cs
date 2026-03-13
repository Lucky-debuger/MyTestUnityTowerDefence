using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void ReloadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive); // [ ] Why we dont use LoadSceneAsync?
        // [ ] Maybe we can get current scene from gameState?
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single); // [ ] Should we do all in additive?
    }
}
