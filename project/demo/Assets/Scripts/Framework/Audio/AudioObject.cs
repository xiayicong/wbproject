using Framework.Common;
using UnityEngine;
using System.Collections;

/// <summary>
/// 播放声音组件
/// </summary>
public class AudioObject : MonoBehaviour
{
    private AudioSource audio;

    private Coroutine endFunction;

    public void Awake()
    {
        audio = this.GetComponent<AudioSource>();
    }
    
    /// <summary>
    /// 播放声音
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="delay"></param>
    /// <param name="isLoop"></param>
    public void Play(AudioClip clip, float delay = 0, bool isLoop = false)
    {
        audio.clip = clip;
        audio.loop = isLoop;
        audio.PlayDelayed(delay);
        if(!isLoop)
            endFunction = StartCoroutine(PlayEnd(clip.length));
    }
    
    public void Stop()
    {
        audio.Stop();
        StopCoroutine(endFunction);
    }
    
    /// <summary>
    /// 完成后自动销毁进回收池
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    private IEnumerator PlayEnd(float length)
    {
        yield return new WaitForSeconds(length);
        Destory();
    }

    void Destory()
    {
        GameEntry.instance.FindModel<ObjectPool>().PullOne("Audio/AudioObject", this.gameObject);
    }
}