using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que controla el puzzle de luces para acceder a la habitación superior
public class openUpStairsDoor : MonoBehaviour {
    // Cogemos el script con el delegado
    private ChangeColorLight scriptColor;
    private bool isOpen;
    public Animator transition;
    public GameObject saveSceneObject;
    private restoreScene saveScene;

    void Start() { 
        scriptColor = GameObject.Find("CameraPlayer").GetComponent<ChangeColorLight>();
        scriptColor.doorEvent += openDoor; // Suscribimos el método al delegado que se lanzará cuando el puzzle sea resuelto
        isOpen = false;
        saveSceneObject = GameObject.Find("RestaurarEscena");
        saveScene = saveSceneObject.GetComponent<restoreScene>();
    }

    // Función indica que la puerta está abierta
    void openDoor() { 
        isOpen = true;
    }

    void OnTriggerEnter(Collider other) {
        if (isOpen) {   // Si el puzzle ha sido resuelto
            // Cambiamos de escena aplicando la transición correspondiente
            saveScene.saveSceneState();
            StartCoroutine(loadLevelWithTransition(3));
        }
    }

    // Función que carga el siguiente nivel con una transición
    IEnumerator loadLevelWithTransition(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelIndex);
    }
}
