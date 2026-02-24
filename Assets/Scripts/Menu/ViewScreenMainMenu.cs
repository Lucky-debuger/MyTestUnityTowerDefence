using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewScreenMainMenu : MonoBehaviour
{
    [SerializeField] Button buttonSelectLevel;

    public event Action<Button> OnButtonSelectLevelEnter;

    void OnEnable()
    {
        // buttonSelectLevel.OnPointerEnter( () => OnButtonSelectLevelEnter?.Invoke() );
    }
}
