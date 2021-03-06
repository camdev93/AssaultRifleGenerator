using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifleGenerator : MonoBehaviour
{
    public static GameObject gunPart;

    /* These variables must be made to initialise via the
     resources folder and not public access via the inspector.*/
    public List<GameObject> upperRecieverParts;
    public List<GameObject> lowerRecieverParts;
    public List<GameObject> barrelParts;
    public List<GameObject> buttstockParts;
    public List<GameObject> magazineParts;
    public List<GameObject> scopeParts;

    
    public void GenerateAssaultRifle()
    {
        DestroyAllChildren();

        GameObject randomUR = GetRandomComponent(upperRecieverParts);
        GameObject ur = Instantiate(randomUR, transform.position, Quaternion.identity, this.transform);
        AssaultRifleBody arb = ur.GetComponent<AssaultRifleBody>();

        UpperRecieverModule urm = GetComponentInChildren<UpperRecieverModule>();
        urm.GenerateNewUpperReciever();
        
        int swapValue = Random.Range(0, 2);

        Debug.Log(swapValue);

        if (swapValue == 1)
        {
            GenerateRifleComponents(magazineParts, arb.magazineSocketBack);
            GenerateRifleComponents(lowerRecieverParts, arb.lowerRecieverSocketFront);
        }
        else
        {
            GenerateRifleComponents(magazineParts, arb.magazineSocket);
            GenerateRifleComponents(lowerRecieverParts, arb.lowerRecieverSocket);
        }

        GenerateRifleComponents(scopeParts, arb.scopeSocket);
        GenerateRifleComponents(barrelParts, arb.barrelSocket);
        GenerateRifleComponents(buttstockParts, arb.buttstockSocket);

        BarrelModule bm = GetComponentInChildren<BarrelModule>();
        bm.GenerateNewBarrel();

        ButtstockModule bsm = GetComponentInChildren<ButtstockModule>();
        bsm.GenerateNewButtstock();

        LowerRecieverModule lrm = GetComponentInChildren<LowerRecieverModule>();
        lrm.GenerateNewLowerReciever();

        MagazineModule mm = GetComponentInChildren<MagazineModule>();
        mm.GenerateNewMagazineModule();

        ScopeModule sm = GetComponentInChildren<ScopeModule>();
        sm.GenerateNewScopeModule();
    }

    void GenerateRifleComponents(List<GameObject> parts, Transform socket)
    {
        GameObject randomPart = GetRandomComponent(parts);

        Instantiate(randomPart, socket.position, randomPart.transform.rotation, this.transform);
    }

    GameObject GetRandomComponent(List<GameObject> partList)
    {
        int rand = Random.Range(0,partList.Count);
        return partList[rand];
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
}
