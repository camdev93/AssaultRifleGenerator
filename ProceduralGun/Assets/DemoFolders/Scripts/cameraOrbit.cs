using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraOrbit : MonoBehaviour
{
    GameObject gunBox;
    public float speed = 10f;
    void Start()
    {
        gunBox = GameObject.Find("GunBox");
    }
    void Update()
    {
        float _speed = speed * Time.deltaTime;
        transform.RotateAround(gunBox.transform.position, Vector3.up, _speed);
    }
}
