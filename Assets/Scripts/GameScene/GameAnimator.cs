using UnityEngine;
using DG.Tweening;
using GameConstant;
using MyUI;

namespace GameConstant
{
    public class GameAnimator : MonoBehaviour
    {

        [SerializeField] private ViewPanelLevelCompleted viewPanelLevelCompleted;

        private void OnEnable()
        {
            viewPanelLevelCompleted.ButtonNext.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
            viewPanelLevelCompleted.ButtonMenu.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
            viewPanelLevelCompleted.ButtonRestart.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
            viewPanelLevelCompleted.ButtonNext.GetComponent<ButtonHover>().OnExit += AnimateButtonExit;
            viewPanelLevelCompleted.ButtonMenu.GetComponent<ButtonHover>().OnExit += AnimateButtonExit;
            viewPanelLevelCompleted.ButtonRestart.GetComponent<ButtonHover>().OnExit += AnimateButtonExit;
            
        }

        private void OnDisable()
        {
            viewPanelLevelCompleted.ButtonNext.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
            viewPanelLevelCompleted.ButtonMenu.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
            viewPanelLevelCompleted.ButtonRestart.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
            viewPanelLevelCompleted.ButtonNext.GetComponent<ButtonHover>().OnExit -= AnimateButtonExit;
            viewPanelLevelCompleted.ButtonMenu.GetComponent<ButtonHover>().OnExit -= AnimateButtonExit;
            viewPanelLevelCompleted.ButtonRestart.GetComponent<ButtonHover>().OnExit -= AnimateButtonExit;
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
