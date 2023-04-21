using System;
using System.Collections;
using GameManagers;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace NotesSpawn
{
    public class MoveNote : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        private Animator myAnim;
        private SpriteRenderer mySprite;
        private Sprite theSprite;
        private BoxCollider2D myCollider;
        private bool hasCollided;

        private IObjectPool<MoveNote> notePool;

        private Vector2 targetPosition;

        private void Awake()
        {
            myAnim = GetComponent<Animator>();
            mySprite = GetComponent<SpriteRenderer>();
            myCollider = GetComponent<BoxCollider2D>();
            
        }

        private void Start()
        {
            theSprite = mySprite.sprite;
        }

        private void OnEnable()
        {
            myCollider.enabled = false;
            SelectWhereToMove();
        }

        private void OnDisable()
        {
            mySprite.sprite = theSprite;
        }

        private void Update()
        {
            Move();
        }

        void SelectWhereToMove()
        {
            targetPosition = new Vector2(Random.Range(-15, 15), 11);
        }
        
        void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 
                moveSpeed * Time.deltaTime);
            if (transform.position.y > -2.0f)
                myCollider.enabled = true;
        }

        public void SetPool(IObjectPool<MoveNote> pool)
        {
            notePool = pool;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((collision.CompareTag(Tags.HAMMER_TAG) || collision.CompareTag(Tags.BARRIER_TAG)) && !hasCollided)
            {
                hasCollided = true;
                myAnim.SetTrigger(Tags.NOTE_EXPLOSION);
                SoundManager.instance.PlayHammerHit();
                myCollider.enabled = false;
                if (collision.CompareTag((Tags.HAMMER_TAG)))
                {
                    ScoreManager.instance.SetScore();
                }

                StartCoroutine(WaitExplosion());
            }
        }
        
        IEnumerator WaitExplosion()
        {
            yield return new WaitForSeconds(0.6f);
            notePool.Release(this);
            hasCollided = false;
        }
        
    }
}
