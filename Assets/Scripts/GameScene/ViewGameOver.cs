using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameConstant
{
    public enum GameOverAction
    {
        Restart,
        Menu
    }
    
    public class ViewGameOver : MonoBehaviour
    {
        [SerializeField] private Button buttonRestart;
        [SerializeField] private Button buttonMenu;

        public event Action<GameOverAction> OnAction;

        public void Init()
        {
            buttonRestart.onClick.AddListener(() => OnAction?.Invoke(GameOverAction.Restart));
            buttonMenu.onClick.AddListener(() => OnAction?.Invoke(GameOverAction.Menu));
        }

        public void Dispose()
        {
            buttonRestart.onClick.RemoveAllListeners();
            buttonMenu.onClick.RemoveAllListeners();
        }
    }
}