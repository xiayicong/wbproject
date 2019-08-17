using Framework.Common;
using UnityEngine;
using System.Collections;

public class AudioObject : MonoBehaviour
{
    private AudioSource audio;

    private Coroutine endFunction;

    public void Awake()
    {
        audio = this.GetComponent<AudioSource>();
    }

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