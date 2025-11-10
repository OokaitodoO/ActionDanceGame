using Rhythm;
using UnityEngine;
using UnityEngine.Playables;

public class RhythmController : MonoBehaviour
{
    [SerializeField] private RhythmProcessor processor;
    [SerializeField] private PlayableDirector director;

    private void Start()
    {
        if (director.state == PlayState.Playing)
        {
            director.Stop();
        }
    }

    public void StartDirector()
    {
        if (director.state == PlayState.Paused)
        {
            director.Play();
        }
    }
}
