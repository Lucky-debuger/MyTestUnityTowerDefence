using UnityEngine;
using DG.Tweening;

namespace menu
{
    public class MainMenuAnimator : MonoBehaviour
    {
        [SerializeField] private CanvasGroup rootCanvasGroup; // [ ] Deal with the new component
        [SerializeField] private RectTransform panel;
        [SerializeField] private float fadeDuration = 0.5f;
        [SerializeField] private float moveDuration = 0.6f;
        [SerializeField] private float moveOffset = 200f;

        private void Awake()
        {
            rootCanvasGroup.alpha = 0f;
            panel.anchoredPosition += new Vector2(0, -moveOffset); // [ ] What's going on here
        }

        private void Start()
        {
            PlayShowAnimation();
        }

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

        public void AnimationButtonExit(RectTransform button)
        {
            button.DOScale(1.1f, 0.15f).SetEase(Ease.OutQuad);
        }
    }
}
