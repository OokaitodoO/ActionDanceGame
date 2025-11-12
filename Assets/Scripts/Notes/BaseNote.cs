using System;
using UnityEngine;
using UnityEngine.Playables;

public class BaseNote : MonoBehaviour
{
    [Header("Out line")]
    [SerializeField] private Transform outLine;
    [SerializeField] private float speedScaling;
    [SerializeField] private Vector2 StartScale;
    [SerializeField] private Vector2 EndScale;

    public virtual void InitializeGameobject()
    {
        //Send this gameobject when instantiate to game manager

    }

    public virtual void InitializeOutline()
    {
        outLine.localScale = StartScale;
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

    }    
}
