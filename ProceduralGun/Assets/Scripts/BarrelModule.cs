using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelModule : MonoBehaviour
{
    public void GenerateNewBarrel()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            float x = Random.Range(0.6f, 1.5f);
            float y = Random.Range(0.2f, 1.5f);
            float z = Random.Range(0.6f, 2f);

            transform.GetChild(i).localScale = new Vector3(x, y, z);
        }

        transform.GetChild(0).position = transform.position;
        transform.GetChild(1).position = transform.GetChild(0).GetChild(0).GetChild(0).position;
        transform.GetChild(2).position = transform.GetChild(1).GetChild(0).GetChild(0).position;
        transform.GetChild(3).position = transform.position;
    }
}
