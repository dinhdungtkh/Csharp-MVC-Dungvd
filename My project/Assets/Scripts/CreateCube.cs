using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeObject.transform.localScale = new Vector3(2, 2, 2);
        cubeObject.transform.position = new Vector3(0, 0, 0);  
        cubeObject.GetComponent<Renderer>().material.color = Color.red;    
    }

}
