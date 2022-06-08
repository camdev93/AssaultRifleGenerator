using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineModule : MonoBehaviour
{
    public void GenerateNewMagazineModule()
    {
        float y = Random.Range(0.75f, 1.0f);
        float z = Random.Range(0.5f, 1.0f);

        transform.localScale = new Vector3(1.0f, y, z);
    }
}
