using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada del control del movimiento del jugador
public class PlayerControler : MonoBehaviour {
    public float moveSpeed = 7;
    public CharacterController controller;
    public Camera mainCamera;
    private Vector3 forward;
    private float gravity = 9.8f;
    private Vector3 side;
    private Vector3 movement;

    void Start() {
      controller = gameObject.GetComponent<CharacterController>();
      mainCamera = Camera.main;
    }

    void Update() {    
      // Obtenemos las entradas del usuario
      float horizontalInput = Input.GetAxis("Horizontal"); 
      float verticalInput = Input.GetAxis("Vertical");
      // Calculamos el movimiento a realizar
      getCameraOrientation();
      movement = horizontalInput * side + verticalInput * forward;
      movement = movement * moveSpeed;
      setGravity();
      controller.Move(movement * Time.deltaTime); // Realizamos el movimiento
    }

    void setGravity() {
        movement.y = -gravity;
    }

    void getCameraOrientation() {
      // Obtenemos la orientación de la cámara para realizar el movimiento conforme a esta
      forward = mainCamera.transform.forward;
      side = mainCamera.transform.right;
      forward.y = 0f;
      side.y = 0;
    }
}
