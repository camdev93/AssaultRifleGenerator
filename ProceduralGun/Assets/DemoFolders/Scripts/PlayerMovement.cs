using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    CharacterController controller;
    public float speed, mouseSensitivity, gravity, jumpForce;
    [HideInInspector]
    public int health;
    public int maxHealth = 100;
    public Slider healthBar;
    Vector3 playerDir;
    public GameObject hurtUI;
    GameObject hud;
    GunController gun;

    void Start()
    {
        hud = GameObject.Find("HUD");
        health = maxHealth;
        healthBar.maxValue = maxHealth;

        cam = GetComponentInChildren<Camera>();
        controller = GetComponent<CharacterController>();
        gun = GetComponentInChildren<GunController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void GunAnimations()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            gun.gunAnim.SetBool("isRunning", true);
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            gun.gunAnim.SetBool("isRunning", false);
        }
    }

    float speedH = 2.0f, rotX = 0.0f;

    void CameraClamp()
    {
        rotX -= speedH * Input.GetAxis("Mouse Y");

        rotX = Mathf.Clamp(rotX, -30f, 30f);

        cam.transform.eulerAngles = new Vector3(rotX, 0, 0);
    }

    void Update()
    {
        if (health >= 1)
        {
            if (Time.timeScale == 1)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }

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

            healthBar.value = health;

            GunAnimations();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public IEnumerator PlayerHurt()
    {
        GameObject ui = Instantiate(hurtUI, hud.transform);
        ui.transform.SetAsFirstSibling();
        yield return new WaitForEndOfFrame();
    }
}
