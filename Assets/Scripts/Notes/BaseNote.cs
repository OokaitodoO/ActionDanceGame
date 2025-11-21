using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UI;

public class BaseNote : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("Out line")]
    [SerializeField] protected Transform outLine;    
    [SerializeField] private Vector2 StartScale;
    [SerializeField] private Vector2 EndScale;

    protected PlayableDirector director; 
    protected Canvas canvas;
    protected Button button;

    public AccuracyType accuracy;
    public double hitTime;
    public bool interacable;
    protected NoteAccuracyConfig _accuracyConfig = new();

    protected event Action<BaseNote> OnTap;
    protected event Action<BaseNote> OnSuccess;
    protected event Action<BaseNote> OnMiss;
    protected event Action<BaseNote> OnCheck;

    public void SetOnCheckListener(Action<BaseNote> onCheck)
    {
        OnCheck = onCheck;
    }

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

    public void SetCanvas(Canvas canvas)
    {
        this.canvas = canvas;
    }

    public virtual void SetDirectorNController(PlayableDirector director, GameManager controller)
    {
        this.director = director;        
    }

    public virtual void Initialize()
    {        
        accuracy = AccuracyType.Miss;        
        outLine.localScale = StartScale;              
    }

    public virtual void UpdateOutline(double offsetHitTime, double startTime, double localTime)
    {          
        float sinceTime = (float)localTime - (float)startTime;
        float T_norm = Mathf.Clamp01((float)localTime / (float)offsetHitTime);        

        Vector3 newScale = Vector3.Lerp(StartScale, EndScale, T_norm);
        outLine.localScale = newScale;              
    }
    
    public virtual void Success()
    {           
        OnSuccess?.Invoke(this);
    }

    public virtual void Missed()
    {
        OnMiss?.Invoke(this);
    }

    public virtual void CheckPlayNote()
    {
        OnCheck?.Invoke(this);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {        
        OnTap?.Invoke(this);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        
    }
}
