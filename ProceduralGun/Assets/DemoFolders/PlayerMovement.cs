using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    CharacterController controller;
    public float speed, mouseSensitivity, gravity, jumpForce;
    Vector3 playerDir;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float ver = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -40f, 40f);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        playerDir.y -= gravity * Time.deltaTime;

        controller.Move(forward * ver);
        controller.Move(right * hor);
        controller.Move(playerDir);
        transform.Rotate(0, mouseX, 0);
        cam.transform.Rotate(-mouseY, 0, 0);

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerDir.y = jumpForce;
            }
        }

        Cursor.lockState = CursorLockMode.Locked;
    }
}
