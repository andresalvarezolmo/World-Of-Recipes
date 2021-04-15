using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void selectedCorrectIngredient()
    {
        userCorrectIngredients++;
        Debug.Log("Correct ingredient selected. Amount: " + userCorrectIngredients);
    }
    public void unSelectedCorrectIngredient()
    {
        userCorrectIngredients--;
        Debug.Log("Correct ingredient unselected. Amount: " + userCorrectIngredients);
    }

    public void selectedCorrectAppliance()
    {
        userCorrectAppliances++;
        Debug.Log("Correct Appliance selected. Amount: " + userCorrectAppliances);
    }
    public void unSelectedCorrectAppliance()
    {
        userCorrectAppliances--;
        Debug.Log("Correct Appliance unselected. Amount: " + userCorrectAppliances);
    }
}
