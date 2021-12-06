using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene("Task4");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void ButtonExit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
