using UnityEngine;

namespace GameManagers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        
        [SerializeField] private Transform snoopyPosition;
        
        [SerializeField] private AudioClip bgSFX;
        [SerializeField] private AudioClip HammerHit;
        [SerializeField] private AudioClip HammerWoosh;
        [SerializeField] private AudioClip BellHit;
        [SerializeField] private AudioClip WoodstockSurprise;
        [SerializeField] private AudioClip WoodstockCry;
        
        private AudioSource _myAudioSource;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            
            _myAudioSource = GetComponent<AudioSource>();
        }
        
        private void Start()
        {
            PlayBgSfx();
        }
        
        public void PlayHammerHit()
        {
            AudioSource.PlayClipAtPoint(HammerHit,snoopyPosition.position,2f);
        }
        
        public void PlayHammerWoosh()
        {
            AudioSource.PlayClipAtPoint(HammerWoosh,snoopyPosition.position,2f);
        }

        public void PlayBellHit()
        {
            AudioSource.PlayClipAtPoint(BellHit,snoopyPosition.position,2f);
        }
        
        public void PlayWoodStockSurprise()
        {
            AudioSource.PlayClipAtPoint(WoodstockSurprise,snoopyPosition.position,2f);
        }
        public void PlayWoodStockCry()
        {
            AudioSource.PlayClipAtPoint(WoodstockCry,snoopyPosition.position,2f);
        }
        
        private void PlayBgSfx()
        {
            _myAudioSource.clip = bgSFX;
            _myAudioSource.Play();
            _myAudioSource.volume = 0.8f;
            _myAudioSource.loop = true;
        }
    }
}
