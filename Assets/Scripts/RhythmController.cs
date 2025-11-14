using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class RhythmController : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private Transform canvasParent;

    private Queue<BaseNote> _queueNotes = new();
    private List<BaseNote> _notes = new();

    private NoteAccuracyConfig _config = new();

    private void OnValidate()
    {
        InitTrack();
    }

    private void Start()
    {
        InitTrack();
    }    

    /*    public void AddNoteList(BaseNote note)
        {
            _notes.Add(note);
        }

        public void RemoveNoteList(BaseNote note)
        {
            _notes.Remove(note);
        }*/

    public void AddQueue(BaseNote note)
    {
        Debug.Log("Add queue");
        //Add queue
        _queueNotes.Enqueue(note);
        //Init note
        note.SetDirectorNController(director, this);
        note.Initialize();
        note.SetOnTapListener(OnTapNote);
        SetNoteToFront();
    }

    public void DeQueue()
    {
        //Remove queue
        if (_queueNotes.Count > 0)
        {
            _queueNotes.Dequeue();
        }
    }

    public bool IsCurrentPeek(BaseNote note)
    {
        if (note == _queueNotes.Peek())
        {
            return true;
        }

        return false;
    }

    public void InitTrack()
    {
        var asset = director.playableAsset;
        if (asset is TimelineAsset timeLineAsset)
        {
            foreach (var track in timeLineAsset.GetRootTracks())
            {
                if (track is RhythmTrack)
                {
                    Debug.Log($"Track: {track.name}");
                    var rhythm = track as RhythmTrack;
                    if (!rhythm.canvasParent)
                    {
                        rhythm.canvasParent = canvasParent;
                    }
                }
            }
        }
    }

    private void CalculateScore()
    {

    }

    private void OnTapNote(BaseNote note)
    {
        //Tap out of note => miss
        //Scored
        Destroy(note.gameObject);
        //Dequeue and destroy note
        DeQueue();
        //Set current note to front
        SetNoteToFront();
    }

    private void SetNoteToFront()
    {
        if (_queueNotes.Count > 0)
        {
            _queueNotes.Peek().transform.SetAsLastSibling();
        }
    }
}
