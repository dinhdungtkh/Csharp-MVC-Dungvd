using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtYAxis : MonoBehaviour
{
    GameObject target;
    void Start()
    {
        target = GameObject.Find("Target");
    }
    void Update()
    {
        Vector3 targetPosition = new Vector3(
            target.transform.position.x,
            transform.position.y,
             target.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
