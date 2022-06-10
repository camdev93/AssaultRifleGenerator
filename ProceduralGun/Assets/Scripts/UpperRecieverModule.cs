using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperRecieverModule : MonoBehaviour
{
    public GameObject bolt;
    public int numberOfBolts = 7;
    public void SpawnBolts(GameObject _gunPart)
    {
        MeshFilter mesh = _gunPart.GetComponent<MeshFilter>();
        float maxZ = mesh.sharedMesh.bounds.max.z;
        float minZ = mesh.sharedMesh.bounds.min.z;
        float maxY = mesh.sharedMesh.bounds.max.y;
        float minY = mesh.sharedMesh.bounds.min.y;

        for (int i = 0; i < numberOfBolts; i++)
        {
            float boltPosZ = Random.Range(minZ, maxZ);
            float boltPosY = Random.Range(minY, maxY)/3;

            int rand = Random.Range(0, 2);

            if (rand == 0)
            {
                Vector3 boltPosition = new Vector3(0.5f, boltPosY, boltPosZ);
                GameObject _bolt = Instantiate(bolt, boltPosition, transform.rotation, this.transform);
            }
            else
            {
                Vector3 boltPosition = new Vector3(-0.5f, boltPosY, boltPosZ);
                GameObject _bolt = Instantiate(bolt, boltPosition, transform.rotation, this.transform);
            }
        }
    }

    public void GenerateNewUpperReciever()
    {
        SpawnBolts(this.gameObject);

        float x = Random.Range(0.02f, 0.15f);
        float y = Random.Range(0.2f, 0.5f);
        float z = Random.Range(0.08f, 0.17f);

        transform.localScale = new Vector3(x, y, z);
    }
}
