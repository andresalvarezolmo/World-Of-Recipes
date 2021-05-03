using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script that provides functionality to the buttons from the game over screens at the end of each level
public class GameOverButtons : MonoBehaviour
{
    public GameObject gameOverScreenWrong;
    public void restartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    
    public void loadLevels()
    {
        SceneManager.LoadScene(1);
    }

    public void continueLevel()
    {
        gameOverScreenWrong.SetActive(false);
    }

}
