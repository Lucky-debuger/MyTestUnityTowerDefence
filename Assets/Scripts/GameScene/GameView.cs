using UnityEngine;

namespace GameConstant // [ ] I gave the name correct?
{
    public class GameView: MonoBehaviour
    {
        [SerializeField] GameObject canvasLevelCompleted; // [ ] GameObject or transform?

        public void SwitchCanvasLevelCompleted()
        {
            canvasLevelCompleted.SetActive(!canvasLevelCompleted.activeSelf);
        }
    }
}
