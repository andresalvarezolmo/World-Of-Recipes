using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (clicked == false)
        {
            this.gameObject.transform.localPosition = new Vector3(0,1,1);
            this.gameObject.transform.localScale = aumentedScale;
;           clicked = true;
            filter.enabled = true;
            gameManager.hideTexts();

        }
        else
        {
            this.gameObject.transform.localScale = dishScale;
            this.gameObject.transform.localPosition = dishPosition;
            clicked = false;
            filter.enabled = false;
            gameManager.hideTexts();

        }
        //Debug.Log("u clicked" + clicked);
    }
}
