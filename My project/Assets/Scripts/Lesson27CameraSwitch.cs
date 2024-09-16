using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson27CameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update 
    public GameObject camera1;
    public GameObject camera2;

    AudioListener camera1Listener;
    AudioListener camera2Listener;
    void Start()
    {
        camera1Listener = camera1.GetComponent<AudioListener>();
        camera2Listener = camera2.GetComponent<AudioListener>();

    }

    void Update()
    {
        SwitchCamera();
    }

    public void SwitchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            cameraChangeCounter();
        }
    }

    public void cameraPositionM()
    {
        cameraChangeCounter();
    }
    public void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
        PlayerPrefs.SetInt("CameraPosition", cameraPositionCounter);
    }

    public void cameraPositionChange(int cameraPosition)
    {
        cameraPosition %= 2; 
        PlayerPrefs.SetInt("CameraPosition", cameraPosition);

        camera1.SetActive(cameraPosition == 0);
        camera1Listener.enabled = (cameraPosition == 0);

        camera2.SetActive(cameraPosition == 1);
        camera2Listener.enabled = (cameraPosition == 1);
    }
}
