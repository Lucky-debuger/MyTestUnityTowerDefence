using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using MyUI;

namespace menu
{
    public class MainMenuAnimator : MonoBehaviour
    {
        [SerializeField] private CanvasGroup rootCanvasGroup; // [ ] Deal with the new component
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private ViewMainMenu viewMainMenu;
        [SerializeField] private ButtonHover buttonHoverSelectLevel;

        private void Awake()
        {
            rootCanvasGroup.alpha = 0f;
        }

        private void Start()
        {
            PlayShowAnimation();
        }

        private void OnEnable()
        {
            foreach (Button button in viewMainMenu.buttons)
            {
                button.gameObject.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
                button.gameObject.GetComponent<ButtonHover>().OnExit += AnimateButtonExit;
            }
        }

        private void OnDisable()
        {
            foreach (Button button in viewMainMenu.buttons)
            {
                button.gameObject.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
                button.gameObject.GetComponent<ButtonHover>().OnExit -= AnimateButtonExit;
            }
        }

        public void PlayShowAnimation() // [ ] What's animation?
        {
            rootCanvasGroup.DOFade(1f, fadeDuration);
        }

        public void AnimateButtonHover(RectTransform button)
        {
            button.DOScale(1.1f, 0.15f).SetEase(Ease.OutQuad);
        }

        public void AnimateButtonExit(RectTransform button)
        {
            button.DOScale(1f, 0.15f).SetEase(Ease.OutQuad);
        }
    }
}
