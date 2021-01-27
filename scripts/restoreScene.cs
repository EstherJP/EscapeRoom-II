using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que guarda el estado de la escena para restaurarlo cuando el usuario vuelva
public class restoreScene : MonoBehaviour {
    private GameObject picture;
    private GameObject player;
    private GameObject labyrinthDoor;
    private openDoor drawerScript;
    private GameObject leftDoor;
    private GameObject rightDoor;
    public GameObject labyrinthDoors;
    private GameObject labyrinthInitialDoor;
    private GameObject[] hearts;

    void Start() {
        labyrinthInitialDoor = GameObject.Find("ParedInicialLaberinto");
        hearts = GameObject.FindGameObjectsWithTag("Heart");
        leftDoor = GameObject.Find("PuertaIzquierda");
        rightDoor = GameObject.Find("PuertaDerecha");
        drawerScript = GameObject.Find("CameraPlayer").GetComponent<openDoor>();
        picture = GameObject.Find("Cuadro");
        player = GameObject.Find("Player");
        labyrinthDoor = GameObject.Find("ParedLaberinto");


        // Recuperamos la posición del jugador 
        if (PlayerPrefs.GetInt("reapareceArriba") == 1) 
            player.GetComponent<Transform>().position = new Vector3(48.7f, 21.7f, 1.4f);
        // Recuperamos la posición de la puerta del laberinto
        if (PlayerPrefs.GetFloat("puertaLaberinto") < -1)
            labyrinthDoor.GetComponent<Transform>().position = new Vector3(26.8f, -7f, 13.5f);
        // Recuperamos la posición del cuadro
        if (PlayerPrefs.GetInt("gravedadCuadro") != 0)
            picture.GetComponent<Rigidbody>().useGravity = true;
        else    
            picture.GetComponent<Rigidbody>().useGravity = false;
        // Recuperamos si las puertas del armario están abiertas
        if (PlayerPrefs.GetInt("puertaIzq") == 1)
            leftDoor.GetComponent<Animation>().Play();
        if (PlayerPrefs.GetInt("puertaDcha") == 1)  
            rightDoor.GetComponent<Animation>().Play();
        // Recuperamos las piezas de corazón que hayan sido recolectadas
        if (Mathf.FloorToInt(PlayerPrefs.GetFloat("heart1")) == 11)
            hearts[0].GetComponent<Transform>().position = new Vector3(11.7f, 3.6f, 19.8f);
        if (Mathf.FloorToInt(PlayerPrefs.GetFloat("heart2")) == 12)
            hearts[1].GetComponent<Transform>().position = new Vector3(12.3f, 3.6f, 19.3f);
        if (Mathf.FloorToInt(PlayerPrefs.GetFloat("heart3")) == 12)
            hearts[2].GetComponent<Transform>().position = new Vector3(12.5f, 3.6f, 18.6f);
        if (Mathf.FloorToInt(PlayerPrefs.GetFloat("heart4")) == 13)
            hearts[3].GetComponent<Transform>().position = new Vector3(13.2f, 3.6f, 19.3f);
        if (Mathf.FloorToInt(PlayerPrefs.GetFloat("heart5")) == 13)
            hearts[4].GetComponent<Transform>().position = new Vector3(13.1f, 3.6f, 20.0f);
        // Recuperamos el estado de las paredes del laberinto
        if (Mathf.FloorToInt(PlayerPrefs.GetFloat("paredesLaberinto")) == -10) {
            labyrinthInitialDoor.GetComponent<Animation>().Play();
            labyrinthDoors.GetComponent<Animation>().Play();
        }
    }

    // Método qeu al ser llamado almacena toda la información de la escena
    public void saveSceneState() {
        PlayerPrefs.SetInt("reapareceArriba", 1); // Si el jugado ha subido siempre reaparecerá arriba. No hay más cambios de escena
        PlayerPrefs.SetInt("gravedadCuadro", picture.GetComponent<Rigidbody>().useGravity? 1 : 0);
        PlayerPrefs.SetFloat("puertaLaberinto", labyrinthDoor.GetComponent<Transform>().position.y);
        PlayerPrefs.SetInt("puertaIzq", drawerScript.leftOpen);
        PlayerPrefs.SetInt("puertaDcha", drawerScript.rightOpen);
        PlayerPrefs.SetFloat("heart1", hearts[0].GetComponent<Transform>().position.x);
        PlayerPrefs.SetFloat("heart2", hearts[1].GetComponent<Transform>().position.x);
        PlayerPrefs.SetFloat("heart3", hearts[2].GetComponent<Transform>().position.x);
        PlayerPrefs.SetFloat("heart4", hearts[3].GetComponent<Transform>().position.x);
        PlayerPrefs.SetFloat("heart5", hearts[4].GetComponent<Transform>().position.x);
        PlayerPrefs.SetFloat("paredesLaberinto", labyrinthDoors.GetComponent<Transform>().position.y);
    }
}
