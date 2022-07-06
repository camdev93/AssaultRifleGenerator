using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float thrust = 50f;

    [HideInInspector]
    float autoDamage = 20f, boltDamage = 150f;

    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * thrust * Time.deltaTime;
        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Zombie1"|| collision.transform.tag == "Zombie2")
        {
            if (this.transform.tag=="FullAuto") 
            {
                collision.gameObject.GetComponent<Zombie>().health -= autoDamage;
                Destroy(this.gameObject); 
                
                if (collision.gameObject.GetComponent<Zombie>().health <= 1)
                {
                    collision.gameObject.GetComponent<Zombie>().manager.zombiesAlive--;
                    Destroy(collision.collider);
                }
            }

            if (this.transform.tag == "BoltAction")
            {
                collision.gameObject.GetComponent<Zombie>().health -= boltDamage;
                Destroy(this.gameObject);

                if (collision.gameObject.GetComponent<Zombie>().health <= 1)
                {
                    collision.gameObject.GetComponent<Zombie>().manager.zombiesAlive--;
                    Destroy(collision.collider);
                }
            }
        }
    }
}
