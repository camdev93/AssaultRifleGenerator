using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float thrust = 50f;

    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * thrust * Time.deltaTime;
        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Zombie1"|| collision.transform.tag == "Zombie2")
        {
            if (GameObject.FindGameObjectWithTag("Player").TryGetComponent<FullyAutomatic>(out FullyAutomatic component)) 
            {
                collision.gameObject.GetComponent<Zombie>().health -= component.damage;
                Destroy(this.gameObject);
                Debug.Log("auto");
            }

            if (GameObject.FindGameObjectWithTag("Player").TryGetComponent<SingleShot>(out SingleShot comp))
            {
                collision.gameObject.GetComponent<Zombie>().health -= comp.damage;
                Destroy(this.gameObject);
                Debug.Log("single");
            }
        }
    }
}
