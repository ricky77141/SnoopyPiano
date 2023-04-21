using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameManagers
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager instance;
        
        [SerializeField] private AudioClip[] music;
        
        private AudioSource _myAudioSource;
        private int songNumber;
        
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
            songNumber = Random.Range(0, 4);
            PlaySong();
        }
        
        private void PlaySong()
        {
            _myAudioSource.clip = music[songNumber];
            _myAudioSource.Play();
            _myAudioSource.volume = 0.8f;
            _myAudioSource.loop = true;
        }
    }
}
