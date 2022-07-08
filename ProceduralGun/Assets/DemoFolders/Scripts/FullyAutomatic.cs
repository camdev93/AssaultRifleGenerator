using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullyAutomatic : MonoBehaviour
{
    private Text ammoCount;
    public GameObject bullet, gunRig;
    bool canShoot;

    [HideInInspector]
    public int ammo, maxAmmo = 300;
    public int damage = 20;
    int playerHealth;
    GunController gun;

    void Start()
    {
        gun = GetComponentInParent<GunController>();
        playerHealth = GameObject.FindObjectOfType<PlayerMovement>().health;
        gunRig = GameObject.Find("GunRig");
        ammoCount = GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>();
        ammo = 150;
        canShoot = true;
    }

    void Update()
    {
        if (playerHealth >= 1)
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
                gunRig.GetComponent<GunController>().instructions.text = "NO AMMO.. Go generate another weapon!!";
                gunRig.GetComponent<GunController>().infoTabAnim.SetBool("showInfo", true);
                ammoCount.text = "NO AMMO";
                ammoCount.color = Color.red;
                canShoot = false;
            }
        }
        else
        {
            gunRig.SetActive(false);
        }
    }

    IEnumerator Shoot(float _time = 0.1f)
    {
        canShoot = true;

        do
        {
            gun.gunAnim.Play("GunShoot");
            GameObject _bullet = Instantiate(bullet, transform.position, transform.rotation);
            ammo--;
            yield return new WaitForSeconds(_time);
        } while (canShoot);
    }
}
