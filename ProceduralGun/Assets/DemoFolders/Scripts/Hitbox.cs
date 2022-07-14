using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int damage = 10;
    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Player")
        {
            StartCoroutine(col.GetComponent<PlayerMovement>().PlayerHurt());
            col.gameObject.GetComponent<PlayerMovement>().health -= damage;
            Debug.Log("HIT");
        }
    }
}
