using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que ejecuta la animación final del laberinto
public class labyrinthHideWalls : MonoBehaviour  {
    private RaycastHit hit;
    public GameObject walls;
    public GameObject initialDoor;
    private Animation anim;
    private AudioSource sound;
    private bool alreadyPlaying;
    public Light playerLight;

    void Start() {
        anim = walls.GetComponent<Animation>();
        sound = walls.GetComponent<AudioSource>();
        alreadyPlaying = false;
    }

    void FixedUpdate() {
        Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
        // Comprobamos que el usuario esté mirando al armario final del laberinto y que la animación no se haya ejecutado ya
        if (Physics.Raycast(gameObject.transform.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "aramarioLab" && !alreadyPlaying &&
                Mathf.FloorToInt(PlayerPrefs.GetFloat("paredesLaberinto")) != -10) {
            // Ejecutamos la animación y apagamos la luz
            alreadyPlaying = true;
            anim.Play();
            sound.Play();
            attenuateLight();
        }
    }

    void attenuateLight() {
        // Apagamos progresivamente la luz del usuario
        playerLight.range = playerLight.range - 1;
        if (playerLight.range > 0)
            this.Invoke("attenuateLight", 1.0f);
    }

}
