using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevisarObjeto : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        string tipoObjetoElegido = GameObject.Find("TriggerSearch").GetComponent<ObtenerObjetoABuscar>().tipoObjetoElegido;
        string color1ObjetoElegido = GameObject.Find("TriggerSearch").GetComponent<ObtenerObjetoABuscar>().color1ObjetoElegido;
        string color2ObjetoElegido = GameObject.Find("TriggerSearch").GetComponent<ObtenerObjetoABuscar>().color2ObjetoElegido;

        // Revisa si el objeto es el que hay que entregar.
        if (collision.gameObject.tag == "ObjetoEntregable")
        {
            VariablesObjeto varObjeto = collision.gameObject.GetComponent<VariablesObjeto>();
            if (varObjeto.tipo == tipoObjetoElegido && varObjeto.color1 == color1ObjetoElegido && varObjeto.color2 == color2ObjetoElegido)
            {
                Debug.Log("Bien");
                // Destruir objeto entregado
                Destroy(collision.gameObject);

                // Reproducir sonido de entregado correctamente
                GameObject.Find("AlertaOK").GetComponent<AudioSource>().Play();

                // ExitNPC
                GameObject.FindGameObjectWithTag("NPC").GetComponent<Animator>().SetTrigger("ExitNPC");
            }
            else
            {
                Debug.Log("Mal");
                // Destruir objeto entregado
                //Destroy(collision.gameObject);

                // Reproducir sonido de objeto incorrecto
                GameObject.Find("AlertaError").GetComponent<AudioSource>().Play();
            }
            //Debug.Log(collision.gameObject.GetComponent<VariablesObjeto>().color1);
            //Destroy(gameObject);
        }
    }
}
