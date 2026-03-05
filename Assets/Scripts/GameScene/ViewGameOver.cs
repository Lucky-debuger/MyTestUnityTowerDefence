using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameConstant
{
    public class ViewGameOver : MonoBehaviour
    {
        [SerializeField] private Button buttonMenu;
        [SerializeField] private Button buttonRestart;

        public Button ButtonMenu => buttonMenu;
        public Button ButtonRestart => buttonRestart;

        public event Action OnButtonMenuClicked;
        public event Action OnButtonRestartClicked;

        private void OnEnable()
        {
            buttonMenu.onClick.AddListener(ButtonMenuClicked);
            buttonRestart.onClick.AddListener(ButtonRestartClicked);
        }

        private void OnDisable()
        {
            buttonMenu.onClick.RemoveListener(ButtonMenuClicked);
            buttonRestart.onClick.RemoveListener(ButtonRestartClicked);
        }

        private void ButtonMenuClicked() => OnButtonMenuClicked?.Invoke();
        private void ButtonRestartClicked() => OnButtonRestartClicked?.Invoke();
    }
}
