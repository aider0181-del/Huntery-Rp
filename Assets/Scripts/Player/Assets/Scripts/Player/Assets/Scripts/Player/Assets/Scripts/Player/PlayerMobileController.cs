using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMobileController : MonoBehaviour
{
    public MobileJoystick joystick;
    public Transform cameraTransform;

    public float speed = 5f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = joystick != null
            ? joystick.Direction
            : Vector2.zero;

        Vector3 forward = cameraTransform != null
            ? cameraTransform.forward
            : transform.forward;

        Vector3 right = cameraTransform != null
            ? cameraTransform.right
            : transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * input.y + right * input.x;

        controller.Move(move * speed * Time.deltaTime);

        if (controller.isGrounded && verticalVelocity.y < 0)
            verticalVelocity.y = -2f;

        verticalVelocity.y += gravity * Time.deltaTime;

        controller.Move(verticalVelocity * Time.deltaTime);
    }
}
