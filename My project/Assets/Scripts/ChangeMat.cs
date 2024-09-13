using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    public Material mat;
    public Material mat2;
    void Start(){
        Invoke("Change", 2.0f);
        mat = GetComponent<Renderer>().material;
    }
    void Change(){
        GetComponent<Renderer>().material = mat2;
        Invoke("ChangeToMat", 2.0f);
    }
    void ChangeToMat(){
        GetComponent<Renderer>().material = mat;
         Invoke("Change", 2.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
