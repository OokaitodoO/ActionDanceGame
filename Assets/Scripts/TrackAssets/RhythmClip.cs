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

        private RythmBehaviour template = new();


        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {            
            template.SetDefiantion(noteDefination);
            var playable = ScriptPlayable<RythmBehaviour>.Create(graph, template);           
            return playable;
        }
    }
}
