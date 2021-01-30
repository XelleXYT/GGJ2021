using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoWASD : MonoBehaviour
{
    public float velocidadAndar = 7.5f;
    public float velocidadCorrer = 11.5f;
    public float velocidaSalto = 8.0f;
    public float gravedad = 20.0f;
    public Camera camaraJugador;
    public float velocidadCamara = 2.0f;
    public float limiteCamaraX = 45.0f;

    CharacterController controladorPersonaje;
    Vector3 direccionMovimiento = Vector3.zero;
    float rotacionX = 0;

    [HideInInspector]
    public bool sePuedeMover = true;

    void Start()
    {
        controladorPersonaje = GetComponent<CharacterController>();

        // Bloqueo de cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Activar sprint
        bool estaCorriendo = Input.GetKey(KeyCode.LeftShift);
        float velocidadXActual = sePuedeMover ? (estaCorriendo ? velocidadCorrer : velocidadAndar) * Input.GetAxis("Vertical") : 0;
        float velocidadYActual = sePuedeMover ? (estaCorriendo ? velocidadCorrer : velocidadAndar) * Input.GetAxis("Horizontal") : 0;
        float movimientoDireccionY = direccionMovimiento.y;
        direccionMovimiento = (forward * velocidadXActual) + (right * velocidadYActual);

        if (Input.GetButton("Jump") && sePuedeMover && controladorPersonaje.isGrounded)
        {
            direccionMovimiento.y = velocidaSalto;
        }
        else
        {
            direccionMovimiento.y = movimientoDireccionY;
        }

        if (!controladorPersonaje.isGrounded)
        {
            direccionMovimiento.y -= gravedad * Time.deltaTime;
        }

        // Movimiento del personaje
        controladorPersonaje.Move(direccionMovimiento * Time.deltaTime);

        // Rotación del personaje y la cámara
        if (sePuedeMover)
        {
            rotacionX += -Input.GetAxis("Mouse Y") * velocidadCamara;
            rotacionX = Mathf.Clamp(rotacionX, -limiteCamaraX, limiteCamaraX);
            camaraJugador.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * velocidadCamara, 0);
        }
    }
}
