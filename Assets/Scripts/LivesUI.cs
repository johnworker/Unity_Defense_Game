using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Leo
{
    public class LivesUI : MonoBehaviour
    {
        public TextMeshProUGUI livesText;

        void Update()
        {
            livesText.text = PlayerStats.Lives.ToString() + "LIVES";
        }
    }
}
