using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitToDeskTop()
    {
        Application.Quit();
    }

    public void WeaponShowCase()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
