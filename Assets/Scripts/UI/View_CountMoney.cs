using TMPro;
using UnityEngine;

namespace UI
{
    public class View_CountMoney : MonoBehaviour
    {
        [SerializeField] TMP_Text text;

        private void OnEnable()
        {
            PlayerStats.OnMoneyChanged += SetMoney;
        }

        private void OnDisable()
        {
            PlayerStats.OnMoneyChanged -= SetMoney;
        }

        public void SetMoney(float money)
        {
            text.text = $"{money.ToString()} $";
        }
    }
}
