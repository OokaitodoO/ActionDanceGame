using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
[CreateAssetMenu(fileName = "NewSlideClip", menuName = "Timeline/SlideClip")]
public class SlideClip : RhythmClip
{
    [SerializeField] private Vector3 endPosistion;

    private SlideBehaviour slideTemplate = new();

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        slideTemplate.prefabToSpawn = defination.GetPrefab();
        slideTemplate.tapDuration = defination.duration;
        slideTemplate.spawnLocation = spawnPosition;
        slideTemplate.canvasParent = canvasParent;
        slideTemplate.clipStartTime = clipStartTime;
        slideTemplate.clipEndTime = clipEndTime;
        slideTemplate.clipLength = duration;

        return ScriptPlayable<SlideBehaviour>.Create(graph, slideTemplate);
    }
}
