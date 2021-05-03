using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//simple script used for the buttons from the main menu
public class MenuScript : MonoBehaviour
{
    public void runLevelExplorer()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
