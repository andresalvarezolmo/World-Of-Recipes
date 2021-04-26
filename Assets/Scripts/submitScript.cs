using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class submitScript : MonoBehaviour
{

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("Scripter").GetComponent<GameManager>();

    }
    public void submitButton()
    {
        gameManager.checkSolution();
    }
}
