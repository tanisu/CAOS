using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private AudioSource startVoice;

    void Start()
    {
        startVoice = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        startVoice.PlayOneShot(startVoice.clip);
    }
}
