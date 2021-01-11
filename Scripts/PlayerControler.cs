using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 5;
    public CharacterController controller;
    public Camera mainCamera;
    private Vector3 forward;
    private Vector3 side;

    void Start() {
      controller = gameObject.GetComponent<CharacterController>();
      mainCamera = Camera.main;
    }

    void Update()
    {
      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");
      getCameraOrientation();
      Vector3 movement = horizontalInput * side + verticalInput * forward;
      controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    void getCameraOrientation() {
      forward = mainCamera.transform.forward;
      side = mainCamera.transform.right;
      forward.y = 0f;
      side.y = 0;
    }
}
