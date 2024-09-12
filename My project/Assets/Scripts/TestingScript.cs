using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingScript : MonoBehaviour
{
    private void Start() {
    }

    private void Update()
    {
        Debug.Log("Update" + Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Debug.Log("Fixupdate" + Time.deltaTime);
    }
}