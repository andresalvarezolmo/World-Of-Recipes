using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script that takes care of the dishPicture, which if it is clicked it gets bigger and moved to the centre of the screen
public class dishPictureScript : MonoBehaviour
{
    private bool clicked = false;
    private Vector3 dishPosition;
    private Vector3 dishScale;
    private Vector3 aumentedScale;
    public SpriteRenderer filter;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //store initial position of the picture
        dishPosition = this.transform.localPosition;
        dishScale = this.transform.localScale;
        aumentedScale = 3 * dishScale;
    }
    private void Awake()
    {
        gameManager = GameObject.Find("Scripter").GetComponent<GameManager>();

    }

    public void OnMouseDown()
    {
        //if image is clicked and it was not clicked before it gets bigger and moved to the center of the screen
        if (clicked == false)
        {
            this.gameObject.transform.localPosition = new Vector3(0,1,1);
            this.gameObject.transform.localScale = aumentedScale;
;           clicked = true;
            filter.enabled = true;
            gameManager.hideTexts();

        }
        //if image had already been clicked, then move it to its original position
        else
        {
            this.gameObject.transform.localScale = dishScale;
            this.gameObject.transform.localPosition = dishPosition;
            clicked = false;
            filter.enabled = false;
            gameManager.hideTexts();

        }
    }
}
