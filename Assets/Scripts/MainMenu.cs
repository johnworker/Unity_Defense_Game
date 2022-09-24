using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leo
{
    public class MainMenu : MonoBehaviour
    {
        public string levelToLoad = "MainLevel";

        public SceneFader sceneFader;

        public void Play()
        {
            sceneFader.FadeTo(levelToLoad);
        }

        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

}
