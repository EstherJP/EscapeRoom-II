using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideWalls : MonoBehaviour
{
    private RaycastHit hit;
    public GameObject walls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(gameObject.transform.position, fwd, out hit, Mathf.Infinity) && hit.collider.tag == "Wall") {
            Debug.Log("Estoy mirando al armario");
            walls.SetActive(false);
        }
    }
}
