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

    private void OnMouseDown()
    {
        gameManager.checkSolution();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
