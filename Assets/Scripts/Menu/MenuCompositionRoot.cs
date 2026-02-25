using UnityEngine;

namespace menu
{
    public class MenuCompositionRoot : MonoBehaviour
    {
        [SerializeField] MainMenuController mainMenuController;
        [SerializeField] ViewMainMenu ViewMainMenu;

        private void Awake()
        {
            ViewMainMenu.Initialize();
        }

        private void OnEnable()
        {
            ViewMainMenu.OnButtonSelectLevelClicked += mainMenuController.SwitchSсreen;
            ViewMainMenu.OnButtonBackClicked += mainMenuController.SwitchSсreen;
            ViewMainMenu.OnButtonExitClicked += mainMenuController.Exit;

            ViewMainMenu.OnButtonLevel1Clicked += mainMenuController.LoadLevel;
            ViewMainMenu.OnButtonLevel2Clicked += mainMenuController.LoadLevel;
            ViewMainMenu.OnButtonLevel3Clicked += mainMenuController.LoadLevel;
        }

        private void OnDisable()
        {
            ViewMainMenu.OnButtonSelectLevelClicked -= mainMenuController.SwitchSсreen;
            ViewMainMenu.OnButtonBackClicked -= mainMenuController.SwitchSсreen;
            ViewMainMenu.OnButtonExitClicked -= mainMenuController.Exit;

            ViewMainMenu.OnButtonLevel1Clicked -= mainMenuController.LoadLevel;
            ViewMainMenu.OnButtonLevel2Clicked -= mainMenuController.LoadLevel;
            ViewMainMenu.OnButtonLevel3Clicked -= mainMenuController.LoadLevel;
        }


    }
}
