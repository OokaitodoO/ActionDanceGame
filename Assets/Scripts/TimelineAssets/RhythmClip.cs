using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
[CreateAssetMenu(fileName = "NewRhythmClip", menuName = "Timeline/RhythmClip")]
public class RhythmClip : PlayableAsset
{
    [SerializeField] private GameObject prefab;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<RhythmBehaviour>.Create(graph);
    }
   
}
