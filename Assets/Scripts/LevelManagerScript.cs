using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//script that provides functionality to the level select scene
public class LevelManagerScript : MonoBehaviour
{
    public Button[] levelButtons;
    private void Start()
    {
        string levelReached = encryptScript.EncryptDecrypt(PlayerPrefs.GetString("LevelReached"),200);
        Debug.Log(levelReached);
        
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > int.Parse(levelReached)) levelButtons[i].interactable = false;
        }

    }
    //resets the stored number of unlocked levels so a player can restart the game
    public void resetUnlockedLevels()
    {
        Debug.Log("aqui tamos");
        PlayerPrefs.SetString("LevelReached", encryptScript.EncryptDecrypt("0",200));
        SceneManager.LoadScene(1);

    }

    //these methods are used to load each different level's scene

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
    public void runAmericanLevel()
    {
        SceneManager.LoadScene(5);
    }
    public void runBritishLevel()
    {
        SceneManager.LoadScene(6);
    }
    public void runMexicanLevel()
    {
        SceneManager.LoadScene(7);
    }
    public void backButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
}
