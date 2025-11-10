using UnityEngine;
using UnityEngine.Playables;

namespace Rhythm
{
    public class RhythmProcessor : MonoBehaviour
    {
        [SerializeField] private PlayableDirector director;

        private double _currentTime;

        private void Update()
        {
            if (director != null && director.playableAsset != null)
            {
                _currentTime = director.time;
            }
        }

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


