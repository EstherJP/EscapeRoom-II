using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla la apertura de las puertas del armario
public class openDoor : MonoBehaviour {
    public GameObject miniDoorR;
    public GameObject miniDoorL;
    public int leftOpen;
    public int rightOpen;
    private RaycastHit hit;
    private Transform tf;

    void Start() {
        tf = GetComponent<Transform>();
    }

    void FixedUpdate() {
        // Si el usuario interactúa
        if (Input.GetButton("A") || Input.GetKeyDown("z")) { 
            Vector3 fwd = tf.TransformDirection(Vector3.forward);
            // Si el usuario está mirando al armario
            if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "Armario") {
                // Comprobamos a que puerta está mirando el usuario y la abrimos
                if (hit.collider.gameObject.name == "PuertaDerecha") {
                    miniDoorR.GetComponent<Animation>().Play();
                    rightOpen = 1;
                } else if (hit.collider.gameObject.name == "PuertaIzquierda") {
                    miniDoorL.GetComponent<Animation>().Play();
                    leftOpen = 1;
                }
            }
        }
    }
}
