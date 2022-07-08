using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Animator gunBoxAnim, infoTabAnim, gunAnim;
    public GameObject generator;
    public GameObject singleShot_Module, fullyAutomatic_Module, infoUI;
    bool canLoad = false, tutorial;
    public Text fullAutoUI, boltActionUI, instructions;

    private void Start()
    {
        infoUI = GameObject.Find("InfoTab");
        instructions = infoUI.GetComponentInChildren<Text>();
        infoTabAnim = infoUI.GetComponent<Animator>();
        gunAnim = GetComponent<Animator>();
        tutorial = true;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, generator.transform.position) <= 3.5f)
        {
            tutorial = false;
            gunBoxAnim.SetBool("canOpen", true);
            infoTabAnim.SetBool("showInfo", true);

            if (!canLoad)
            {
                instructions.text = "Press 'C' to generate a random weapon!";
                instructions.color = Color.white;

                if (Input.GetKeyDown(KeyCode.C))
                {
                    StartCoroutine(CycleWeapons());
                }
            }
            else
            {
                instructions.text = "Press 'C' to LOAD WEAPON!";
                instructions.color = Color.yellow;

                if (Input.GetKeyDown(KeyCode.C))
                {
                    LoadWeapon();
                }
            }
        }
        else
        {
            if (tutorial)
            {
                infoTabAnim.SetBool("showInfo", true);
                instructions.text = "1. Find the Gun Generator in the middle of the map.\n" + "2. Generate and LOAD and new weapon.\n" + "3. SHOOT ZOMBIES!!";
            }
            else
            {
                gunBoxAnim.SetBool("canOpen", false);
                infoTabAnim.SetBool("showInfo", false);
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
