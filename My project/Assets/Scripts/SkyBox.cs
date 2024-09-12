using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public Material skyboxNum1;
    public Material skyboxNum2;
    public Material skyboxNum3;
    public Material skyboxNum4;
    public float changeDuration = 15f;
    private float timer = 0f;
    private int currentSkyboxIndex = 0;
    private Material[] skyboxes;

    void Start()
    {
        skyboxes = new Material[] { skyboxNum1, skyboxNum2, skyboxNum3, skyboxNum4 };
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDuration)
        {
            currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxes.Length;
            RenderSettings.skybox = skyboxes[currentSkyboxIndex];
            timer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RenderSettings.skybox = skyboxNum2;
        }

    }

}