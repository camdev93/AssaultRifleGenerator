using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject generator;
    bool canSwap = true, canLoad = false;

    private void Update()
    {
        if (Vector3.Distance(transform.position, generator.transform.position) < 3f)
        {
            if (canLoad)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    LoadWeapon();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    if (canSwap)
                    {
                        StartCoroutine(CycleWeapons());
                        canLoad = false;
                    }
                }
            }
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

        canSwap = true;
    }

    IEnumerator CycleWeapons(float time = 0.15f)
    {
        bool jackPot = false;
        int index = Random.Range(15, 30);
        canSwap = false;

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
