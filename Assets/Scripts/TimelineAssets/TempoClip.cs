using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[CreateAssetMenu(fileName = "NewTempoClip", menuName = "Timeline/TempoClip")]
public class TempoClip : PlayableAsset, ITimelineClipAsset
{
    public Texture clipIconTexture;
    public Color beatColor = Color.white;

    public TempoBehaviour template = new();

    public ClipCaps clipCaps => ClipCaps.None;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {                       
        return ScriptPlayable<TempoBehaviour>.Create(graph, template); 
    }
}
