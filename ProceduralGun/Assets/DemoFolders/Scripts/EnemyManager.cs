using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject zombie1, zombie2;
    public static List<GameObject> zombiesAlive;
    bool canSpawn;
    int currentWave, maxZombies;
    public Text currentWaveText;//, zombiesInScene;

    void Start()
    {
        canSpawn = true;
        currentWave = 1;
        maxZombies = 30;
        currentWaveText = GameObject.Find("WaveCount").GetComponent<Text>();
        //zombiesInScene = GameObject.Find("ZombieCount").GetComponent<Text>();
    }

    void Update()
    {
        //int enemies = 
        currentWaveText.text = "WAVE: " + currentWave.ToString();
        //zombiesInScene.text = "Zombies: " + zombiesAlive.Count.ToString();

        if (canSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy(float time = 1f)
    {
        canSpawn = false;

        for (int i = 0; i < maxZombies; i++)
        {
            int zombieIndex = Random.Range(0, 2);
            int index = Random.Range(0, (transform.childCount-1));
            Transform spawnPoint = transform.GetChild(index);

            if (zombieIndex == 0)
            {
                GameObject zombie = Instantiate(zombie1, spawnPoint.position, transform.rotation);
                //zombiesAlive.Add(zombie);
            }
            else
            {
                GameObject zombie = Instantiate(zombie2, spawnPoint.position, transform.rotation);
                //zombiesAlive.Add(zombie);
            }
            yield return new WaitForSeconds(time);
        }

        maxZombies += 10;
        currentWave++;

        canSpawn = true;
    }
}
