using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public bool dragging = false;
    private float distance;

    public GameObject EggArrow;
    public GameObject TreeArrow;
    public GameObject PotArrow;

    void OnMouseDown()
    {
        if (!dragging) //pickup
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
            Cursor.visible = false;
            EggArrow.SetActive(false);
            TreeArrow.SetActive(true);
        }
        else //drop
        {
            dragging = false;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3 (rayPoint.x, rayPoint.y ,transform.position.z);
        }
    }
}

