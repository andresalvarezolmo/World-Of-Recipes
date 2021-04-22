using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    public Button[] levelButtons;
    // Start is called before the first frame update
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 0);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelReached) levelButtons[i].interactable = false;
        }

    }
    public void runSpanishLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void runItalianLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void runNetherlandsLevel()
    {
        SceneManager.LoadScene(4);
    }

    public void runBritishLevel()
    {
        SceneManager.LoadScene(5);
    }
    public void runAmericanLevel()
    {
        SceneManager.LoadScene(6);
    }
}
