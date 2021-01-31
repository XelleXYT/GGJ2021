using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtenerObjetoABuscar : MonoBehaviour
{
    public string tipoObjetoElegido;
    public string color1ObjetoElegido;
    public string color2ObjetoElegido;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject[] objetosEntregables = GameObject.FindGameObjectsWithTag("ObjetoEntregable");
        int objetoElegido = Random.Range(0, objetosEntregables.Length);
        tipoObjetoElegido = objetosEntregables[objetoElegido].GetComponent<VariablesObjeto>().tipo;
        color1ObjetoElegido = objetosEntregables[objetoElegido].GetComponent<VariablesObjeto>().color1;
        color2ObjetoElegido = objetosEntregables[objetoElegido].GetComponent<VariablesObjeto>().color2;
        Debug.Log(tipoObjetoElegido);
        Debug.Log(color1ObjetoElegido);
        Debug.Log(color2ObjetoElegido);

        string colorParser(string color)
        {
            switch (color)
            {
                case "Rojo":
                    return "red";
                case "Verde":
                    return "green";
                case "Azul":
                    return "blue";
                case "Amarillo":
                    return "yellow";
                case "Morado":
                    return "purple";
                case "Naranja":
                    return "orange";
                case "Negro":
                    return "black";
                case "Blanco":
                    return "white";
                default:
                    return color;
            }
        }

        string color1 = string.Format("<color={1}><b>{0}</b></color>", color1ObjetoElegido, colorParser(color1ObjetoElegido));
        string color2 = string.Format("<color={1}><b>{0}</b></color>", color2ObjetoElegido, colorParser(color2ObjetoElegido));
        GameObject.Find("Text").GetComponent<Text>().text = "Hola, he perdido una <b>" + tipoObjetoElegido + "</b> de color " + color1 + ", también tiene detalles en " + color2 + ".";
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject.Find("Text").GetComponent<Text>().text = "";
    }
}
