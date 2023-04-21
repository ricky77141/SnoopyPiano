using System;
using System.Collections;
using UnityEngine;

namespace GameManagers
{
    public class NoteCollide : MonoBehaviour
    {
        [SerializeField] private GameObject woodstock;
        [SerializeField] private GameObject sleep;
        [SerializeField] private Sprite woodstock1, woodstock2, woodstock3;
        [SerializeField] private GameObject warningCanvas;
       
        private SpriteRenderer myRenderer;
        private int noteCollisions = 0;
        private bool hasCollided;

        private void Awake()
        {
            myRenderer = woodstock.GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Tags.NOTE) && !hasCollided)
            {
                hasCollided = true;
                sleep.SetActive(false);
                noteCollisions++;
                if (noteCollisions >= 3)
                {
                    myRenderer.sprite = woodstock3;
                }
                else
                {
                    myRenderer.sprite = woodstock2;
                    StartCoroutine(WaitBeforeSleep());
                }
                ScoreManager.instance.SetBell(noteCollisions-1);
                if (myRenderer.sprite == woodstock3)
                {
                    warningCanvas.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
        
        IEnumerator WaitBeforeSleep()
        {
            yield return new WaitForSeconds(1.5f);
            myRenderer.sprite = woodstock1;
            sleep.SetActive(true);
            hasCollided = false;
        }

        public void ResetThings()
        {
            Time.timeScale = 1;
            warningCanvas.SetActive(false);
            LiveManager.instance.RemoveLives();
            ScoreManager.instance.ResetBells();
            myRenderer.sprite = woodstock1;
            noteCollisions = 0;
            sleep.SetActive(true);
            hasCollided = false;
        }

    }
}
