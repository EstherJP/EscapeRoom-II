using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que implementa el manejo del puzzle deslizant 
public class PuzzleMovePieces : MonoBehaviour {
    RaycastHit hit;
    Transform tf;
    GameObject[] pieces;
    Vector3[] initialPositions;
    GameObject invisiblePiece;
    Vector3 invisiblePosition;

    // Método que desordena el puzzle realizando movimientos secuenciales
    void shufflePieces() {
      int i = 0;
      while (i < 50) {
        if (isNextToInvisible(pieces[(i % 8)])) {
          movePiece(pieces[(i % 8)]);
        }
        i++;
      }
    }

    void Start() {  // Inicializa las variables y desordena el puzzle
      tf = GetComponent<Transform>();
      initialPositions = new Vector3[8];
      pieces = GameObject.FindGameObjectsWithTag("Piece");
      invisiblePiece = GameObject.Find("InvisiblePiece");

      int i = 0;
      foreach(GameObject obj in pieces) {
        initialPositions[i] = obj.GetComponent<Transform>().position;
        i++;
      }
      invisiblePosition = invisiblePiece.GetComponent<Transform>().position;
      shufflePieces();
    }


    // Método que comprueba si la pieza parámetro está al lado del hueco
    bool isNextToInvisible(GameObject piece) {
      if (Vector3.Distance(piece.GetComponent<Transform>().position , invisiblePosition) < 0.65)
        return true;
      return false;
    }

    // Método que comprueba si el puzzle ha sido resuleto
    bool checkIfCorrect() {
      for (int i = 0; i < 8; i++) {
        if (pieces[i].GetComponent<Transform>().position != initialPositions[i])
          return false;
      }
      invisiblePiece.GetComponent<MeshRenderer>().enabled = true;
      return true;
    }

    // Método que permite mover una pieza al hueco
    void movePiece(GameObject piece) {
      Transform currentTf = piece.GetComponent<Transform>();
      invisiblePiece.GetComponent<Transform>().position = currentTf.position;
      Vector3 auxPos = currentTf.position;
      currentTf.position = invisiblePosition;
      invisiblePosition = auxPos;
    }

    void FixedUpdate() {
      if (Input.GetButton("A") || Input.GetKeyDown("z")) {  // si el usuario interactúa
        Vector3 fwd = tf.TransformDirection(Vector3.forward);
        // Si el usuario está mirando a una pieza
        if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "Piece") {
          // La movemos siemprey cuando sea posible
          if (isNextToInvisible(hit.collider.gameObject)) {
            movePiece(hit.collider.gameObject);
            checkIfCorrect();
          }
        }
      }
    }
}
