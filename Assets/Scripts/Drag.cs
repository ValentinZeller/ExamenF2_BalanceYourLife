using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    float startPosX;
    float startPosY;
    bool isBeingHeld = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            if (mousePos.y > GameObject.Find("BalancePad").transform.position.y)
            {
                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
            }

            
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);

            isBeingHeld = true;
            tag = "Drag";

        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
        tag = "Untagged";
    }

}
