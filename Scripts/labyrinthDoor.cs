using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labyrinthDoor : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Vector3 labyrinthPosition = new Vector3(158.3f, 2.6f, 20.8f);
        if (Mathf.Round(GameObject.Find("Corazon2").GetComponent<Transform>().position.x) == Mathf.Round(labyrinthPosition.x)) {
            door.SetActive(true);
        } else {
            door.SetActive(false);
        }
    }
}

