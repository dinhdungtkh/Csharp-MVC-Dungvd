using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VisionOS;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] 
    private Animator animZombie;
    [SerializeField]
    private Rigidbody rbZombie;
[SerializeField]
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    { 
        animZombie = GetComponent<Animator>();
        rbZombie = GetComponent<Rigidbody>();
        animZombie.SetBool("Stop", true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
      {
        //animate zombie    
        animZombie.SetBool("Walk", true);
      }
       if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animZombie.SetBool("Stop", true);
        }

    }
    void FixedUpdate()
    {  
          //move zombie
      if (Input.GetKey(KeyCode.W))
      {
        rbZombie.MovePosition(transform.position + new Vector3(0,0,5) * speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.zero);
      } else
      if (Input.GetKey(KeyCode.S))
      {
        rbZombie.MovePosition(transform.position + new Vector3(0,0,-5) * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 180,0));
      } else 
      if (Input.GetKey(KeyCode.A))
      {
        rbZombie.MovePosition(transform.position + new Vector3(-5,0,0) * speed * Time.deltaTime);
         transform.rotation = Quaternion.LookRotation(Vector3.left);
      } else
      if (Input.GetKey(KeyCode.D))
      {
        rbZombie.MovePosition(transform.position + new Vector3(5,0,0) * speed * Time.deltaTime);
           transform.rotation = Quaternion.LookRotation(Vector3.right);
      } else {
         animZombie.SetBool("Stop", true);
      }
    }
}
