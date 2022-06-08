using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform gun;
    public static float speed = 50f;
    public float angleChange = 3f;
    int angleIndex;

    private void Start()
    {
        StartCoroutine(CameraAngle(angleChange));
    }

    void Update()
    {
        switch (angleIndex)
        {
            case 0:
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.right), speed * Time.deltaTime);
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.up), speed * Time.deltaTime);
                break;
            case 1:
                transform.RotateAround(gun.position, transform.TransformDirection(-Vector3.right), speed * Time.deltaTime);
                transform.RotateAround(gun.position, transform.TransformDirection(-Vector3.up), speed * Time.deltaTime);
                break;
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.left), speed * Time.deltaTime);
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.down), speed * Time.deltaTime);
            case 2:
                transform.RotateAround(gun.position, transform.TransformDirection(-Vector3.left), speed * Time.deltaTime);
                transform.RotateAround(gun.position, transform.TransformDirection(-Vector3.down), speed * Time.deltaTime);
                break;
            case 3:
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.right), speed * Time.deltaTime);
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.down), speed * Time.deltaTime);
                break;
            case 4:
                transform.RotateAround(gun.position, transform.TransformDirection(-Vector3.right), speed * Time.deltaTime);
                transform.RotateAround(gun.position, transform.TransformDirection(-Vector3.down), speed * Time.deltaTime);
                break;
            case 5:
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.left), speed * Time.deltaTime);
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.up), speed * Time.deltaTime);
                break;
            case 6:
                transform.RotateAround(gun.position, transform.TransformDirection(-Vector3.left), speed * Time.deltaTime);
                transform.RotateAround(gun.position, transform.TransformDirection(-Vector3.up), speed * Time.deltaTime);
                break;
            case 7:
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.up), speed * Time.deltaTime);
                break;
        }
        


    }

    IEnumerator CameraAngle(float _angleChange)
    {
        while (true)
        {
            angleIndex = 7;//Random.Range(0, 8);
            yield return new WaitForSeconds(_angleChange);
        }
    }
}
