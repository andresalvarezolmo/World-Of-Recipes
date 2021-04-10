using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    public GameObject dragArea;
    private bool isMoving;

    private float startingPositionX;
    private float startingPositionY;
    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startingPositionX = mousePos.x - this.transform.localPosition.x;
            startingPositionY = mousePos.y - this.transform.localPosition.y;

            isMoving = true;
        }
    }

    private void OnMouseUp()
    {
        isMoving = false;
        if(Mathf.Abs(this.transform.localPosition.x - dragArea.transform.localPosition.x) <= 3 && 
           Mathf.Abs(this.transform.localPosition.y - dragArea.transform.localPosition.y) <= 3){
            this.transform.localPosition = new Vector3(dragArea.transform.localPosition.x, dragArea.transform.localPosition.y, dragArea.transform.localPosition.z);
        }
        else
        {
            this.transform.localPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);
        }
    }
}
