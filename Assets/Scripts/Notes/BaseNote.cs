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
    
    private Canvas _canvas;

    protected event Action<BaseNote> OnTap;

    public void SetOnTapListener(Action<BaseNote> note)
    {
        OnTap = note;
    }

    public virtual void SetDirectorNController(PlayableDirector director, RhythmController controller)
    {
        this.director = director;
        this.controller = controller;
    }

    public virtual void Initialize()
    {
        _canvas = GetComponent<Canvas>();
        if(_canvas) _canvas.worldCamera = Camera.main;

        //Init button
        button = GetComponent<Button>();
        if (button)
        {
            Debug.Log($"Found button");
            button.onClick.AddListener(Tap);
        }

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
        //When action success
    }

    public virtual void Missed()
    {

    }
}
