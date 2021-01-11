using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragObject : MonoBehaviour
{
    private RaycastHit hit;
    private Vector3 destination;
    private Vector3 currentPos;
    private Vector3 rotation;
    private float moveSpeed;
    // private Rigidbody rb;

    void Start() {
        // currentPos = transform.position;
        // destination = new Vector3(0, 0, 0); // posicion por defecto
        moveSpeed = 0.5f;
        // rotation = new Vector3(-90f, 0, 133.695f); (-0.7, 0.3, 0.3, 0.7)
        // rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("A") || Input.GetKeyDown("z")) {
            Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(gameObject.transform.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "Heart") {
                // Debug.Log("hit collider " + hit.collider.tag);
                // Debug.Log("estoy mirando un cacho de corazon al corazon " + hit.collider.gameObject.name);
                currentPos = hit.collider.transform.position;
                if (hit.collider.gameObject.name == "Corazon 1") {
                    destination = new Vector3(13.2f, 3.8f, 9.6f);
                } else if (hit.collider.gameObject.name == "Corazon 2") {
                    destination = new Vector3(12.4f, 3.8f, 8.9f);
                } else if (hit.collider.gameObject.name == "Corazon 3") {
                    destination = new Vector3(11.5f, 3.8f, 8.7f);
                } else if (hit.collider.gameObject.name == "Corazon 4") {
                    destination = new Vector3(12.5f, 3.8f, 7.8f);
                } else if (hit.collider.gameObject.name == "Corazon 5") {
                    destination = new Vector3(13.5f, 3.8f, 7.8f);
                }

                // Vector3 smoothedDelta = Vector3.MoveTowards(currentPos, destination, Time.fixedDeltaTime * moveSpeed);
                // hit.collider.GetComponent<Rigidbody>().MovePosition(currentPos + destination * Time.fixedDeltaTime * moveSpeed);
                Debug.Log(hit.collider.gameObject.name + ": ");
                Debug.Log("Pos actual: ");
                Debug.Log(currentPos);
                hit.collider.transform.position = destination;
                // hit.collider.transform.rotation = rotation;
                Debug.Log("rotacion: ");
                Debug.Log(hit.collider.transform.rotation);
                Debug.Log("Se tiene que mover a: ");
                Debug.Log(destination);
                Debug.Log(" y se ha movido a ");
                Debug.Log(hit.collider.transform.position);
                Debug.Log("-----------");
            }
        }

    }
}
