using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{    
    [SerializeField] private PlayableDirector director;

    [SerializeField] private TMP_Text songName;
    [SerializeField] private TMP_Text songBPM;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [Space]
    [SerializeField] private TimelineAsset KodAw;
    [SerializeField] private TimelineAsset MaiHargGun;

    private List<SongConfig> _songList = new();
    private int songIndex = 0;

    private void Start()
    {
        Init();
        Updateinfo();
    }

    private void Init()
    {        
        _songList.Add(new SongConfig { timeAsset = MaiHargGun, bpm = 130, songName = "Mai Harg Gun" });
        _songList.Add(new SongConfig { timeAsset = KodAw, bpm = 140, songName = "Kod Aw" });

        nextButton.onClick.AddListener(OnClickNext);
        previousButton.onClick.AddListener(OnClickPrevious);

        Debug.Log($"Song list count : {_songList.Count}");
    }    

    private void OnClickPrevious()
    {
        songIndex--;
        if(songIndex < 0)
        {
            songIndex = _songList.Count - 1;
        }
        Updateinfo();
    }

    private void OnClickNext()
    {
        songIndex++;
        if (songIndex > _songList.Count - 1)
        {
            songIndex = 0;
        }        
        Updateinfo();
    }

    private void Updateinfo()
    {
        songName.SetText(_songList[songIndex].songName);
        songBPM.SetText(_songList[songIndex].bpm.ToString());
        director.playableAsset = _songList[songIndex].timeAsset;
    }
}
