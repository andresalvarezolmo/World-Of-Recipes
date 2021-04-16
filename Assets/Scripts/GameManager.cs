using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject IngredientHolder;
    public GameObject[] Ingredients;
    public GameObject ApplianceHolder;
    public GameObject[] Appliances;

    [SerializeField]
    int correctIngredients = 0;
    int userCorrectIngredients = 0;

    [SerializeField]
    int correctAppliances = 0;
    int userCorrectAppliances = 0;

    //text variables
    int ingredientCounter = 0;
    int applianceCounter = 0;
    public Text IngredientDisplayText;
    public Text ApplianceDisplayText;

    //submit button
    public SpriteRenderer submitButton;

    // Start is called before the first frame update
    void Start()
    {
        correctIngredients = IngredientHolder.transform.childCount;

        Ingredients = new GameObject[correctIngredients];
        for(int i = 0; i < Ingredients.Length; i++)
        {
            Ingredients[i] = IngredientHolder.transform.GetChild(i).gameObject;
            Debug.Log(IngredientHolder.transform.GetChild(i).gameObject);
        }

        correctAppliances = ApplianceHolder.transform.childCount;
        Appliances = new GameObject[correctAppliances];
        for (int j = 0; j < Appliances.Length; j++)
        {
            Appliances[j] = ApplianceHolder.transform.GetChild(j).gameObject;
            Debug.Log(ApplianceHolder.transform.GetChild(j).gameObject);
        }

    }

    public void checkAmountofIngredients()
    {
        if(ingredientCounter == correctIngredients && applianceCounter == correctAppliances)
        {
            Debug.Log("User can submit");
            submitButton.color = new Color(255, 255, 255, 255);
        }
        else
        {
            submitButton.color = new Color(255, 0, 0, 255);
        }
    }

    public void checkSolution()
    {
        if(ingredientCounter == correctIngredients && applianceCounter == correctAppliances)
        {
            if (userCorrectIngredients == correctIngredients && userCorrectAppliances == correctAppliances)
            {
                Debug.Log("Correct solution");
            }
            else
            {
                Debug.Log("Incorrect solution");
            }
        }
        else
        {
            Debug.Log("Solution does not meet the requirements");
        }

    }

    public void selectedCorrectIngredient()
    {
        userCorrectIngredients++;
        Debug.Log("Correct ingredient selected. Amount: " + userCorrectIngredients);
        checkAmountofIngredients();
    }
    public void unSelectedCorrectIngredient()
    {
        userCorrectIngredients--;
        Debug.Log("Correct ingredient unselected. Amount: " + userCorrectIngredients);
        checkAmountofIngredients();
    }

    public void selectedCorrectAppliance()
    {
        userCorrectAppliances++;
        Debug.Log("Correct Appliance selected. Amount: " + userCorrectAppliances);
        checkAmountofIngredients();
    }

    public void unSelectedCorrectAppliance()
    {
        userCorrectAppliances--;
        Debug.Log("Correct Appliance unselected. Amount: " + userCorrectAppliances);
        checkAmountofIngredients();
    }

    public void RaiseIngredientCounter(int s)
    {
        ingredientCounter += s;
        //Debug.Log(ingredientCounter);
        IngredientDisplayText.text = "Selected ingredients " + ingredientCounter + "/"  + correctIngredients;
    }
    public void DecreaseIngredientCounter(int s)
    {
        ingredientCounter -= s;
        //Debug.Log(ingredientCounter);
        IngredientDisplayText.text = "Selected ingredients " + ingredientCounter + "/" + correctIngredients;
    }

    public void RaiseApplianceCounter(int s)
    {
        applianceCounter += s;
        //Debug.Log(applianceCounter);
        ApplianceDisplayText.text = "Selected appliance " + applianceCounter + "/" + correctAppliances;
    }
    public void DecreaseApplianceCounter(int s)
    {
        applianceCounter -= s;
        //Debug.Log(applianceCounter);
        ApplianceDisplayText.text = "Selected appliance " + applianceCounter + "/" + correctAppliances;
    }


}
