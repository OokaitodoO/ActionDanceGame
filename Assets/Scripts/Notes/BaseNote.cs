using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BaseNote : MonoBehaviour
{
    [Header("Out line")]
    [SerializeField] private Transform outLine;
    [SerializeField] private float speedScaling;
    [SerializeField] private Vector2 StartScale;
    [SerializeField] private Vector2 EndScale;

    protected PlayableDirector director;
    protected RhythmManager controller;
    protected Button button;

    public AccuracyType accuracy;

    protected event Action<BaseNote> OnTap;
    protected event Action<BaseNote> OnSuccess;
    protected event Action<BaseNote> OnMiss;

    public void SetOnTapListener(Action<BaseNote> onTap)
    {
        OnTap = onTap;
    }

    public void SetOnSuccessListener(Action<BaseNote> onSuccess)
    {
        OnSuccess = onSuccess;
    }

    public void SetOnMissListener(Action<BaseNote> onMiss)
    {
        OnMiss = onMiss;
    }

    public virtual void SetDirectorNController(PlayableDirector director, RhythmManager controller)
    {
        this.director = director;
        this.controller = controller;
    }

    public virtual void Initialize()
    {
        //Init button
        button = GetComponent<Button>();
        if (button)
        {
            Debug.Log($"Found button");
            button.onClick.AddListener(Tap);
        }

        //Set accuracy
        accuracy = AccuracyType.Miss;

        //Init outline scale
        outLine.localScale = StartScale;              
    }

    public virtual void UpdateOutline(double offsetHitTime, double startTime, double localTime)
    {          
        float sinceTime = (float)localTime - (float)startTime;
        float T_norm = Mathf.Clamp01((float)localTime / (float)offsetHitTime);        

        Vector3 newScale = Vector3.Lerp(StartScale, EndScale, T_norm);
        outLine.localScale = newScale;              
    }

    public virtual void Tap()
    {        
        OnTap?.Invoke(this);
    }
    
    public virtual void Success()
    {           
        OnSuccess?.Invoke(this);
    }

    public virtual void Missed()
    {
        OnMiss?.Invoke(this);
    }
}
