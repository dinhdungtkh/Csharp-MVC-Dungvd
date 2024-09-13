using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
   bool isFiring;
   public AudioSource audioSource;
   public void pointerDown()
   {
    isFiring = true;
   }
   public void pointerUp()
   {
    isFiring = false;
   }

   void Update()
   {
    if(isFiring)
    {
        Debug.Log("Fire");
        audioSource.Play();
    }
   }
  
}
