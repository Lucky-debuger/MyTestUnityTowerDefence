using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject selectLevelScreen;
    [SerializeField] private GameState gameState;

    private GameObject _currentScreen;

    private void Awake()
    {
        _currentScreen = menuScreen;
    }

    public void LoadLevel(string levelName)
    {
        gameState.SetLevel(levelName);

        if (!SceneManager.GetSceneByName("Game").isLoaded)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void SwitchSсreen(GameObject newScreen)
    {
        _currentScreen.SetActive(false);
        newScreen.SetActive(true);

        _currentScreen = newScreen;
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
