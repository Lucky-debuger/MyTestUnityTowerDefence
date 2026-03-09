using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameConstant
{
    public enum LevelCompletedAction
    {
        Next,
        Menu,
        Restart
    }

    public class ViewLevelCompleted : MonoBehaviour
    {
        [SerializeField] private Button buttonNext;
        [SerializeField] private Button buttonMenu;
        [SerializeField] private Button buttonReload;

        public event Action<LevelCompletedAction> OnAction; // [ ] Вспомнить какие есть еще события

        public void Init()
        {
            buttonNext.onClick.AddListener(() => OnAction?.Invoke(LevelCompletedAction.Next));
            buttonMenu.onClick.AddListener(() => OnAction?.Invoke(LevelCompletedAction.Menu));
            buttonReload.onClick.AddListener(() => OnAction?.Invoke(LevelCompletedAction.Restart));
        }

        public void Dispose()
        {
            buttonNext.onClick.RemoveAllListeners();
            buttonMenu.onClick.RemoveAllListeners();
            buttonReload.onClick.RemoveAllListeners();
        }


    }
}
