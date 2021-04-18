using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dishPictureScript : MonoBehaviour
{
    private bool clicked = false;
    private Vector3 dishPosition;
    private Vector3 dishScale;

    // Start is called before the first frame update
    void Start()
    {
        dishPosition = this.transform.localPosition;
        dishScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {

        if (clicked == false)
        {
            this.gameObject.transform.localPosition = new Vector3(0,1,1);
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
;            clicked = true;
        }
        else
        {
            this.gameObject.transform.localScale = dishScale;
            this.gameObject.transform.localPosition = dishPosition;
            clicked = false;
        }
        Debug.Log("Ahhhh clickase wey " + clicked);
    }
}
