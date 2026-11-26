
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform playerBody;
    public float sensitivity = 2f;

    private float xRotation = 0f;

    void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > Screen.width * 0.35f &&
                touch.phase == TouchPhase.Moved)
            {
                mouseX = touch.deltaPosition.x * sensitivity * 0.1f;
                mouseY = touch.deltaPosition.y * sensitivity * 0.1f;
            }
        }
        else
        {
            mouseX = Input.GetAxis("Mouse X") * sensitivity;
            mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation =
            Quaternion.Euler(xRotation, 0f, 0f);

        if (playerBody != null)
            playerBody.Rotate(Vector3.up * mouseX);
    }
}
