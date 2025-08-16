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
        WaveSpawner.isSpawning = false;
        isGameEnd = true;
        isVisibleGameOverUI = true;
        gameOverUI.SetActive(isVisibleGameOverUI);
    }
}
