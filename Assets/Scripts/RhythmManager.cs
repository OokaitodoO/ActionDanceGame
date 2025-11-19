using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private Transform noteParent;
    [SerializeField] private Canvas canvas;
    [Space]
    [SerializeField] private RhythmUI rhythmUI;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject startBtn;
    [SerializeField] private GameObject summaryPanel;

    private Queue<BaseNote> _queueNotes = new();
    private List<BaseNote> _notes = new();

    private NoteAccuracyConfig _accuracyConfig = new();
    private ComboConfig _comboConfig = new();
    private GradeConfig _gradeConfig = new();

    private int _currentCombo;
    private int _currentScore;

    private int perfect;
    private int good;
    private int bad;
    private int miss;
    private int h_combo;

    private void OnValidate()
    {
        InitTrack();
    }

    private void Start()
    {
        //InitTrack();
        Initialize();        
    }

    #region GameState
    public void Initialize()
    {
        ResetCombo();
        ResetSocre();
        ResetStatisic();
        InitTrack();

        director.playOnAwake = false;
        director.stopped += EndGame;
    }

    public void StartGame()
    {
        //Reset variable
        ResetCombo();
        ResetSocre();

        director.Play();
    }

    public void EndGame(PlayableDirector director)
    {
        //Reset director
        director.Stop();
        director.time = 0;        

        //Enable sum panel
        gameplayPanel.SetActive(false);
        summaryPanel.SetActive(true);

        //Update summaray
        //Debug.Log($"{perfect}, {good}, {bad}, {miss}, {h_combo}, {_currentScore}");
        rhythmUI.UpdateStatisticAcc(perfect, good, bad, miss, h_combo, _currentScore);
        var grade = _gradeConfig.CalculateGrade(_currentScore);
        rhythmUI.UpdateGrade(grade);        
    }
    #endregion

    public void AddQueue(BaseNote note)
    {        
        //Add queue
        _queueNotes.Enqueue(note);
        //Init note
        note.SetDirectorNController(director, this);
        note.SetCanvas(canvas);
        note.Initialize();
        note.SetOnTapListener(OnTapNote);
        note.SetOnSuccessListener(OnSuccessNote);
        note.SetOnMissListener(OnMissNote);
        SetNoteToFront();
    }

    public void DeQueue()
    {
        //Remove queue
        if (_queueNotes.Count > 0)
        {
            //Debug.Log("Dequeue note");
            _queueNotes.Dequeue();
        }
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
                    var rhythm = track as RhythmTrack;
                    if (rhythm)
                    {
                        rhythm.canvasParent = noteParent;
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
        Debug.Log("Tap note");
        //Destroy note
        //Dequeue and destroy note        
        //Set current note to front
        SetNoteToFront();
    }

    private void OnSuccessNote(BaseNote note)
    {                
        //Set accuracy
        DeQueue();
        SetNoteToFront();       
        AddSocre(note.accuracy);
        rhythmUI.UpdateAccuracy(note.accuracy);

        Destroy(note.gameObject);
    }

    private void OnMissNote(BaseNote note)
    {
        DeQueue();
        SetNoteToFront();
        ResetCombo();        
        rhythmUI.UpdateAccuracy(AccuracyType.Miss);        
        CountStatistic(AccuracyType.Miss);

        if (!Application.isPlaying)
        {
            DestroyImmediate(note.gameObject);
        }
        else
        {
            Destroy(note.gameObject);
        }        
    }

    private void SetNoteToFront()
    {
        if (_queueNotes.Count > 0)
        {
            var note = _queueNotes.Peek().GetComponent<BaseNote>();
            if (note) note.interacable = true;
            note.transform.SetAsLastSibling();
        }
    }

    private void ResetCombo()
    {
        _currentCombo = 0;
        rhythmUI.UpdateCombo(_currentCombo);
    }

    private void ResetSocre()
    {
        _currentScore = 0;
        rhythmUI.UpdateScore(_currentCombo);
    }

    private void ResetStatisic()
    {
        perfect = 0;
        good = 0;
        bad = 0;
        miss = 0;
        h_combo = 0;
    }

    private void AddSocre(AccuracyType accuracy)
    {
        if (accuracy == AccuracyType.Miss)
        {
            ResetCombo();
        }
        else
        {
            AddCombo();
            h_combo = _currentCombo > h_combo ? _currentCombo : h_combo;
        }

        //score += combo multiplier * accuracy point
        _currentScore += Mathf.CeilToInt(_comboConfig.GetMultiplier(_currentCombo) * _accuracyConfig.GetScoreByAccuracyType(accuracy));
        CountStatistic(accuracy);
        rhythmUI.UpdateScore(_currentScore);
    }

    private void AddCombo()
    {
        _currentCombo++;
        rhythmUI.UpdateCombo(_currentCombo);
    }   
    
    private void CountStatistic(AccuracyType accuracy)
    {
        switch (accuracy)
        {
            case AccuracyType.Perfect:
                perfect++;
                break;
            case AccuracyType.Good:
                good++;
                break;
            case AccuracyType.Bad:
                bad++;
                break;
            case AccuracyType.Miss:
                miss++;
                break;
        }
    }    
}
