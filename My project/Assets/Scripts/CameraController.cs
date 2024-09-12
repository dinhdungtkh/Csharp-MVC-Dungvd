using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
       // target = GameObject.Find("Human");
       // cameraOffset = new Vector3(0,4,-3);
    }

    // Update is called once per frame
    void Update()
    {   
        //Debug.Log(target.transform.position);
        transform.position = target.transform.position + cameraOffset;
    }
}
