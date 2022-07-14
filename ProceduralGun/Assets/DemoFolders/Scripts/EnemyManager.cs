using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject zombie1, zombie2;
    public int zombiesAlive;
    bool newWave = false;
    int currentWave, maxZombies;
    public Text currentWaveText, zombiesInScene;

    void Start()
    {
        currentWave = 1;
        maxZombies = 3;
        zombiesAlive = 0;
        currentWaveText = GameObject.Find("WaveCount").GetComponent<Text>();
        zombiesInScene = GameObject.Find("ZombieCount").GetComponent<Text>();

        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        currentWaveText.text = "WAVE: " + currentWave.ToString();
        zombiesInScene.text = "Zombies alive: " + zombiesAlive.ToString();

        if (newWave)
        {
            if (zombiesAlive <= 0)
            {
                StartCoroutine(SpawnEnemy());

                currentWave++;
            }
        }
    }

    IEnumerator SpawnEnemy(float time = 2.5f)
    {
        if (currentWave < 2)
        {
            for (int i = 0; i < maxZombies; i++)
            {
                int index = Random.Range(0, (transform.childCount - 1));
                Transform spawnPoint = transform.GetChild(index);

                GameObject zombie = Instantiate(zombie1, spawnPoint.position, transform.rotation);
                zombiesAlive++;

                yield return new WaitForSeconds(time);
            }
        }
        else
        {
            for (int i = 0; i < maxZombies; i++)
            {
                int zombieIndex = Random.Range(0, 2);
                int index = Random.Range(0, (transform.childCount - 1));
                Transform spawnPoint = transform.GetChild(index);

                if (zombieIndex == 0)
                {
                    GameObject zombie = Instantiate(zombie1, spawnPoint.position, transform.rotation);
                    zombiesAlive++;
                }
                else
                {
                    GameObject zombie = Instantiate(zombie2, spawnPoint.position, transform.rotation);
                    zombiesAlive++;
                }
                yield return new WaitForSeconds(time);
            }
        }
        yield return new WaitForEndOfFrame();
        maxZombies += 3;
        newWave = true;
    }
}
