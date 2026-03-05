using UnityEngine;

namespace GameConstant
{
    public class GameView: MonoBehaviour
    {
        [SerializeField] GameObject canvasLevelCompleted;
        [SerializeField] GameObject canvasGameOver;

        public void HideCanvasLevelCompleted()
        {
            canvasLevelCompleted.SetActive(false);
        }

        public void ShowCanvasLevelCompleted()
        {
            canvasLevelCompleted.SetActive(true);
        }

        public void HideCanvasGameOver()
        {
            canvasGameOver.SetActive(false);
        }

        public void ShowCanvasGameOver()
        {
            canvasGameOver.SetActive(true);
        }
    }
}
