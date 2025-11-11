using Rhythm;
using UnityEngine;
using UnityEngine.Playables;

public class BaseNote : MonoBehaviour
{
    [Header("Out line")]
    [SerializeField] private Transform outLine;
    [SerializeField] private float speedScaling;
    [SerializeField] private Vector2 StartScale;
    [SerializeField] private Vector2 EndScale;

    public virtual void InitializeOutline()
    {
        outLine.localScale = StartScale;
    }

    public virtual void UpdateOutline(double offsetHitTime, double startTime, double localTime)
    {
        //Know out line scale will be in every time        
        float sinceTime = (float)localTime - (float)startTime;
        float T_norm = Mathf.Clamp01((float)localTime / (float)offsetHitTime);        

        Vector3 newScale = Vector3.Lerp(StartScale, EndScale, T_norm);
        outLine.localScale = newScale;              
    }
}
