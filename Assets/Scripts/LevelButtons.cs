using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelButtons : MonoBehaviour
{
    public void BackButtonFunctionality()
    {
        SceneManager.LoadScene(1);
    }
}
