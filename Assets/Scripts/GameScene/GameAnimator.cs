using UnityEngine;
using DG.Tweening;
using MyUI;

namespace GameConstant
{
    public class GameAnimator : MonoBehaviour
    {

        [SerializeField] private ViewLevelCompleted viewLevelCompleted;
        [SerializeField] private ViewGameOver viewGameOver;


        private void OnEnable()
        {
            viewLevelCompleted.ButtonNext.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
            viewLevelCompleted.ButtonMenu.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
            viewLevelCompleted.ButtonRestart.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
            viewLevelCompleted.ButtonNext.GetComponent<ButtonHover>().OnExit += AnimateButtonExit;
            viewLevelCompleted.ButtonMenu.GetComponent<ButtonHover>().OnExit += AnimateButtonExit;
            viewLevelCompleted.ButtonRestart.GetComponent<ButtonHover>().OnExit += AnimateButtonExit;

            viewGameOver.ButtonMenu.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
            viewGameOver.ButtonMenu.GetComponent<ButtonHover>().OnExit += AnimateButtonExit;
            viewGameOver.ButtonRestart.GetComponent<ButtonHover>().OnEnter += AnimateButtonHover;
            viewGameOver.ButtonRestart.GetComponent<ButtonHover>().OnExit += AnimateButtonExit;
        }

        private void OnDisable()
        {
            viewLevelCompleted.ButtonNext.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
            viewLevelCompleted.ButtonMenu.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
            viewLevelCompleted.ButtonRestart.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
            viewLevelCompleted.ButtonNext.GetComponent<ButtonHover>().OnExit -= AnimateButtonExit;
            viewLevelCompleted.ButtonMenu.GetComponent<ButtonHover>().OnExit -= AnimateButtonExit;
            viewLevelCompleted.ButtonRestart.GetComponent<ButtonHover>().OnExit -= AnimateButtonExit;

            viewGameOver.ButtonMenu.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
            viewGameOver.ButtonMenu.GetComponent<ButtonHover>().OnExit -= AnimateButtonExit;
            viewGameOver.ButtonRestart.GetComponent<ButtonHover>().OnEnter -= AnimateButtonHover;
            viewGameOver.ButtonRestart.GetComponent<ButtonHover>().OnExit -= AnimateButtonExit;
        }

        public void AnimateButtonHover(RectTransform button)
        {
            button.DOScale(1.1f, 0.15f).SetEase(Ease.OutQuad);
            Debug.Log("FFFFFF");
        }

        public void AnimateButtonExit(RectTransform button)
        {
            button.DOScale(1f, 0.15f).SetEase(Ease.OutQuad);
        }
    }
}
