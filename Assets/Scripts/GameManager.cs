using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script used in order to manage the flow of the game
public class GameManager : MonoBehaviour
{
    //objects that store the ingredients and appliances
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
    
    //Level complete screens
    public GameObject gameOverScreenCorrect;
    public GameObject gameOverScreenWrong;
    public GameObject gameCompleted;

    public GameObject AIButton;

    //levelmanager
    public string nextLevel;

    int randomSelectedIngredient;
    int hintsLeft = 1;
    public Text HintsText;
    public Text Instructions;

    //Sounds effects
    public AudioSource wrongSolution;
    public AudioSource correctSolution;
    public AudioSource gameFinished;

    //Set up variables that keep track of the current state of game
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
        Debug.Log(encryptScript.EncryptDecrypt(PlayerPrefs.GetString("LevelReached"), 200));

    }
    //coroutine created to generate a delay when the AI button highlights one ingredient in green so 3 seconds later it goes back to its regular color
    IEnumerator ExampleCoroutine(GameObject myObject)
    {
        yield return new WaitForSeconds(3);
        myObject.GetComponent<Renderer>().material.color = Color.white;
    }

    //method that changes the color of the button once the provided solution matches the requirements
    public void checkAmountofIngredients()
    {
        Image imgButton = submitButton.GetComponent<Image>();
        if (ingredientCounter == correctIngredients && applianceCounter == correctAppliances)
        {
            imgButton.color = Color.green;
        }
        else
        {
            imgButton.color = Color.red;
        }
    }

    //checks if the solution is correct or not
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

                if (int.Parse(encryptScript.EncryptDecrypt(PlayerPrefs.GetString("LevelReached"), 200)) == 6)
                {
                    gameCompleted.SetActive(true);
                    gameFinished.Play();
                }

                else
                {
                    gameOverScreenCorrect.SetActive(true);
                    correctSolution.Play();
                }
            }
            else
            {
                Debug.Log("Incorrect solution, please try again");
                Debug.Log("ingredientCounter" + ingredientCounter);
                Debug.Log("applianceCounter" + applianceCounter);
                gameOverScreenWrong.SetActive(true);
                wrongSolution.Play();
                wrongSolution.Play();
            }
        }
        else
        {
            Debug.Log("Solution does not meet the requirements");
        }

    }
    //select one random from the list and highlight for a few seconds
    public void AIMethod()
    {
        if(hintsLeft > 0)
        {
            randomSelectedIngredient = Random.Range(0, Ingredients.Length);
            //Debug.Log(randomSelectedIngredient);
            Ingredients[randomSelectedIngredient].GetComponent<Renderer>().material.color = Color.green;
            StartCoroutine(ExampleCoroutine(Ingredients[randomSelectedIngredient]));
            hintsLeft--;
            updateHintsText();
        }
        
    }

    //updates the text that announces the number of hints left
    public void updateHintsText()
    {
        HintsText.text = "Hints left:" + hintsLeft;
        if (hintsLeft < 1) HintsText.color = Color.red;
    }
    //hides elements so the image picture is not covered when moved to center
    public void hideTexts()
    {
        if (HintsText.gameObject.activeSelf) HintsText.gameObject.SetActive(false);
        else HintsText.gameObject.SetActive(true);
        if (AIButton.activeSelf) AIButton.SetActive(false);
        else AIButton.SetActive(true);
        if (Instructions.gameObject.activeSelf) Instructions.gameObject.SetActive(false);
        else Instructions.gameObject.SetActive(true);
    }

    //all this methods below keep track of the selected and unselected ingredients and appliances

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
