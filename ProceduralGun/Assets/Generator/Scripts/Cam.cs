using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform gun;
    public static float speed = 50f;
    public float angleChange = 3f;
    int angleIndex;

    float minimum = -1.0F;
    float maximum = 1.0F;

    static float t = 0.0f;

    private void Start()
    {
        StartCoroutine(CameraAngle(angleChange));
    }

    void Update()
    {
        switch (angleIndex)
        {
            case 0:
                transform.RotateAround(gun.position, transform.TransformDirection(Vector3.up), speed * Time.deltaTime);
                break;
            case 1:
                transform.RotateAround(gun.position, transform.TransformDirection(-Vector3.up), speed * Time.deltaTime);
                break;
        }

        float lerpValue = Mathf.Lerp(minimum, maximum, t);
        float camRigX = transform.position.x;
        float camRigZ = transform.position.z;
        transform.GetChild(0).position = new Vector3(camRigX, lerpValue, camRigZ);
        transform.GetChild(0).LookAt(gun.position);
        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }

    IEnumerator CameraAngle(float _angleChange)
    {
        while (true)
        {
            angleIndex = Random.Range(0, 2);
            yield return new WaitForSeconds(_angleChange);
        }
    }
}
