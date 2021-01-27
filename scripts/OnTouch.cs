using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Clase que permite que el cuadro del puzzle caiga al suelo
public class OnTouch : MonoBehaviour {
    private Rigidbody rb;
    bool inside;

    void Start() {
        inside = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("A") || Input.GetKeyDown("z")) { // Si el usuario interactúa activamos la gravedad
            rb.useGravity = true;
        }
    }

    public void isInside() {
      inside = true;
    }

    public void isOutside() {
      inside = false;
    }
}
