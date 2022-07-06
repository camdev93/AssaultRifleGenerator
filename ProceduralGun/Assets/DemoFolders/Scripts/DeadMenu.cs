using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    PlayerMovement player;
    public GameObject deadMenu;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (player.health >= 1)
        {
            deadMenu.SetActive(false);
        }
        else
        {
            deadMenu.SetActive(true);
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
