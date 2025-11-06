using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Rhythm
{
    public class RythmBehaviour : PlayableBehaviour
    {
        private NoteDefination noteDefination;
        private bool hasInstantiated = false;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (info.effectivePlayState != PlayState.Playing)
                return;

            if (hasInstantiated)
                return;

            double currentTime = playable.GetTime();
            double clipStartTime = playable.GetDuration() * playable.GetPreviousTime();

            float preRoll = noteDefination.preRollTime;
        }

        public override void OnGraphStop(Playable playable)
        {
            hasInstantiated = false;
        }
    }
}
