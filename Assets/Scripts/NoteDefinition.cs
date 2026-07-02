using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewNoteDefination", menuName = "Timeline/NoteDefination")]
public class NoteDefinition : ScriptableObject
{    
    [SerializeField] private GameObject prefab;
    public NoteType noteType;
    public double duration;
    public bool isLocked;

    [Header("Clip edit")]
    public Texture leftIcon;
    public Texture centerIcon;
    public Texture rightIcon;
    public Color bgColor;

    public GameObject GetPrefab()
    {
        return prefab;
    }
}
