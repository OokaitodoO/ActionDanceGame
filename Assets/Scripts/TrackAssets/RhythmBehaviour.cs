using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Rhythm
{
    public class RythmBehaviour : PlayableBehaviour
    {
        private NoteDefination _noteDefination;
        private bool _hasInstantiated = false;

        private GameObject note;

        public void SetDefiantion(NoteDefination defination)
        {
            _noteDefination = defination;
        }

/*        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (info.effectivePlayState != PlayState.Playing)
                return;

            if (_hasInstantiated)
                return;

            double currentTime = playable.GetTime();
            double clipStartTime = playable.GetDuration() * playable.GetPreviousTime();

            float preRoll = _noteDefination.preRollTime;

            if (currentTime >= 0 && currentTime <= preRoll)
            {
                double clipLocalTime = playable.GetTime();

                if (clipLocalTime < info.deltaTime && !_hasInstantiated)
                {
                    GameObject go = _noteDefination.GetNotePrefab();
                    if (go != null)
                    {
                        var newNote = GameObject.Instantiate(go);
                        _hasInstantiated = true;
                    }
                }
            }
        }*/

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (!_hasInstantiated)
            {
                note = GameObject.Instantiate(_noteDefination.GetNotePrefab());
                _hasInstantiated = true;
            }
        }

        public override void OnGraphStop(Playable playable)
        {
            if (note)
            {
                GameObject.Destroy(note);
            }
            _hasInstantiated = false;
        }
    }
}
