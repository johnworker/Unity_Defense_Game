using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Leo
{
    public class MoneyUI : MonoBehaviour
    {

        public TextMeshProUGUI moneyText;

        void Update()
        {
            moneyText.text = "$" + PlayerStats.Money.ToString();
        }
    }

}
