using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("UpArrow");
            rb.MovePosition(rb.position + new Vector3(0, 0, 1) * 5 * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("DownArrow");
            rb.MovePosition(rb.position + new Vector3(0, 0, -1) * 5 * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("LeftArrow");
            rb.MovePosition(rb.position + new Vector3(-1, 0, 0) * 5 * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("RightArrow");
            rb.MovePosition(rb.position + new Vector3(1, 0, 0) * 5 * Time.fixedDeltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
