using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleShot : MonoBehaviour
{
    Slider reloadMeter;
    private Text ammoCount;
    public GameObject bullet;
    bool canShoot, isReloading;

    [HideInInspector]
    public int ammo, maxAmmo = 20;
    public int damage = 150;

    void Start()
    {
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
        if (ammo >= 1)
        {
            ammoCount.text = "Ammunition: " + ammo.ToString();

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
            ammoCount.text = "NO AMMO";
            reloadMeter.gameObject.SetActive(true);
            reloadMeter.value = 0;
        }

        if (isReloading)
        {
            Reload();
        }
    }

    void Reload()
    {
        reloadMeter.value += 1f*Time.deltaTime;

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
        reloadMeter.gameObject.SetActive(true);
        reloadMeter.value = 0;
        canShoot = false;
        GameObject _bullet = Instantiate(bullet, transform.position, transform.rotation);
        ammo--;
        isReloading = true;
        yield return new WaitForEndOfFrame();
    }
}
