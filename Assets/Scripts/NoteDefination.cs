using UnityEngine;

[CreateAssetMenu(fileName = "NewNoteDefination", menuName = "Timeline/NoteDefination")]
public class NoteDefination : ScriptableObject
{
    public enum NoteType
    {
        Tap,
        Slide,
        Swipe,
    }

    [SerializeField] private GameObject prefab;
    public NoteType type;
    public double duration;
    public bool isLocked;

    public GameObject GetPrefab()
    {
        return prefab;
    }
}
