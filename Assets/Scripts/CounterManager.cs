using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CounterManager : MonoBehaviour
{
    public static CounterManager counterManager;
    int ingredientCounter = 0;
    int applianceCounter = 0;
    public Text IngredientDisplayText;
    public Text ApplianceDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        counterManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RaiseIngredientCounter(int s)
    {
        ingredientCounter += s;
        //Debug.Log(ingredientCounter);
        IngredientDisplayText.text = "Selected ingredients " + ingredientCounter + "/x";
    }
    public void DecreaseIngredientCounter(int s)
    {
        ingredientCounter -= s;
        //Debug.Log(ingredientCounter);
        IngredientDisplayText.text = "Selected ingredients " + ingredientCounter + "/x";
    }

    public void RaiseApplianceCounter(int s)
    {
        applianceCounter += s;
        //Debug.Log(applianceCounter);
        ApplianceDisplayText.text = "Selected appliance " + applianceCounter + "/x";
    }
    public void DecreaseApplianceCounter(int s)
    {
        applianceCounter -= s;  
        //Debug.Log(applianceCounter);
        ApplianceDisplayText.text = "Selected appliance " + applianceCounter + "/x";
    }
}
