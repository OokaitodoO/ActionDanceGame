using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using static NoteDefination;

[System.Serializable]
[CreateAssetMenu(fileName = "NewRhythmClip", menuName = "Timeline/RhythmClip")]
public class RhythmClip : PlayableAsset, ITimelineClipAsset
{
    [SerializeField] private NoteDefination defination;
    [Header("Settings")]
    [SerializeField] private double spawnTime;
    [SerializeField] private Vector2 spawnPosition;

    private RhythmBehaviour template = new();

    public double FixedDuration => defination.duration;
    public bool isLockedDuration => defination.isLocked;

    public ClipCaps clipCaps => ClipCaps.None; 

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        template.prefabToSpawn = defination.GetPrefab();
        template.spawnLocation = spawnPosition;

        return ScriptPlayable<RhythmBehaviour>.Create(graph, template);
    }      

    public NoteDefination GetDefination()
    {
        return defination;
    }

}
