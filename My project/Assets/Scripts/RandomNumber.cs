using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber : MonoBehaviour
{
    int randomNumber;
    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(1, 1000);
        Debug.Log(randomNumber);
    }
}
