using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObj : MonoBehaviour
{
    private float startPosY;
    private bool isBeingHeld = false;

    public Transform cloud;

    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            rb.velocity = (mousePos - cloud.position) * 50;
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
