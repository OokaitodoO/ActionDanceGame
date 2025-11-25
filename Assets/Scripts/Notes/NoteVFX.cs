using TMPro;
using UnityEngine;

public class NoteVFX : MonoBehaviour
{    
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        text.raycastTarget = false;
    }

    public void SetText(string acc, Color color)
    {
        text.SetText(acc);
        text.color = color;
    }
}
