using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource[] audioSources;
    public AudioClip startVoice;
    public AudioClip winVoice;
    public AudioClip loseVoice;
    public AudioClip countDown;
    //public AudioClip fight;
    
    public static AudioController I { get; private set; } = null;


    private void Awake()
    {
        
        I = this;
        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        if(I == this)
        {
            I = null;
        }
    }

    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }
    public void StartVoice()
    {
        audioSources[0].PlayOneShot(startVoice);
    }

    public void CountDown()
    {
        audioSources[0].PlayOneShot(countDown);
    }

    public void Fight()
    {
        audioSources[1].Play();
    }

    public void Win()
    {
        audioSources[0].PlayOneShot(winVoice);
    }

    public void Lose()
    {
        audioSources[0].PlayOneShot(loseVoice);
    }

    public void AudioStop()
    {
        audioSources[0].Stop();
        audioSources[1].Stop();
        audioSources[2].Stop();
    }

    public void Ending()
    {
        audioSources[2].Play();
    }

}
