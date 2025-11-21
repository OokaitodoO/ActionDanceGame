using UnityEngine;

public class NoteConnectionLine : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    [SerializeField] private LineRenderer lineRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer)
            SetConnectionLine();
    }

    public void SetConnectionLine()
    {
        lineRenderer.SetPosition(0, start.position);
        lineRenderer.SetPosition(1, end.position);
    }
}
