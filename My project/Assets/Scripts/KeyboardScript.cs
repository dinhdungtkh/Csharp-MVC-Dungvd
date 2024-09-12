using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            Debug.Log("UpArrow");
        }        
        // Examples of other Input methods:
        
        // Check if left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button is pressed");
        }
        
        
        // Check if Space key is held down
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space key is being held");
        }
     
    }
}
