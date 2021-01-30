using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que activa los muros deslizantes del laberinto
public class labyrinthGhostWalls : MonoBehaviour {   
    public GameObject door;

    void OnTriggerEnter(Collider other) {
        door.SetActive(true); // Al interactuar con el trigger se activa la puerta
    }
}
