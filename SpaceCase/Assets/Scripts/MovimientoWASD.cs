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
    public bool pasosSonando = false;

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
        bool estaCaminando = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
        float velocidadXActual = sePuedeMover ? (estaCorriendo ? velocidadCorrer : velocidadAndar) * Input.GetAxis("Vertical") : 0;
        float velocidadYActual = sePuedeMover ? (estaCorriendo ? velocidadCorrer : velocidadAndar) * Input.GetAxis("Horizontal") : 0;
        float movimientoDireccionY = direccionMovimiento.y;

        if (estaCaminando)
        {

            GameObject[] sonidosPasos = GameObject.FindGameObjectsWithTag("SonidoPaso");
            int sonidoPasosElegido = Random.Range(0, sonidosPasos.Length);
            GameObject pasoAleatorio = sonidosPasos[sonidoPasosElegido];
            if (estaCorriendo)
            {
                GetComponent<AudioSource>().pitch = 3f;
                GetComponent<AudioSource>().volume = .15f;
            } else
            {
                GetComponent<AudioSource>().pitch = 1.25f;
                GetComponent<AudioSource>().volume = .1f;
            }
            if (!pasosSonando)
            {
                pasosSonando = true;
                GetComponent<AudioSource>().clip = pasoAleatorio.GetComponent<AudioSource>().clip;
                GetComponent<AudioSource>().Play();
            }
            if (!GetComponent<AudioSource>().isPlaying)
            {
                pasosSonando = false;
            }
        }

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
