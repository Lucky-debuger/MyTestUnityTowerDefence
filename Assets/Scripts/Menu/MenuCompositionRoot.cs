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
        }
        private void OnDisable()
        {
            ViewMainMenu.OnButtonSelectLevelClicked -= mainMenuController.SwitchSсreen;
        }
    }
}
