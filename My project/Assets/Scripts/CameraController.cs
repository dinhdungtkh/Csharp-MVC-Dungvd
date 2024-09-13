using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public float keyboardRotationSpeed = 100f;
    public float accelerometerSensitivity = 1f;

    private bool isTouchDevice;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        isTouchDevice = SystemInfo.deviceType == DeviceType.Handheld;

        if (!isTouchDevice)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        if (isTouchDevice)
        {
            CameraRotationAccelerometer();
        }
        else
        {
            CameraRotationMouseAndKeyboard();
        }
    }

    void CameraRotationAccelerometer()
    {
        Vector3 acceleration = Input.acceleration;

        rotationX -= acceleration.y * accelerometerSensitivity;
        rotationY += acceleration.x * accelerometerSensitivity;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    void CameraRotationMouseAndKeyboard()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationY += mouseX;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationY -= keyboardRotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationY += keyboardRotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rotationX -= keyboardRotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotationX += keyboardRotationSpeed * Time.deltaTime;
        }

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
