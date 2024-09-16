using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
   void OnTriggerEnter(Collider other)
   {
    if(other.gameObject.tag == "Player")
    {
        anim.SetTrigger("openDoor");
        Debug.Log("Player entered the door");
    }
   }

   void OnTriggerExit(Collider other)
   {
    if(other.gameObject.tag == "Player")
    {
        anim.enabled = true;
        Debug.Log("Player exited the door");
    }
   }

   void PauseAnimationEvent()
   {
    anim.enabled = false;
   }
}
