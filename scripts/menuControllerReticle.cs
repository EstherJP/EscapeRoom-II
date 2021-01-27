using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

// Clase que controla la interacción con el menú
public class menuControllerReticle : MonoBehaviour {
    private RaycastHit hit;
    Transform tf;
    public GameObject menu;
    public GameObject controlMenu;
    public GameObject infoMenu;
    public GameObject atrasControl;
    public GameObject atrasInfo;
    public Animator transition;

    void Start() {
      tf = GetComponent<Transform>();
      PlayerPrefs.DeleteAll();
    }

    void FixedUpdate() {
        if (Input.GetButton("A") || Input.GetKey("z")) { // Si el usuario interactúa
            Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
            // Comprobamos si el usuario está mirando al menú
            if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "MenuButton") {
                // dependiendo de la acción realizamos la acción correspondiente. Cargar otra escena o mostrar información
                if (hit.collider.gameObject.name == "ComenzarBoton") {
                    StartCoroutine(loadLevelWithTransition(2));
                 } else if (hit.collider.gameObject.name == "ControlesBoton") {
                     menu.SetActive(false);
                     controlMenu.SetActive(true);
                 } else if (hit.collider.gameObject.name == "InformacionBoton") {
                      menu.SetActive(false);
                      infoMenu.SetActive(true);
                 } else if (hit.collider.gameObject.name == "SalirBoton") {
                      Application.Quit();
                 } else if (hit.collider.gameObject.name == "AtrasTituloCont") {
                      controlMenu.SetActive(false);
                      menu.SetActive(true);
                 } else if (hit.collider.gameObject.name == "AtrasTituloInfo") {
                      menu.SetActive(true);
                      infoMenu.SetActive(false);
                 }
            }
        }
    }

    // Método que permite ejecutar la animación de transición entre escenas
    IEnumerator loadLevelWithTransition(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelIndex);
    }
}
