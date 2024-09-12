using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingScript : MonoBehaviour
{


    private void Start()
    {
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        Invoke("myMethod", 2.5f);
    }
    private void myMethod()
    {
        GameObject.Find("Plane").SetActive(false);
    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    private void Update()
    {
        Debug.Log("Update is calling" + Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Debug.Log("Fixupdate is calling " + Time.deltaTime);
    }



}