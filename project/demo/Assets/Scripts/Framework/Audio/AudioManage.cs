using System.Collections;
using System.Collections.Generic;
using Framework.Common;
using UnityEngine;

public class AudioManage : ModelManage
{
    private AudioSource musicAudio;
    
    private Dictionary<string, AudioObject> mAllAudio = new Dictionary<string, AudioObject>();

    protected override void OnInit()
    {
        musicAudio = GameObject.Find("AudioManage").GetComponent<AudioSource>();
        GameObject.DontDestroyOnLoad(musicAudio);
    }
    
    /// <summary>
    /// 播放背景 唯一
    /// </summary>
    /// <param name="path"></param>
    /// <param name="delay"></param>
    /// <param name="isLoop"></param>
    public void PlayMusic(string path, float delay = 0, bool isLoop = true)
    {
        FindModel<ResourManage>().LoadAsset(path, LoadType.Syn, (obj) =>
        { 
            musicAudio.clip = obj as AudioClip;
            musicAudio.loop = isLoop;
            musicAudio.PlayDelayed(delay);
        });
    }
    
    public void PauseMusic()
    {
        musicAudio.Pause();
    }

    
    public void StopMusic()
    {
        musicAudio.Stop();
    }
    
    /// <summary>
    /// 播放声音 多个
    /// </summary>
    /// <param name="path"></param>
    /// <param name="delay"></param>
    /// <param name="isLoop"></param>
    public void PlayAudio(string path, float delay = 0, bool isLoop = false)
    {
        StopAudio(path);
        AudioObject mAudioObj = FindModel<ObjectPool>().PushOne("Audio/AudioObject").GetComponent<AudioObject>();
        FindModel<ResourManage>().LoadAsset(path, LoadType.Syn, (obj) =>
        { 
            mAudioObj.Play(obj as AudioClip, delay, isLoop);
        });
        mAllAudio.Add(path, mAudioObj);
    }
    
    public void StopAudio(string path)
    {
        if(mAllAudio.ContainsKey(path))
             mAllAudio[path].Stop();
    }
}
