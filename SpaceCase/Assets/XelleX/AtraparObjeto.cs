using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtraparObjeto : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;


    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        dragging = true;
        if (transform.position.y > 1f) {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        } else
        {
            distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), Camera.main.transform.position);
        }
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            if (rayPoint.y < 0.5f)
            {
                rayPoint.y = transform.position.y;
            }
            transform.position = rayPoint;
        }
    }
}
