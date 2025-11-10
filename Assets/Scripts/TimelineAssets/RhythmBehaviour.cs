using UnityEngine;
using UnityEngine.Playables;

public class RhythmBehaviour : PlayableBehaviour
{
    public GameObject prefabToSpawn;
    public Vector2 spawnLocation;

    private GameObject spawnedInstance;


    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (spawnedInstance == null && prefabToSpawn != null)
        {
            spawnedInstance = Object.Instantiate(prefabToSpawn, spawnLocation, Quaternion.identity);            
            spawnedInstance.name = $"{prefabToSpawn.name}_Instance";

            //Debug.Log($"<color=cyan>TL Spawn:</color> '{spawnedInstance.name}' created at time {playable.GetTime()}.");
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {        
        if (spawnedInstance != null)
        {
            if (!Application.isPlaying)
            {                
                Object.DestroyImmediate(spawnedInstance);
            }
            else
            {
                Object.Destroy(spawnedInstance);
            }

            spawnedInstance = null;

            //Debug.Log($"<color=yellow>TL Despawn:</color> Instance destroyed at time {playable.GetTime()}.");
        }
    }

    public override void OnGraphStop(Playable playable)
    {        
        if (spawnedInstance != null)
        {
            if (!Application.isPlaying)
            {
                Object.DestroyImmediate(spawnedInstance);
            }
            else
            {
                Object.Destroy(spawnedInstance);
            }
            spawnedInstance = null;
            //Debug.Log("<color=red>TL Cleanup:</color> Instance destroyed during Graph Stop.");
        }
    }
}
