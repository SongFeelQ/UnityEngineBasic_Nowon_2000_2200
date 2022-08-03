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
        try // ���ܰ� �߻��ϴ��� �õ�.
        {
            clip = Resources.Load<VideoClip>($"VideoClips/{clipName}");
            TextAsset songDataText = Resources.Load<TextAsset>($"SongData/{clip.name}");
            JsonUtility.FromJson<SongData>(songDataText.ToString());
        }
        catch // ���ܰ� �߻��Ұ�� catch ������ ��ȯ
        {
            isOK = false;
        }
        finally // ���� �߻��� ������� �������� ����.
        {
        }

        isDataLoaded = isOK;
        if (isDataLoaded)
        {
            Debug.Log($"SongData Loaded : {clipName}");
        }
    }
}
