using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void runSpanishLevel()
    {
        SceneManager.LoadScene(2);
    }
}
