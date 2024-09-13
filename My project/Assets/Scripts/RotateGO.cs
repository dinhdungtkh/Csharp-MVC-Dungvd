using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RotateGO : MonoBehaviour
{
    float speed = 500f;
    public AudioSource audioSource;
    float totalRotation = 0f;
    int roundCount = 0;
    
    public TextMeshProUGUI textMeshPro;
    void Start()
    {
       
    }
    
    void Update()
    {
        float rotationThisFrame = speed * Time.deltaTime * 10;
        transform.Rotate(0, 0, rotationThisFrame);
        textMeshPro.text = "Round: " + roundCount;
        
        totalRotation += rotationThisFrame;
        if (totalRotation >= 360f)
        {
            roundCount++;
            totalRotation -= 360f;
            
            if (roundCount >= 200)
            {
                if (audioSource != null && !audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                roundCount = 0;
            }
        }
    }
}
