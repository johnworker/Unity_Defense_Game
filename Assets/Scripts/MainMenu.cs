using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leo
{
    public class MainMenu : MonoBehaviour
    {
        public string levelToLoad = "���d";

        public void Play()
        {
            SceneManager.LoadScene(levelToLoad);
        }

        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

}
