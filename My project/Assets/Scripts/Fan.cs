using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
  float spinSpeed = 1000;
  void Update()
  {
    transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
  }
}
