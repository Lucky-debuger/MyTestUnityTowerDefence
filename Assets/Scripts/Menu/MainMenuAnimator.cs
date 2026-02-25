using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using MyUI;

namespace menu
{
    public class MainMenuAnimator : MonoBehaviour
    {
        [SerializeField] private CanvasGroup rootCanvasGroup; // [ ] Deal with the new component
        [SerializeField] private RectTransform panel;
        [SerializeField] private float fadeDuration = 0.5f;
        [SerializeField] private float moveDuration = 0.6f;
        [SerializeField] private float moveOffset = 200f;
        [SerializeField] private ViewMainMenu viewMainMenu;
        [SerializeField] private ButtonHover buttonHoverSelectLevel;

        private void Awake()
        {
            rootCanvasGroup.alpha = 0f;
            panel.anchoredPosition += new Vector2(0, -moveOffset); // [ ] What's going on here
        }

        private void Start()
        {
            PlayShowAnimation();
        }

        // private void OnEnable()
        // {
        //     foreach (Button button in viewMainMenu.buttons)
        //     {
        //         button.gameObject.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
        //         button.gameObject.GetComponent<ButtonHover>().OnExit += AnimateButtonHover;
        //     }

        //     // buttonHoverSelectLevel.OnEnter += AnimateButtonHover;
        //     // buttonHoverSelectLevel.OnExit += AnimateButtonExit;
        // }

        // private void OnDisable()
        // {
        //     foreach (Button button in viewMainMenu.buttons)
        //     {
        //         button.gameObject.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
        //         button.gameObject.GetComponent<ButtonHover>().OnExit -= AnimateButtonHover;
        //     }
        //     // buttonHoverSelectLevel.OnEnter -= AnimateButtonHover;
        //     // buttonHoverSelectLevel.OnExit -= AnimateButtonExit;
        // }

        public void PlayShowAnimation() // [ ] What's animation?
        {
            rootCanvasGroup.DOFade(1f, fadeDuration);
            panel.DOAnchorPosY(panel.anchoredPosition.y + moveOffset, moveDuration)
                .SetEase(Ease.OutBack);
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
