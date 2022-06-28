using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{

    public Animator gunBoxAnim;
    public GameObject generator;
    public GameObject singleShot_Module, fullyAutomatic_Module;
    bool canLoad = false;
    public Text fullAutoUI, boltActionUI;

    private void Update()
    {
        if (Vector3.Distance(transform.position, generator.transform.position) <= 3.5f)
        {
            gunBoxAnim.SetBool("canOpen", true);

            if (!canLoad)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    StartCoroutine(CycleWeapons());
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    LoadWeapon();
                }
            }
        }
        else
        {
            gunBoxAnim.SetBool("canOpen", false);
        }
    }

    public void DestroyAllChildren()
    {
        while (transform.childCount != 0)
        {
            foreach (Transform item in transform)
            {
                DestroyImmediate(item.gameObject);
            }
        }
    }

    public void LoadWeapon()
    {
        DestroyAllChildren();

        GameObject weapon =
            Instantiate(
                GameObject.FindGameObjectWithTag("gun"),
            transform.position,
            transform.rotation, transform);

        AssaultRifleGenerator generator =
            weapon.GetComponent<AssaultRifleGenerator>();

        Destroy(generator);
        weapon.name = 
            "Assault Rifle";
        weapon.transform.position = 
            transform.position;

        int index = Random.Range(0, 2);

        if (index == 0)
        {
            Transform firePoint = GetComponentInChildren<FirePointRig>().transform;
            GameObject module = Instantiate(singleShot_Module, firePoint.position, firePoint.rotation, firePoint);
            GameObject hud = GameObject.FindGameObjectWithTag("HUD");
            Instantiate(boltActionUI, hud.transform.position, hud.transform.rotation, hud.transform);
        }
        else
        {
            Transform firePoint = GetComponentInChildren<FirePointRig>().transform;
            GameObject module = Instantiate(fullyAutomatic_Module, firePoint.position, firePoint.rotation, firePoint);
            GameObject hud = GameObject.FindGameObjectWithTag("HUD");
            Instantiate(fullAutoUI, hud.transform.position, hud.transform.rotation, hud.transform);
        }
        canLoad = false;
    }

    IEnumerator CycleWeapons(float time = 0.15f)
    {
        bool jackPot = false;
        int index = Random.Range(15, 30);

        while (!jackPot)
        {
            generator.GetComponent<AssaultRifleGenerator>().GenerateAssaultRifle();
            yield return new WaitForSeconds(time);
            index--;

            if (index < 1)
            {
                jackPot = true;
            }
        }

        canLoad = true;
    }
}
