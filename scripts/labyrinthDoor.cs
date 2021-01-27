using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que ejecuta la animación al entrar al laberinto y enciende la luz del personaje
public class labyrinthDoor : MonoBehaviour {
    public GameObject door;
    public Light playerLight;
    private bool animationDone;
    private Animation closeDoor;
    private AudioSource sound;
    private bool alreadyPlaying;

    void Start() {
        closeDoor = door.GetComponent<Animation>();
        animationDone = false;
        sound = door.GetComponent<AudioSource>();
        alreadyPlaying = false;
    }

    void OnTriggerEnter(Collider other) {
        float labyrinthHeartPos = 158.3f; // Posición del corazón dentro del laberinto
        // Comprobamos si el corazón está dentro del laberinto, si la animación NO se ha ejecutado y
        // si las paredes del laberinto no estás bajadas
        if (Mathf.Round(GameObject.Find("Corazon 2").GetComponent<Transform>().position.x) == Mathf.Round(labyrinthHeartPos) && !animationDone &&
                Mathf.FloorToInt(PlayerPrefs.GetFloat("paredesLaberinto")) != -10) {
            // Si estas condiciones se dan, ejecutamos la animación y aumentamos el rango de luz del usuario
            playerLight.range = 30;
            closeDoor.Play();
            animationDone = true;
            alreadyPlaying = true;
            sound.Play();
        }
    }
}

