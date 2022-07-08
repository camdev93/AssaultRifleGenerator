using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleShot : MonoBehaviour
{
    Slider reloadMeter;
    private Text ammoCount;
    public GameObject bullet, gunRig;
    bool canShoot, isReloading;

    [HideInInspector]
    public int ammo, maxAmmo = 20;
    public int damage = 150;
    [HideInInspector]
    public float reloadTime = 2f;
    int playerHealth;
    GunController gun;

    void Start()
    {
        gun = GetComponentInParent<GunController>();
        playerHealth = GameObject.FindObjectOfType<PlayerMovement>().health;
        gunRig = GameObject.Find("GunRig");
        reloadMeter = GameObject.FindGameObjectWithTag("ReloadIndicator").GetComponent<Slider>();
        reloadMeter.maxValue = 1.6f;
        reloadMeter.gameObject.SetActive(false);
        ammoCount = GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>();
        ammo = maxAmmo;
        canShoot = true;
        isReloading = false;
    }

    void Update()
    {
        if (playerHealth >= 1)
        {
            if (ammo >= 1)
            {
                ammoCount.text = "Ammunition: " + ammo.ToString();
                ammoCount.color = Color.yellow;

                if (canShoot)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        StartCoroutine(Shoot());
                    }
                }
            }
            else
            {
                if (Vector3.Distance(gunRig.GetComponent<GunController>().transform.position, gunRig.GetComponent<GunController>().generator.transform.position) >= 3.5f)
                {
                    reloadMeter.gameObject.SetActive(false);
                    gunRig.GetComponent<GunController>().instructions.text = "NO AMMO.. Go generate another weapon!!";
                    gunRig.GetComponent<GunController>().infoTabAnim.SetBool("showInfo", true);
                    ammoCount.text = "NO AMMO";
                    ammoCount.color = Color.red;
                    reloadMeter.gameObject.SetActive(true);
                    reloadMeter.value = 0;
                }
            }

            if (isReloading)
            {
                Reload();
            }
        }
        else
        {
            gunRig.SetActive(false);
        }
    }

    void Reload()
    {
        reloadMeter.value += reloadTime * Time.deltaTime;

        if (reloadMeter.value == reloadMeter.maxValue)
        {
            canShoot = true;
            reloadMeter.value = 0;
            reloadMeter.gameObject.SetActive(false);
            isReloading = false;
        }
    }

    IEnumerator Shoot()
    {
        gun.gunAnim.Play("GunShoot");
        reloadMeter.gameObject.SetActive(true);
        reloadMeter.value = 0;
        canShoot = false;
        GameObject _bullet = Instantiate(bullet, transform.position, transform.rotation);
        ammo--;
        isReloading = true;
        yield return new WaitForEndOfFrame();
    }
}
