using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject target;
    private Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Human");
        cameraOffset = new Vector3(0,1,-3);
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log(target.transform.position);
        transform.position = target.transform.position + cameraOffset;
    }
}
