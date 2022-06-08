using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerRecieverModule : MonoBehaviour
{
    public Transform triggerModuleConnection;
   public void GenerateNewLowerReciever()
   {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "GRIP")
            {
                for (int j = 0; j < transform.GetChild(i).childCount; j++)
                {
                    float x = transform.GetChild(i).GetChild(j).localScale.x + Random.Range(0.01f, 0.05f);
                    float y = transform.GetChild(i).GetChild(j).localScale.y + Random.Range(0.01f, 0.05f);
                    float z = transform.GetChild(i).GetChild(j).localScale.z + Random.Range(0.01f, 0.05f);

                    transform.GetChild(i).GetChild(j).localScale = new Vector3(x, y, z);
                }
            }else if (transform.GetChild(i).name == "Trigger")
            {
                transform.GetChild(i).position = triggerModuleConnection.position;
            }
            else
            {
                float x = transform.GetChild(i).localScale.x + Random.Range(0.003f, 0.06f);
                float y = transform.GetChild(i).localScale.y + Random.Range(0.001f, 0.007f);
                float z = transform.GetChild(i).localScale.z + Random.Range(0.003f, 0.07f);

                transform.GetChild(i).localScale = new Vector3(x, y, z);
            }
        }
   }
}
