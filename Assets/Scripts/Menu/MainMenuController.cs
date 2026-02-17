using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject selectLevelScreen;

    private GameObject _currentSreen;

    private void Awake()
    {
        _currentSreen = menuScreen;
    }

    public  void LoadLevel(string levelName)
    {
        if (!SceneManager.GetSceneByName("Game").isLoaded)
        {
            SceneManager.LoadScene("Game");
        }

        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
    }

    public void SwitchSсreen(GameObject newScreen)
    {
        _currentSreen.SetActive(false);
        newScreen.SetActive(true);

        _currentSreen = newScreen;
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
