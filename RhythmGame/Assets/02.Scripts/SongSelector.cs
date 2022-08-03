using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SongSelector : MonoBehaviour
{
    public static SongSelector instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        instance = this;
    }
    public VideoClip clip { get; private set; }
    public SongData songData { get; private set; }
    public bool isDataLoaded { get; private set; }
    public void LoadSongData(string clipName)
    {
        bool isOK = true;
        try // 예외가 발생하는지 시도.
        {
            clip = Resources.Load<VideoClip>($"VideoClips/{clipName}");
            TextAsset songDataText = Resources.Load<TextAsset>($"SongData/{clip.name}");
            JsonUtility.FromJson<SongData>(songDataText.ToString());
        }
        catch // 예외가 발생할경우 catch 문으로 반환
        {
            isOK = false;
        }
        finally // 예외 발생에 상관없이 마지막에 실행.
        {
        }

        isDataLoaded = isOK;
        if (isDataLoaded)
        {
            Debug.Log($"SongData Loaded : {clipName}");
        }
    }
}
