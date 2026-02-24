using UnityEngine;

namespace GameConstant
{
    public class GameView: MonoBehaviour
    {
        [SerializeField] GameObject canvasLevelCompleted;

        public void HideCanvasLevelCompleted()
        {
            canvasLevelCompleted.SetActive(false);
        }

        public void ShowCanvasLevelCompleted()
        {
            canvasLevelCompleted.SetActive(true);
        }
    }
}
