using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackcam : MonoBehaviour
{   
    static WebCamTexture backCam;
    void Start()
    {
        if (backCam == null)
        {
            backCam = new WebCamTexture();
        }
        
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.mainTexture = backCam;
        }
        else
        {
            Debug.LogError("Không tìm thấy Renderer trên GameObject");
        }
        
        if (!backCam.isPlaying)
        {
            backCam.Play();
        }
    }
    
    void Update()
    {
       
    }
}
