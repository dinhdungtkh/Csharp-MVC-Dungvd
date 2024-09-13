using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision" + collision.transform.name); 
        if (collision.transform.tag == "enemy")
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        } 
    }
}
