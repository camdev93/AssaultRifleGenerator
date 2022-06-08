using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperRecieverModule : MonoBehaviour
{
    public void GenerateNewUpperReciever()
    {
        float x = Random.Range(0.02f, 0.15f);
        float y = Random.Range(0.2f, 0.5f);
        float z = Random.Range(0.08f, 0.17f);

        transform.localScale = new Vector3(x, y, z);
    }
}
