using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevisarObjeto : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        string tipoObjetoElegido = GameObject.FindGameObjectWithTag("NPC").GetComponent<ObtenerObjetoABuscar>().tipoObjetoElegido;
        string color1ObjetoElegido = GameObject.FindGameObjectWithTag("NPC").GetComponent<ObtenerObjetoABuscar>().color1ObjetoElegido;
        string color2ObjetoElegido = GameObject.FindGameObjectWithTag("NPC").GetComponent<ObtenerObjetoABuscar>().color2ObjetoElegido;

        // Revisa si el objeto es el que hay que entregar.
        if (collision.gameObject.tag == "ObjetoEntregable")
        {
            VariablesObjeto varObjeto = collision.gameObject.GetComponent<VariablesObjeto>();
            if (varObjeto.tipo == tipoObjetoElegido && varObjeto.color1 == color1ObjetoElegido && varObjeto.color2 == color2ObjetoElegido)
            {
                Debug.Log("Bien");
            }
            else
            {
                Debug.Log("Mal");
            }
            //Debug.Log(collision.gameObject.GetComponent<VariablesObjeto>().color1);
            //Destroy(gameObject);
        }
    }
}
