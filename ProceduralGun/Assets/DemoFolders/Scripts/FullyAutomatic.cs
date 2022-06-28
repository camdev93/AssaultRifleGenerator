using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullyAutomatic : MonoBehaviour
{
    private Text ammoCount;
    public GameObject bullet;
    bool canShoot;

    [HideInInspector]
    public int ammo, maxAmmo = 150;
    public int damage = 20;

    void Start()
    {
        ammoCount = GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>();
        ammo = 150;
        canShoot = true;
    }

    void Update()
    {
        if (ammo >= 1)
        {
            ammoCount.text = "Ammunition: " + ammo.ToString();
            ammoCount.color = Color.yellow;

            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Shoot());
            }
            else if (Input.GetMouseButtonUp(0))
            {
                canShoot = false;
                Debug.Log("Up");
            }
        }
        else
        {
            ammoCount.text = "NO AMMO";
            ammoCount.color = Color.red;
            canShoot = false;
        }
    }

    IEnumerator Shoot(float _time = 0.1f)
    {
        canShoot = true;

        do
        {
            GameObject _bullet = Instantiate(bullet, transform.position, transform.rotation);
            ammo--;
            yield return new WaitForSeconds(_time);
        } while (canShoot);
    }
}
