using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Leo
{
    public class GameOver : MonoBehaviour
    {
        public TextMeshProUGUI roundsText;

        void OnEnable()
        {
            roundsText.text = PlayerStats.Rounds.ToString();
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Menu()
        {
            Debug.Log("Go To Menu");
        }
    }

}
