using UnityEngine;
using UnityEngine.Playables;

public class TempoClip : PlayableAsset
{
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<TempoBehaviour>.Create(graph);
    }
}
