using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public bool isVisibleGameOverUI = false;
    public GameObject gameOverUI;

    void Update()
    {
        gameOverUI.SetActive(isVisibleGameOverUI);
    }
}
