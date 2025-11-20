using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool dragging = false;
    private float distance;

    void OnMouseDown()
    {
        if (!dragging)
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
            Cursor.visible = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            dragging = false;
            Cursor.visible = true;
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}

