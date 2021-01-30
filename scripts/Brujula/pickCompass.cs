using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite recoger y dejar el compass es su ubicación
public class pickCompass : MonoBehaviour {
    RaycastHit hit;
    Transform tf;
    public GameObject UICompass;
    public GameObject platformCompass;

    void Start() {
        tf = GetComponent<Transform>();
    }


    void Update() {
        Vector3 fwd = tf.TransformDirection(Vector3.forward);
        // Si el usuario interactúa
        if (Input.GetButton("A") || Input.GetKeyDown("z")) {
            // Si está mirando a la brújula la recoge
            if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.gameObject.name == "BrujulaPlataforma") {
                UICompass.SetActive(true);
                platformCompass.SetActive(false);
            // Si está mirando a la plataforma la coloca
            } else if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.gameObject.name == "plataforma") {
                UICompass.SetActive(false);
                platformCompass.SetActive(true);
            }
        }
    }
}
