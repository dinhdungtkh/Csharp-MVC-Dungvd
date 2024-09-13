using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingScript : MonoBehaviour
{
    public string nextSceneName;

    private void Start()
    {
        Debug.Log("Name: " + PlayerPrefs.GetString("Name"));
        Debug.Log("ID: " + PlayerPrefs.GetString("ID"));
        Debug.Log("Level: " + PlayerPrefs.GetInt("Level"));

       // Invoke("MoveToSceneTwo", 3.0f);
      
     
    }

    void MoveToSceneTwo()
    {
       // SceneManager.LoadScene(nextSceneName);
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
        //Debug.Log("Update is calling" + Time.deltaTime);
        if (Input.GetMouseButtonDown(0)) {
        Ray ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.transform.name);
            if (hit.transform.name == "Cube")
            {
                Debug.Log("Hit: " + hit.transform.name);
                SceneManager.LoadScene(nextSceneName);
            }
        }
        }
    }
    private void FixedUpdate()
    {
       // Debug.Log("Fixupdate is calling " + Time.deltaTime);
    }



}