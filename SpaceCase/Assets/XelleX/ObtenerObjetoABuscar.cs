using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerObjetoABuscar : MonoBehaviour
{
    public string tipoObjetoElegido;
    public string color1ObjetoElegido;
    public string color2ObjetoElegido;
    void Start()
    {
        GameObject[] objetosEntregables = GameObject.FindGameObjectsWithTag("ObjetoEntregable");
        int objetoElegido = Random.Range(0, objetosEntregables.Length);
        tipoObjetoElegido = objetosEntregables[objetoElegido].GetComponent<VariablesObjeto>().tipo;
        color1ObjetoElegido = objetosEntregables[objetoElegido].GetComponent<VariablesObjeto>().color1;
        color2ObjetoElegido = objetosEntregables[objetoElegido].GetComponent<VariablesObjeto>().color2;
        Debug.Log(tipoObjetoElegido);
        Debug.Log(color1ObjetoElegido);
        Debug.Log(color2ObjetoElegido);

    }
}
