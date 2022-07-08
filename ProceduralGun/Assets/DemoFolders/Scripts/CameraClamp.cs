using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    float speedH = 2.0f, rotX = 0.0f;

    void Update()
    {
        rotX += speedH * Input.GetAxis("Mouse Y");

        rotX = Mathf.Clamp(rotX, -30f, 30f);

        transform.eulerAngles = new Vector3(rotX, 0, 0);
    }
}
