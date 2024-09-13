using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip idleClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        idleClip = Resources.Load<AudioClip>("SoundFX/idlesfx");
        
        if (idleClip != null)
        {
            Debug.Log("found idlesfx");
            audioSource.clip = idleClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("not foundidlesfx");
        }
    }

}
