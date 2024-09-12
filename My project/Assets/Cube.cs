using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myGameObject;
    void Start()
    {
       // myGameObject.transform.localScale = new Vector3(2, 3, 4);
       // myGameObject.transform.Translate(new Vector3(5,6,7));
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter:");
        Debug.Log("Đối tượng va chạm: " + collision.gameObject.name);
        Debug.Log("Vị trí va chạm: " + collision.contacts[0].point);
        Debug.Log("Hướng va chạm: " + collision.contacts[0].normal);
        Debug.Log("Vận tốc tương đối: " + collision.relativeVelocity);
        Debug.Log("Số điểm tiếp xúc: " + collision.contactCount);
        Debug.Log("Xung lực va chạm: " + collision.impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter:");
        Debug.Log("Đối tượng trigger: " + other.gameObject.name);
        Debug.Log("Vị trí của đối tượng trigger: " + other.transform.position);
        Debug.Log("Tag của đối tượng trigger: " + other.tag);
        Debug.Log("Layer của đối tượng trigger: " + LayerMask.LayerToName(other.gameObject.layer));
    }
}
