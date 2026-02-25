using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyUI
{
    public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public event Action<RectTransform> OnEnter; // [ ] Should I add RectTransform?
        public event Action<RectTransform> OnExit;

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnEnter?.Invoke(GetComponent<RectTransform>());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnExit?.Invoke(GetComponent<RectTransform>());
        }
    }
}
