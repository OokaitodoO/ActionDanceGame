using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [Space]
    [SerializeField] private AudioClip clickSound;

    public void PlayClickSound()
    {        
        audioSource.PlayOneShot(clickSound);
    }
    
}
