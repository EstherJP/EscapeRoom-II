﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase encargada de gestionar la espera y el cambio de escena de 
// el video mostrado en la introducción
public class wait : MonoBehaviour {

    // Tiempo a esperar. En esta caso la duración del vídeo
    public float waitTime = 24f;
    public int numberScene = 0;
    public Animator transition;

    void Start() {
        StartCoroutine(WaitForIntro());  
    }

    IEnumerator WaitForIntro() {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(loadLevelWithTransition(1));
    }

    IEnumerator loadLevelWithTransition(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelIndex);
    }
}
