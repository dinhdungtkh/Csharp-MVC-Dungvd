using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Invoke("cubeAnimation", 2.0f);
    }


    void cubeAnimation()
    {
      GameObject.Find("Cube").GetComponent<Animator>().SetBool("isRunning",true);
        
    } 

    void sphereAnimation()
    {
        Animator animator =  GameObject.Find("Sphere").GetComponent<Animator>();
        animator.SetBool("isRunning", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
