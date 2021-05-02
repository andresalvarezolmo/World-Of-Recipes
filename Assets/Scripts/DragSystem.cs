using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    //object that will be dragged in
    public GameObject dragArea;
    //type of sprite, appliance or ingredient
    public string type;
    //field to know if ingredient is included on the recipe
    public bool shouldBeIncluded;
    //field to track if user has selected the ingredient
    private bool selected;
    //field to track if sprite being moved
    private bool isMoving;
    SpriteRenderer sprite;

    //store originalColor from sprite before turning it into greyscale
    private Color originalColor;

    //store starting positions before being dragged 
    private float startingPositionX;
    private float startingPositionY;
    private Vector3 originalPosition;

    GameManager gameManager;

    public AudioSource selectedItemSound;
    public AudioSource unSelectedItemSound;

    private void Awake()
    {
        gameManager = GameObject.Find("Scripter").GetComponent<GameManager>();

    }

    void Start()
    {
        //set original position
        originalPosition = this.transform.localPosition;
        sprite = GetComponent<SpriteRenderer>();
        originalColor = GetComponent<SpriteRenderer>().material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        //update location of sprite every frame is being rendered
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
        //drag sprite if has not been selected yet
        if (Input.GetMouseButtonDown(0) && selected == false)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startingPositionX = mousePos.x - this.transform.localPosition.x;
            startingPositionY = mousePos.y - this.transform.localPosition.y;
            isMoving = true;
        }
        //deselect sprite so it can be dragged again
        if (Input.GetMouseButtonDown(0) && selected == true)
        {
            selected = false;
            sprite.color = originalColor;
            unSelectedItemSound.Play();


            if (this.type == "ingredient")
            {
                gameManager.DecreaseIngredientCounter(1);
                //CounterManager.counterManager.DecreaseIngredientCounter(1);
                if (this.shouldBeIncluded)
                {
                    //Debug.Log("Deselected correct Ingredient");
                    gameManager.unSelectedCorrectIngredient();
                }
            }
            else if (this.type == "appliance")
            {
                gameManager.DecreaseApplianceCounter(1);
                //CounterManager.counterManager.DecreaseApplianceCounter(1);
                if (this.shouldBeIncluded)
                {
                    //Debug.Log("Deselected correct Appliance");
                    gameManager.unSelectedCorrectAppliance();
                }
            }
        }
    }

    private void OnMouseUp()
    {
        isMoving = false;
        //if sprite has been dragged into the dragArea then mark it as selected
        if(Mathf.Abs(this.transform.localPosition.x - dragArea.transform.localPosition.x) <= 2 && 
           Mathf.Abs(this.transform.localPosition.y - dragArea.transform.localPosition.y) <= 2){
            //this.transform.localPosition = new Vector3(dragArea.transform.localPosition.x, dragArea.transform.localPosition.y, dragArea.transform.localPosition.z);
            sprite.color = new Color(0.3f, 0.4f, 0.6f);
            //Debug.Log(this.shouldBeIncluded); 
            selected = true;
            selectedItemSound.Play();

            //check type of selected item
            if (this.type == "ingredient")
            {
                gameManager.RaiseIngredientCounter(1);
                //CounterManager.counterManager.RaiseIngredientCounter(1);
                if (this.shouldBeIncluded)
                {
                    //Debug.Log("Selected correct Ingredient");
                    gameManager.selectedCorrectIngredient();
                }
            }
            else if (this.type == "appliance")
            {
                gameManager.RaiseApplianceCounter(1);
                //CounterManager.counterManager.RaiseApplianceCounter(1);
                if (this.shouldBeIncluded)
                {
                    //Debug.Log("Selected correct Appliance");
                    gameManager.selectedCorrectAppliance();
                }

            }

        }
        //move sprite back to original position
        this.transform.localPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);
    }
}
