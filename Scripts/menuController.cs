using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    void Start() {}
    void Update() {}

    public void clickComenzar() {
      SceneManager.LoadScene(sceneBuildIndex:2);
    }

    public void clickSalir() {
      Debug.Log("Saliendo");
      Application.Quit();
    }
}
