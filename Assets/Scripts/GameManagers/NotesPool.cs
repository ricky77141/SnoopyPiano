using System;
using System.Collections.Generic;
using NotesSpawn;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Pool;

namespace GameManagers
{
    public class NotesPool : MonoBehaviour
    {
        [SerializeField] private MoveNote noteObj;
        private int noteType;

        private IObjectPool<MoveNote> notesPool;

        private void Awake()
        {
            notesPool = new ObjectPool<MoveNote>(CreateNote, OnGet, OnRelease);
        }
        
        public MoveNote GetNote()
        {
            return notesPool.Get();
        }
        
        MoveNote CreateNote()
        {
            MoveNote newNote = Instantiate(noteObj, transform, true);
            newNote.SetPool(notesPool);

            return newNote;
        }

        void OnGet(MoveNote note)
        {
            note.gameObject.SetActive(true);
        }
        
        void OnRelease(MoveNote note)
        {
            note.gameObject.SetActive(false);
        }

    }
}
