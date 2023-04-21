using UnityEngine;
using UnityEngine.UI;

namespace GameManagers
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        [SerializeField] private Text scoreText;
        [SerializeField] private Image[] bells;
        private int score = 0;
        
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        public void SetScore()
        {
            score += 10;
            scoreText.text = score.ToString();
        }

        public void SetBell(int image)
        {
            bells[image].gameObject.SetActive(true);
        }

        public void ResetBells()
        {
            for (int i = 0; i < bells.Length; i++)
            {
                bells[i].gameObject.SetActive(false);
            }
        }
    }
}
