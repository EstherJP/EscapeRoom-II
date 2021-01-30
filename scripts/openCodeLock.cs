using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de reconocer cuando la clave correcta es introducida
public class openCodeLock : MonoBehaviour {
    private RaycastHit hit;
    private Transform tf;
    private string correctCodeString;
    private Animation openAnim;
    public GameObject cerrojo;

    void Start() {
        tf = GetComponent<Transform>();
        correctCodeString = "";
        openAnim = cerrojo.GetComponent<Animation>();
        openAnim.Stop();
    }


    void FixedUpdate() {
        if (Input.GetButton("A") || Input.GetKeyDown("z")) { // Si el usuario interactúa con el candado
            Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
            // Si el usuario está mirando al candado
            if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "Candado") {
                // Añadimos a la cadena resultado el botón al cual esté mirando
                if (hit.collider.gameObject.name == "Boton 0") {
                    correctCodeString += "0";
                } else if (hit.collider.gameObject.name == "Boton 1") {
                    correctCodeString += "1";
                } else if (hit.collider.gameObject.name == "Boton 2") {
                    correctCodeString += "2";
                } else if (hit.collider.gameObject.name == "Boton 3") {
                    correctCodeString += "3";
                } else if (hit.collider.gameObject.name == "Boton 4") {
                    correctCodeString += "4";
                } else if (hit.collider.gameObject.name == "Boton 5") {
                    correctCodeString += "5";
                } else if (hit.collider.gameObject.name == "Boton 6") {
                    correctCodeString += "6";
                } else if (hit.collider.gameObject.name == "Boton 7") {
                    correctCodeString += "7";
                } else if (hit.collider.gameObject.name == "Boton 8") {
                    correctCodeString += "8";
                } else if (hit.collider.gameObject.name == "Boton 9") {
                    correctCodeString += "9";
                }

                // Comprobamos que la cadena introducida sea correcta
                if (correctCodeString.Length == 4) {
                    if (correctCodeString == "7883") {
                        openAnim.Play();
                        Debug.Log("HAS SALIDA");
                    } else {
                        Debug.Log("Prueba otra vez bro");
                        correctCodeString = "";
                    }
                }
            }
        }
    }
}
