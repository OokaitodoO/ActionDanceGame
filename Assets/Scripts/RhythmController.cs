using Rhythm;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(RhythmProcessor))]
public class RhythmController : MonoBehaviour
{
    [SerializeField] private RhythmProcessor processor;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        //Get processor cache
        if(processor == null)
        {
            processor = GetComponent<RhythmProcessor>();
        }

        //Stop start play on awake
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
