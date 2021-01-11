using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class menuControllerReticle : MonoBehaviour {
    private RaycastHit hit;
    Transform tf;
    public GameObject menu;
    public GameObject controlMenu;
    public GameObject infoMenu;
    public GameObject atrasControl;
    public GameObject atrasInfo;

    void Start() {
      tf = GetComponent<Transform>();
    }

    void FixedUpdate() {
        if (Input.GetButton("A")) { // el boton A
            Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "MenuButton") {
                if (hit.collider.gameObject.name == "ComenzarBoton") {
                    SceneManager.LoadScene(sceneBuildIndex:2);
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
}
