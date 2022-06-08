using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeModule : MonoBehaviour
{
    public void GenerateNewScopeModule()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            float scale = Random.Range(0.75f, 2.0f);
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            float z = Random.Range(0.75f, 2.5f);
            transform.localScale = new Vector3(1.0f, 1.0f, z);
        }
    }
}
