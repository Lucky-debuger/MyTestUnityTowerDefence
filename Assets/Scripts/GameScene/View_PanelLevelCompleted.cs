using System;
using UnityEngine;
using UnityEngine.UI;

public class View_PanelLevelCompleted : MonoBehaviour // [ ] Is it a good class?
{
    [SerializeField] private Button buttonNext;

    public event Action OnButtonNextClicked;

    private void OnEnable()
    {
        buttonNext.onClick.AddListener(ButtonNextClicked);
    }

    private void OnDisable()
    {
        buttonNext.onClick.RemoveListener(ButtonNextClicked);
    }

    private void ButtonNextClicked()
    {
        OnButtonNextClicked?.Invoke();
    }
}
