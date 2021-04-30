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

    public GameObject submitButton;

    public GameObject gameOverScreenCorrect;
    public GameObject gameOverScreenWrong;
    public GameObject gameCompleted;

    //levelmanager
    public string nextLevel;

    // Start is called before the first frame update
    public void Start()
    {
        
        correctIngredients = IngredientHolder.transform.childCount;
        Ingredients = new GameObject[correctIngredients];
        for(int i = 0; i < Ingredients.Length; i++)
        {
            Ingredients[i] = IngredientHolder.transform.GetChild(i).gameObject;
            //Debug.Log(IngredientHolder.transform.GetChild(i).gameObject);
        }

        correctAppliances = ApplianceHolder.transform.childCount;
        Appliances = new GameObject[correctAppliances];
        for (int j = 0; j < Appliances.Length; j++)
        {
            Appliances[j] = ApplianceHolder.transform.GetChild(j).gameObject;
            //Debug.Log(ApplianceHolder.transform.GetChild(j).gameObject);
        }

    }

    public void checkAmountofIngredients()
    {
        Image imgButton = submitButton.GetComponent<Image>();
        if (ingredientCounter == correctIngredients && applianceCounter == correctAppliances)
        {
            //Debug.Log("User can submit");
            //submitButton.color = new Color(255, 255, 255, 255);
            imgButton.color = Color.green;
        }
        else
        {
            //Debug.Log("User can not submit");
            //submitButton.color = new Color(255, 0, 0, 255);
            imgButton.color = Color.red;
        }
    }

    public void checkSolution()
    {
        if(ingredientCounter == correctIngredients && applianceCounter == correctAppliances)
        {
            if (userCorrectIngredients == correctIngredients && userCorrectAppliances == correctAppliances)
            {
                Debug.Log("Congratulations, correct solution");
                if (int.Parse(nextLevel) > int.Parse(encryptScript.EncryptDecrypt(PlayerPrefs.GetString("LevelReached"),200)))
                {
                    PlayerPrefs.SetString("LevelReached", encryptScript.EncryptDecrypt(nextLevel,200));
                    Debug.Log("Next level unlocked");
                }
                else
                {
                    Debug.Log("Next level had already been unlocked");
                }

                if(int.Parse(encryptScript.EncryptDecrypt(PlayerPrefs.GetString("LevelReached"),200)) == 6) gameCompleted.SetActive(true);

                else gameOverScreenCorrect.SetActive(true);
            }
            else
            {
                Debug.Log("Incorrect solution, please try again");
                Debug.Log("ingredientCounter" + ingredientCounter);
                Debug.Log("applianceCounter" + applianceCounter);
                gameOverScreenWrong.SetActive(true);
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
        //Debug.Log("Correct ingredient selected. Amount: " + userCorrectIngredients);
        checkAmountofIngredients();
    }
    public void unSelectedCorrectIngredient()
    {
        userCorrectIngredients--;
        //Debug.Log("Correct ingredient unselected. Amount: " + userCorrectIngredients);
        checkAmountofIngredients();
    }

    public void selectedCorrectAppliance()
    {
        userCorrectAppliances++;
        //Debug.Log("Correct Appliance selected. Amount: " + userCorrectAppliances);
        checkAmountofIngredients();
    }

    public void unSelectedCorrectAppliance()
    {
        userCorrectAppliances--;
        //Debug.Log("Correct Appliance unselected. Amount: " + userCorrectAppliances);
        checkAmountofIngredients();
    }

    public void RaiseIngredientCounter(int s)
    {
        ingredientCounter += s;
        //Debug.Log(ingredientCounter);
        IngredientDisplayText.text = "Selected ingredients " + ingredientCounter + "/"  + correctIngredients;
        checkAmountofIngredients();
    }
    public void DecreaseIngredientCounter(int s)
    {
        ingredientCounter -= s;
        //Debug.Log(ingredientCounter);
        IngredientDisplayText.text = "Selected ingredients " + ingredientCounter + "/" + correctIngredients;
        checkAmountofIngredients();
    }

    public void RaiseApplianceCounter(int s)
    {
        applianceCounter += s;
        //Debug.Log(applianceCounter);
        ApplianceDisplayText.text = "Selected appliance " + applianceCounter + "/" + correctAppliances;
        checkAmountofIngredients();
    }
    public void DecreaseApplianceCounter(int s)
    {
        applianceCounter -= s;
        //Debug.Log(applianceCounter);
        ApplianceDisplayText.text = "Selected appliance " + applianceCounter + "/" + correctAppliances;
        checkAmountofIngredients();
    }

}
