using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
[CreateAssetMenu(fileName = "NewRhythmClip", menuName = "Timeline/RhythmClip")]
public class RhythmClip : PlayableAsset, ITimelineClipAsset
{
    [SerializeField] private GameObject prefab;
    [Header("Settings")]
    [SerializeField] private double spawnTime;

    public ClipCaps clipCaps => throw new System.NotImplementedException();

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<RhythmBehaviour>.Create(graph);
    }
   
}
