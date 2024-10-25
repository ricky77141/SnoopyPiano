using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagers
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader instance;
        
        public void LoadPlayScene()
        {
            SceneManager.LoadScene(Tags.PLAYLEVEL);
        }

        public void Exit()
        {
            Application.Quit();
        }
        
        public void LoadMainMenu()
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
                
            SceneManager.LoadScene(Tags.MAINLEVEL);
        }

        public void PauseGame()
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }
}
