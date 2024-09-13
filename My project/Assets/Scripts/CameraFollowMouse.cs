using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float speedHorizontal = 2.0f;
    public float speedVertical = 2.0f;
    public float smoothTime = 0.1f;

    private float yaw = 0f;
    private float pitch = 0f;
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentRotation = transform.eulerAngles;
    }

    void Update()
    {
        yaw += speedHorizontal * Input.GetAxis("Mouse X");
        pitch -= speedVertical * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        Vector3 targetRotation = new Vector3(pitch, yaw, 0f);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, smoothTime);
        transform.eulerAngles = currentRotation;

        if (Input.GetAxis("Mouse X") > 0)
        {
            Debug.Log("Mouse X: " + Input.GetAxisRaw("Mouse X"));
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speedHorizontal,
            0, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speedVertical);
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speedHorizontal,
             0, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speedVertical);
        }

    }
}
