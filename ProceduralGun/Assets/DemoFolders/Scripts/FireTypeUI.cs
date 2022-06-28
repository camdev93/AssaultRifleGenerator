using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTypeUI : MonoBehaviour
{
    float speed = 300f;
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
