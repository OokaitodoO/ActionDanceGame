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
    protected RhythmController controller;
    protected Button button;
    
    protected NoteAccuracyConfig config = new();
    
    private Canvas canvas;

    public virtual void SetDirector(PlayableDirector director)
    {
        this.director = director;
        controller = director.gameObject.GetComponent<RhythmController>();
    }

    public virtual void Initialize()
    {
        canvas = GetComponent<Canvas>();
        if(canvas) canvas.worldCamera = Camera.main;
        //Init button
        button = GetComponent<Button>();
        if(button) button.onClick.AddListener(OnTap);
        //Init outline scale
        outLine.localScale = StartScale;        
        //Init queue handle
        controller.AddQueue(this);
    }

    public virtual void DestroyNote()
    {
        controller.DeQueue(this);
    }

    public virtual void UpdateOutline(double offsetHitTime, double startTime, double localTime)
    {          
        float sinceTime = (float)localTime - (float)startTime;
        float T_norm = Mathf.Clamp01((float)localTime / (float)offsetHitTime);        

        Vector3 newScale = Vector3.Lerp(StartScale, EndScale, T_norm);
        outLine.localScale = newScale;              
    }

    public virtual void OnTap()
    {
        Debug.Log($"Tap on base note");
    }

    public virtual void OnHold() 
    { 

    }
}
