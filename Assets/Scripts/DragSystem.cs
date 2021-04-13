using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    public GameObject dragArea;
    private bool isMoving;
    private bool selected;
    SpriteRenderer sprite;

    private Color originalColor;

    private float startingPositionX;
    private float startingPositionY;
    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = this.transform.localPosition;
        sprite = GetComponent<SpriteRenderer>();
        originalColor = GetComponent<SpriteRenderer>().material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        //update location of sprite
        if (isMoving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);    
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startingPositionX, mousePos.y - startingPositionY, this.gameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0) && selected == false)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startingPositionX = mousePos.x - this.transform.localPosition.x;
            startingPositionY = mousePos.y - this.transform.localPosition.y;
            isMoving = true;
        }
        //deselect sprite
        if (Input.GetMouseButtonDown(0) && selected == true)
        {
            Debug.Log("DESELECTED");
            selected = false;
            sprite.color = originalColor;
        }
    }

    private void OnMouseUp()
    {
        isMoving = false;
        //if sprite has been dragged into the dragArea then mark it as selected
        if(Mathf.Abs(this.transform.localPosition.x - dragArea.transform.localPosition.x) <= 3 && 
           Mathf.Abs(this.transform.localPosition.y - dragArea.transform.localPosition.y) <= 3){
            //this.transform.localPosition = new Vector3(dragArea.transform.localPosition.x, dragArea.transform.localPosition.y, dragArea.transform.localPosition.z);
            sprite.color = new Color(0.3f, 0.4f, 0.6f);
            Debug.Log("SELECTED"); 
            selected = true;
        }
        this.transform.localPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);
    }
}
