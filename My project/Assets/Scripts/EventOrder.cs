using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOrder : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake is called");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable is called");
    }

    void Start()
    {
        Debug.Log("Start is called");
    }

    void Update()
    {
        Debug.Log("Update is called every frame");
    }

    void LateUpdate()
    {
        Debug.Log("LateUpdate is called after Update");
    }

    void OnDisable()
    {
        Debug.Log("OnDisable is called");
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy is called");
    }
}
