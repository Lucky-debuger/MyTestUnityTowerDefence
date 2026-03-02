using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameConstant
{
    public class ViewPanelLevelCompleted : MonoBehaviour
    {
        [SerializeField] private Button buttonNext;
        [SerializeField] private Button buttonMenu;
        [SerializeField] private Button buttonRestart;

        public Button ButtonNext => buttonNext;
        public Button ButtonMenu => buttonMenu;
        public Button ButtonRestart => buttonRestart;

        public event Action OnButtonNextClicked; // [ ] What types of actions do we have?
        public event Action OnButtonMenuClicked;
        public event Action OnButtonRestartClicked;

        private void OnEnable()
        {
            buttonNext.onClick.AddListener(ButtonNextClicked);
            buttonMenu.onClick.AddListener(ButtonMenuClicked);
            buttonRestart.onClick.AddListener(ButtonRestartClicked);
        }

        private void OnDisable()
        {
            buttonNext.onClick.RemoveListener(ButtonNextClicked);
            buttonMenu.onClick.RemoveListener(ButtonMenuClicked);
            buttonRestart.onClick.RemoveListener(ButtonRestartClicked);
        }

        private void ButtonNextClicked() => OnButtonNextClicked?.Invoke();
        private void ButtonMenuClicked() => OnButtonMenuClicked?.Invoke();
        private void ButtonRestartClicked() => OnButtonRestartClicked?.Invoke();
    }
}
