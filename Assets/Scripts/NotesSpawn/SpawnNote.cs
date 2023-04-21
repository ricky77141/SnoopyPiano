using System;
using System.Timers;
using GameManagers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NotesSpawn
{
    public class SpawnNote : MonoBehaviour
    {
        [SerializeField] private NotesPool[] notesPool;
        [SerializeField] private Transform[] spawnerPoints;
        [SerializeField] private float timeBetweenNotes = 1f;
        private bool canCreateNote;
        private float timer;
        private int noteToSpawn;
        
        private void Start()
        {
            CreateNote();
        }

        private void Update()
        {
            if (Time.time > timer)
                canCreateNote = true;
            
            CreateNote();
        }

        void CreateNote()
        {
            if (!canCreateNote)
                return;

            noteToSpawn = Random.Range(0, notesPool.Length);
            
            MoveNote newMoveNote = notesPool[noteToSpawn].GetNote();
            newMoveNote.transform.position = spawnerPoints[Random.Range(0, spawnerPoints.Length)].position;
            ResetTimer();
        }

        void ResetTimer()
        {
            canCreateNote = false;
            timer = Time.time + timeBetweenNotes;
        }

    }
}
