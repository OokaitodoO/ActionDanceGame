using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Rhythm
{
    public class RhythmProcessor : MonoBehaviour
    {
        public static RhythmProcessor Instance { get; private set; }

        [SerializeField] private PlayableDirector director;

        private Dictionary<int, RhythmTrack> _rhythmTracks = new();
        private TempoTrack _tempoTrack;

        private double _currentTime;        

        public double GetCurrentTime()
        {
            if (director != null)
            {
                return _currentTime;
            }

            return -1.0f;
        }
    }
}


