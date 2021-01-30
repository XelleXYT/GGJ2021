using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntregaObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CuboPrueba")
        {
            Debug.Log("Colisión");
            Destroy(gameObject);
        }
        Debug.Log("Colisión");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
