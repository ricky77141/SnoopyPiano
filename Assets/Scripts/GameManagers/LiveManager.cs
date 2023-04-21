using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameManagers
{
    public class LiveManager : MonoBehaviour
    {
        public static LiveManager instance;

        [SerializeField] private Image[] livesImage;
        [SerializeField] private GameObject gameOverCanvas;
        private int lives = 3;
        
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        public int RemoveLives()
        {
            lives--;
            livesImage[lives].gameObject.SetActive(false);
            if (lives == 0)
            {
                gameOverCanvas.SetActive(true);
                Time.timeScale = 0;
            }

            return lives;
        }

        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(Tags.MAINLEVEL);
        }
        
    }
}
