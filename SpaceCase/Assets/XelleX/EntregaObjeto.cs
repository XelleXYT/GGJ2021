using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntregaObjeto : MonoBehaviour
{
    // Cuando el objeto colisiona
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CuboPrueba")
        {
            Debug.Log("Colisión");
            Destroy(gameObject);
        }
        Debug.Log("Colisión");
    }
}
