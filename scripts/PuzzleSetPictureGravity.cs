using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Clase que permite que el cuadro del puzzle caiga al suelo
public class PuzzleSetPictureGravity : MonoBehaviour {
    public GameObject picture;
    private Rigidbody rb;
    RaycastHit hit;
    Transform tf;
    bool inside;

    void Start()
    {
        inside = false;
        rb = picture.GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    void Update() {
        Vector3 fwd = tf.TransformDirection(Vector3.forward);
        // Si el usuario interactúa y está mirando al cuadro, activamos la gravedad para que caiga
        if ((Input.GetButton("A") || Input.GetKeyDown("z")) && Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.gameObject.name == "MarcoSecreto") { 
            rb.useGravity = true;
        }
    }
}
