using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject selectLevelScreen;

    private GameObject _currentSreen;

    private void Awake() // Возможно стоит заменить на Initialize
    {
        _currentSreen = menuScreen;
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
