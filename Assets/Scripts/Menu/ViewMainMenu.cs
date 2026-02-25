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

    public readonly List<Button> buttons = new List<Button>();

    public event Action<GameObject> OnButtonSelectLevelClicked;
    public event Action OnButtonExitClicked;
    public event Action OnButtonBackClicked;
    public event Action OnButtonLevel1Clicked;
    public event Action OnButtonLevel2Clicked;
    public event Action OnButtonLevel3Clicked;

    public void Initialize()
    {
        buttons.Add(buttonLevels);
        buttons.Add(buttonExit);
        buttons.Add(buttonBack);
        buttons.Add(buttonLevel1);
        buttons.Add(buttonLevel2);
        buttons.Add(buttonLevel3);
    }

    private void OnEnable()
    {
        buttonLevels.onClick.AddListener(ButtonSelectLevelEnterClicked);
        buttonExit.onClick.AddListener(ButtonExitClicked);
        buttonBack.onClick.AddListener(ButtonBackClicked);
        buttonLevel1.onClick.AddListener(ButtonLevel1Clicked);
        buttonLevel2.onClick.AddListener(ButtonLevel2Clicked);
        buttonLevel3.onClick.AddListener(ButtonLevel3Clicked);
    }

    private void OnDisable()
    {
        buttonLevels.onClick.RemoveListener(ButtonSelectLevelEnterClicked);
        buttonExit.onClick.RemoveListener(ButtonExitClicked);
        buttonBack.onClick.RemoveListener(ButtonBackClicked);
        buttonLevel1.onClick.RemoveListener(ButtonLevel1Clicked);
        buttonLevel2.onClick.RemoveListener(ButtonLevel2Clicked);
        buttonLevel3.onClick.RemoveListener(ButtonLevel3Clicked);
    }

    private void ButtonSelectLevelEnterClicked() => OnButtonSelectLevelClicked?.Invoke(screenSelectLevel);
    private void ButtonExitClicked() => OnButtonExitClicked?.Invoke();
    private void ButtonBackClicked() => OnButtonBackClicked?.Invoke();
    private void ButtonLevel1Clicked() => OnButtonLevel1Clicked?.Invoke();
    private void ButtonLevel2Clicked() => OnButtonLevel2Clicked?.Invoke();
    private void ButtonLevel3Clicked() => OnButtonLevel3Clicked?.Invoke();
}
