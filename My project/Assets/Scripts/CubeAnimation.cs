using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Animator animator =  GameObject.Find("Cube").GetComponent<Animator>();
      animator.speed = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
