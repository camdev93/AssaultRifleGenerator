using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject zombie1, zombie2;
    bool canSpawn;
    int currentWave;

    void Start()
    {
        canSpawn = true;
        currentWave = 1;

    }

    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy(float time = 1f)
    {
        canSpawn = false;

        for (int i = 0; i < currentWave; i++)
        {
            GameObject zombie = Instantiate(zombie2, transform.position, transform.rotation);
        }

        yield return new WaitForSeconds(time);
    }
}
