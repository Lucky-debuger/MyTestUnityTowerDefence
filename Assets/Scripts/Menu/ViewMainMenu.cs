using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMainMenu : MonoBehaviour // [ ] Deal with this class
{
    [SerializeField] private Button buttonLevels;
    [SerializeField] private Button buttonExit;
    [SerializeField] private Button buttonBack;
    [SerializeField] private Button buttonLevel1;
    [SerializeField] private Button buttonLevel2;
    [SerializeField] private Button buttonLevel3;
    [SerializeField] private GameObject screenSelectLevel;
    [SerializeField] private GameObject screenMainMenu;

    // public Button ButtonLevel1 => buttonLevel1;
    // public Button ButtonLevel2 => buttonLevel2;
    // public Button ButtonLelve3 => buttonLevel3;

    public readonly List<Button> buttons = new List<Button>();

    public event Action<GameObject> OnButtonSelectLevelClicked;
    public event Action<GameObject> OnButtonBackClicked;
    public event Action OnButtonExitClicked;
    public event Action<string> OnButtonLevel1Clicked;
    public event Action<string> OnButtonLevel2Clicked;
    public event Action<string> OnButtonLevel3Clicked;

    public void Initialize()
    {
        buttons.Add(buttonLevels);
        buttons.Add(buttonBack);
        buttons.Add(buttonExit);
        buttons.Add(buttonLevel1);
        buttons.Add(buttonLevel2);
        buttons.Add(buttonLevel3);
    }

    private void OnEnable()
    {
        buttonLevels.onClick.AddListener(ButtonSelectLevelEnterClicked);
        buttonBack.onClick.AddListener(ButtonBackClicked);
        buttonExit.onClick.AddListener(ButtonExitClicked);
        buttonLevel1.onClick.AddListener(ButtonLevel1Clicked);
        buttonLevel2.onClick.AddListener(ButtonLevel2Clicked);
        buttonLevel3.onClick.AddListener(ButtonLevel3Clicked);
    }

    private void OnDisable()
    {
        buttonLevels.onClick.RemoveListener(ButtonSelectLevelEnterClicked);
        buttonBack.onClick.RemoveListener(ButtonBackClicked);
        buttonExit.onClick.RemoveListener(ButtonExitClicked);
        buttonLevel1.onClick.RemoveListener(ButtonLevel1Clicked);
        buttonLevel2.onClick.RemoveListener(ButtonLevel2Clicked);
        buttonLevel3.onClick.RemoveListener(ButtonLevel3Clicked);
    }

    private void ButtonSelectLevelEnterClicked() => OnButtonSelectLevelClicked?.Invoke(screenSelectLevel);
    private void ButtonBackClicked() => OnButtonBackClicked?.Invoke(screenMainMenu);
    private void ButtonExitClicked() => OnButtonExitClicked?.Invoke();
    private void ButtonLevel1Clicked() => OnButtonLevel1Clicked?.Invoke("Level_01");
    private void ButtonLevel2Clicked() => OnButtonLevel2Clicked?.Invoke("Level_02");
    private void ButtonLevel3Clicked() => OnButtonLevel3Clicked?.Invoke("Level_03");
}
