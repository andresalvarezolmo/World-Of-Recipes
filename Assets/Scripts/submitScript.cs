using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submitScript : MonoBehaviour
{

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("Scripter").GetComponent<GameManager>();

    }

    private void OnMouseDown()
    {
        //drag sprite it has not been selected yet
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.checkSolution();
        }
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
