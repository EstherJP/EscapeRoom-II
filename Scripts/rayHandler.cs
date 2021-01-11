using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayHandler : MonoBehaviour
{
    RaycastHit hit;
    Transform tf;
    GameObject[] pieces;
    Vector3[] initialPositions;
    GameObject invisiblePiece;
    Vector3 invisiblePosition;

    void shufflePieces() {
      int i = 0;
      while (i < 50) {
        if (isNextToInvisible(pieces[(i % 8)])) {
          movePiece(pieces[(i % 8)]);
        }
        i++;
      }
    }

    void Start() {
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


    bool isNextToInvisible(GameObject piece) {
      if (Vector3.Distance(piece.GetComponent<Transform>().position , invisiblePosition) < 0.65)
        return true;
      return false;
    }

    bool checkIfCorrect() {
      for (int i = 0; i < 8; i++) {
        if (pieces[i].GetComponent<Transform>().position != initialPositions[i])
          return false;
      }
      invisiblePiece.GetComponent<MeshRenderer>().enabled = true;
      return true;
    }

    void movePiece(GameObject piece) {
      Transform currentTf = piece.GetComponent<Transform>();
      invisiblePiece.GetComponent<Transform>().position = currentTf.position;
      Vector3 auxPos = currentTf.position;
      currentTf.position = invisiblePosition;
      invisiblePosition = auxPos;
    }

    void FixedUpdate() {
      if (Input.GetButton("A")) {
        Vector3 fwd = tf.TransformDirection(Vector3.forward);
        if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "Piece") {
          if (isNextToInvisible(hit.collider.gameObject)) {
            movePiece(hit.collider.gameObject);
            checkIfCorrect();
          }
        }
      }
    }
}
