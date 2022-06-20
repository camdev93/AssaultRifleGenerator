using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtstockModule : MonoBehaviour
{
    public Transform butt, stockPipe, cheekRest, rigPart, buttPart1, buttPart2;
  
    public void GenerateNewButtstock()
    {
        float stockRigY = Random.Range(0.04f,0.065f);
        float cheekRestY = Random.Range(-0.05f, 0.08f);
        float buttPart1Y = Random.Range(-0.05f, 0.06f);
        float buttPart2Y = Random.Range(-0.05f, 0.06f);
        float _butt = Random.Range(0.01f, 0.15f);
        float rigPartX = Random.Range(0, 25f);
        float sizeY = Random.Range(0.4f, 1f);
        float sizeZ = Random.Range(0.4f, 1f);

        stockPipe.position = butt.position + new Vector3(0, stockRigY, 0);
        cheekRest.position = butt.position + new Vector3(0, cheekRestY, 0);
        buttPart1.position = butt.position + new Vector3(0, buttPart1Y, 0);
        buttPart2.position = butt.position + new Vector3(0, buttPart2Y, 0);

        rigPart.eulerAngles = new Vector3(rigPartX,0,0);

        cheekRest.localScale = new Vector3(cheekRest.localScale.x, sizeY, sizeZ);
        buttPart1.localScale = new Vector3(buttPart1.localScale.x, sizeY, sizeZ);
        butt.localScale = new Vector3(_butt, _butt, _butt);
    }
}
