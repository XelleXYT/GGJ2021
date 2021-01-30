using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtraparObjeto : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    public bool isColliding;
    Vector3 posicionAnterior;
    Quaternion rotacionAnterior;

    private void Start()
    {
        //posicionAnterior = gameObject.transform.position;
    }

    void reDisable()
    {
        GetComponent<Rigidbody>().useGravity = false;
        dragging = false;
    }

    void reEnable()
    {
        GetComponent<Rigidbody>().useGravity = true;
        dragging = true;
    }

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

    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
        if (dragging)
        {
            reDisable();
            Invoke("reEnable", 0.1f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

    /*
    private void OnCollisionStay(Collision collision)
    {
        isColliding = true;
    }
    */

    void Update()
    {
        if (posicionAnterior == null)
        {
            posicionAnterior = gameObject.transform.position;
        }

        if (rotacionAnterior == null)
        {
            rotacionAnterior = gameObject.transform.rotation;
        }

        if (dragging)
        {
            //posicionAnterior = gameObject.transform.position;
            //transform.position = posicionAnterior;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            rayPoint = ray.GetPoint(distance);
            if (rayPoint.y < 0.5f)
            {
                rayPoint.y = transform.position.y;
            }

            transform.position = Vector3.Lerp(transform.position, rayPoint, 1);
            Debug.Log(isColliding);

            if ( isColliding )
            {
                //Debug.Log("Chocando");
                transform.position = posicionAnterior;
                transform.rotation = rotacionAnterior;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            else
            {
                posicionAnterior = transform.position;
                rotacionAnterior = transform.rotation;
            }


            // calcular posicion actual es legal o ilegal // posicion anterior y posicion actual
            // true: guardar posicion anterior = actual

            // calcular posicion actual

            // mover objeto a posicion anterior
        }
        else
        {
            isColliding = false;
            posicionAnterior = gameObject.transform.position;
            rotacionAnterior = gameObject.transform.rotation;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = true;
        }

        /*
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            
            if (!isColliding)
            {

                rayPoint = ray.GetPoint(distance);
                if (rayPoint.y < 0.5f)
                {
                    rayPoint.y = transform.position.y;
                }
            }
            
            transform.position = rayPoint;
        }
        */
    }
}
