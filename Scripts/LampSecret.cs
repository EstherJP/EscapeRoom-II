using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSecret : MonoBehaviour
{
    private Transform tf;
    private RaycastHit hit;
    public GameObject door;
    private Animation anim;
    private AudioSource[] sounds;

    void Start() {
        tf = GetComponent<Transform>();
        anim = door.GetComponent<Animation>();
        sounds = door.GetComponents<AudioSource>();
    }

    void dummy() {
        sounds[1].Play();
    }
    void FixedUpdate() {
        if (Input.GetButton("A") || Input.GetKeyDown("z")) {
            Vector3 fwd = tf.TransformDirection(Vector3.forward);
            if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "secretLamp") {
                anim.Play();
                sounds[0].Play();
                this.Invoke("dummy", 5.0f);
            }
        }
    }
}
