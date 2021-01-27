using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que maneja la transición de escena al entrar al segundo cuarto

public class upDoorOpen : MonoBehaviour
{
    public Animator transition;

    void OnTriggerEnter(Collider other) {
        StartCoroutine(loadLevelWithTransition(1));
    }

    IEnumerator loadLevelWithTransition(int levelIndex) {
        transition.SetTrigger("Start"); // Iniciamos animación para la transición
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelIndex); // Cargamos la nueva escena
    }
}
