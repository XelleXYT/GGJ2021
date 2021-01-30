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

    Rigidbody rigidBody;

    private void Start()
    {
        //posicionAnterior = gameObject.transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody>();
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
        if (transform.position.y > 1f)
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        }
        else
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
        GetComponent<AudioSource>().Play(0);
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint = ray.GetPoint(distance);
            rigidBody.velocity = (rayPoint - gameObject.transform.position) * 10;
        }
        else
        {
            isColliding = false;
            posicionAnterior = gameObject.transform.position;
            rotacionAnterior = gameObject.transform.rotation;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
