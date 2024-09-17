using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SpinController : MonoBehaviour
{
    [Range(0, 1000)]
    public float rotationSpeed = 710;
    [Range(0, 1000)]
    public float RotatePower;
    public float StopPower;

    private Rigidbody2D rb;
    int inRotate;

    private bool isColliding = false;
    private float lastCollisionAngle = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    float t;
    private void Update()
    {
        if (rb.angularVelocity > 0)
        {
            rb.angularVelocity -= StopPower * Time.deltaTime;

            rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, 0, 1440);
        }

        if (rb.angularVelocity == 0 && inRotate == 1)
        {
            t += 1 * Time.deltaTime;
            if (t >= 0.5f)
            {
                if (isColliding)
                {
                    GetReward(lastCollisionAngle);
                }
                inRotate = 0;
                t = 0;
            }
        }
    }

    public void Rotete()
    {
        if (inRotate == 0)
        {
            rb.AddTorque(RotatePower);
            inRotate = 1;
        }
    }

    public void GetReward(float rot)
    {
        if (rot > 0 + 22 && rot <= 45 + 22)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
            Win(1);
        }
        else if (rot > 45 + 22 && rot <= 90 + 22)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            Win(2);
        }
        else if (rot > 90 + 22 && rot <= 135 + 22)
        {
            transform.eulerAngles = new Vector3(0, 0, 135);
            Win(3);
        }
        else if (rot > 135 + 22 && rot <= 180 + 22)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            Win(4);
        }
        else if (rot > 180 + 22 && rot <= 225 + 22)
        {
            transform.eulerAngles = new Vector3(0, 0, 225);
            Win(5);
        }
        else if (rot > 225 + 22 && rot <= 270 + 22)
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
            Win(6);
        }
        else if (rot > 270 + 22 && rot <= 315 + 22)
        {
            transform.eulerAngles = new Vector3(0, 0, 315);
            Win(7);
        }
        else if (rot > 315 + 22 && rot <= 360 + 22)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            Win(8);
        }

    }


    public void Win(int Score)
    {
        print(Score);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("arrow"))
        {
            isColliding = true;
            lastCollisionAngle = transform.eulerAngles.z;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("arrow"))
        {
            isColliding = false;
        }
    }
}
