using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundClip : MonoBehaviour
{
    // Start is called before the first frame update 
    private static BGSoundClip instance = null;
    private static BGSoundClip Instance;
    private static readonly object padlock = new object();
    void Awake()
    {
        lock (padlock)
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            else { Instance = this;}
            DontDestroyOnLoad(this);
        }
        
    }

}
