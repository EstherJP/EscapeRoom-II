using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnTouch : MonoBehaviour
{
    private Rigidbody rb;
    bool inside;

    void Start()
    {
        inside = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("A")) { // Cambiarlo a algo mapeable en mando
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
