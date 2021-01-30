using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que enciende todas las luces al pulsar el interruptor general
public class turnAllLights : MonoBehaviour {
    // Cosas de la retícula
    RaycastHit hit;
    Transform tf;
    private GameObject player;
    private bool lightsOff;
    // Delegado y evento delegado
    public delegate void delegateMethod();
    public event delegateMethod TurnOnLights;


    void Start() { 
        player = GameObject.Find("CameraPlayer");
        tf = player.GetComponent<Transform>();
        lightsOff = true;
    }

    void FixedUpdate() {
        // Si el usuario interactúa
        if (Input.GetButton("A") || Input.GetKeyDown("z")) {
            Vector3 fwd = tf.TransformDirection(Vector3.forward);
            // Si el usuario está mirando
            if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.gameObject.name == "ActuadorGeneral" && lightsOff) {
                // Lanzamos un delegado de que el botón ha sido pulsado
                TurnOnLights();
                lightsOff = false;
            }
        }
    }
}
