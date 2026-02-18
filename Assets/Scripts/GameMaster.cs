using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public bool isVisibleGameOverUI = false;
    public GameObject gameOverUI;
    private bool isGameEnd = false;

    void Update()
    {
        if (isGameEnd)
        {
            return;
        }
        
        if (PlayerStats.Lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // TODO Add GameOver
        isGameEnd = true;
        isVisibleGameOverUI = true;
        gameOverUI.SetActive(isVisibleGameOverUI);
    }
}
