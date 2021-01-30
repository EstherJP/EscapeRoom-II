using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite el cambio de música al entrar al laberinto
public class playLabyrinthMusic : MonoBehaviour {
    public GameObject objectWithSounds;
    private AudioSource[] sounds;

    void Start() {
        sounds = objectWithSounds.GetComponents<AudioSource>();
    }

    void OnTriggerEnter() {
        // Si entra al laberinto cambiamos la música
        if (sounds[0].isPlaying) {
            sounds[0].Stop();
            sounds[1].Play();
        } else {    // Si sale del laberinto vuelve a cambiar la música
            sounds[1].Stop();
            sounds[0].Play(); 
        }
    }
}
