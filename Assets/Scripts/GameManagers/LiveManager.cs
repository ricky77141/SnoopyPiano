using UnityEngine;
using UnityEngine.UI;

namespace GameManagers
{
    public class LiveManager : MonoBehaviour
    {
        public static LiveManager instance;

        [SerializeField] private Image[] livesImage;
        private int lives = 3;
        
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        public void RemoveLives()
        {
            lives--;
            livesImage[lives].gameObject.SetActive(false);
        }
    }
}
