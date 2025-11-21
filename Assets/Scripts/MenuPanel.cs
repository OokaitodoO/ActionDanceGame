using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MenuPanel : MonoBehaviour
{    
    [SerializeField] private PlayableDirector director;

    [SerializeField] private TMP_Text songName;
    [SerializeField] private TMP_Text songBPM;
    [Space]
    [SerializeField] private TimelineAsset KodAw;
    [SerializeField] private TimelineAsset MaiHargGun;

    private void Start()
    {
        SetSongName("Mai Harg Gun");
        SetBPM(130);
        SetDirectorAsset(1);
    }

    public void SetSongName(string song)
    {
        songName.SetText(song);        
    }

    public void SetBPM(int BPM)
    {
        songBPM.SetText($"BPM : {BPM}");
    }    

    public void SetDirectorAsset(int songIndex)
    {
        switch (songIndex)
        {
            case 0:
                director.playableAsset = KodAw;
                break;
            case 1:
                director.playableAsset = MaiHargGun;
                break;
        }
    }
}
