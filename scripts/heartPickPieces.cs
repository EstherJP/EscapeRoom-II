using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite recoger trozos del puzzle corazón y colocarlos en la mesa
public class heartPickPieces : MonoBehaviour {
    private RaycastHit hit;
    private Vector3 destination;
    private Vector3 currentPos;
    private Vector3 rotation;
    private float moveSpeed;

    void Start() {
        moveSpeed = 0.5f;
    }

    void FixedUpdate() {
        if (Input.GetButton("A") || Input.GetKeyDown("z")) { // Si el usuario interactúa
            Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
            // Si el usuario está mirando a un trozo de corazón
            if (Physics.Raycast(gameObject.transform.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "Heart") {
                currentPos = hit.collider.transform.position;
                // Comprobamos que trozo es y lo movemos a su lugar destino
                if (hit.collider.gameObject.name == "Corazon 1") {
                    destination = new Vector3(11.7f, 3.6f, 19.8f);
                } else if (hit.collider.gameObject.name == "Corazon 2") {
                    destination = new Vector3(12.3f, 3.6f, 19.3f);
                } else if (hit.collider.gameObject.name == "Corazon 3") {
                    destination = new Vector3(12.5f, 3.6f, 18.6f);
                } else if (hit.collider.gameObject.name == "Corazon 4") {
                    destination = new Vector3(13.2f, 3.6f, 19.3f);
                } else if (hit.collider.gameObject.name == "Corazon 5") {
                    destination = new Vector3(13.1f, 3.6f, 20.0f);
                }

                hit.collider.transform.position = destination;         
            }
        }

    }
}
