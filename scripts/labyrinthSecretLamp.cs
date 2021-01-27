using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que ejecuta la animación de apertura de la puerta secreta
public class labyrinthSecretLamp : MonoBehaviour {
    private Transform tf;
    private RaycastHit hit;
    public GameObject door;
    public GameObject lamp;
    private Animation anim;
    private Animation lampAnim;
    private AudioSource[] sounds;
    private bool doorUp;

    void Start() {
        tf = GetComponent<Transform>();
        anim = door.GetComponent<Animation>();
        sounds = door.GetComponents<AudioSource>();
        lampAnim = lamp.GetComponent<Animation>();
        doorUp = true;
    }

    void dummy() {
        sounds[1].Play();
    }
    void FixedUpdate() {
        if (Input.GetButton("A") || Input.GetKeyDown("z")) {    // Si el usuario interactúa
            Vector3 fwd = tf.TransformDirection(Vector3.forward);
            // Si el usuario está mirando a la lámpara
            if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "secretLamp" && doorUp) {
                // Ejecutamos la animación y los sonidos correspondientes
                doorUp = false;
                lampAnim.Play();
                anim.Play();
                sounds[0].Play();
                this.Invoke("dummy", 5.0f);
            }
        }
    }
}
