using TMPro;
using UnityEngine;

public class ViewCountdown : MonoBehaviour
{
    [SerializeField] TMP_Text textCountdown;

    public void SetTextCountdown(float countdown)
    {
        textCountdown.text = "New wave in: " + Mathf.Round(countdown).ToString();
    }
}
