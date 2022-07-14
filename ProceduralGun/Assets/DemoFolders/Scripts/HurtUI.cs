using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtUI : MonoBehaviour
{
    void Update()
    {
        Destroy(this.gameObject, 0.2f);
    }
}
