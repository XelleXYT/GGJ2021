using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruyeColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        // Calcula si quedan objetos
        if(GameObject.FindGameObjectsWithTag("ObjetoEntregable") == null)
        {
            Debug.Log("Fin");
            // Cambia a escena final
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        // Calcula si quedan objetos


   }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("ObjetoEntregable").Length == 0)
        {
            Debug.Log("Fin");
            // Cambia a escena final
        }
    }
}
