using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Rhythm
{
    [CreateAssetMenu(fileName = "NewRhythmClip", menuName = "Timeline/Rhythm Clip")]
    [Serializable]
    public class RhythmClip : PlayableAsset, ITimelineClipAsset
    {
        [Header("Defination")]
        [SerializeField] private NoteDefination noteDefination;
        [Space]
        [Header("Clip parameters")]
        [SerializeField] private Vector2 position;
        [SerializeField] private Transform parent;

        public ClipCaps clipCaps { get; }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<RythmBehaviour>.Create(graph);                   
            return playable;
        }
    }
}
