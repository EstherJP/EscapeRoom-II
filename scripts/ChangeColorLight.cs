﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite cambiar los colores de las luces al usar el interruptro
public class ChangeColorLight : MonoBehaviour {
    public Light northLight;
    public Light eastLight;
    public Light westLight;
    public Light southLight;
    private string[] colors;
    private int[] indexes;
    RaycastHit hit;
    Transform tf;
    public delegate void delegateMethod();
    public event delegateMethod doorEvent;


    void Start() { 
        // Inicialización de los arrays correpondientes de colores e índices
        colors = new string[] {"red", "blue", "yellow", "green", "magenta", "white", "cyan", "gray"};
        indexes = new int[] {0, 0, 0, 0};
        tf = GetComponent<Transform>();
    }

    public Color toColor(string color) {
        // Obtención del objeto color a partir de una cadena
        return (Color)typeof(Color).GetProperty(color.ToLowerInvariant()).GetValue(null, null);
    }

    void FixedUpdate() {  
        if (Input.GetButton("A") || Input.GetKeyDown("z")) {  // Si el usuario interactúa
            Vector3 fwd = tf.TransformDirection(Vector3.forward);
            if (Physics.Raycast(tf.position, fwd, out hit, Mathf.Infinity) && hit.collider.gameObject.name == "Actuador") {
                // Buscamos qué interruptor es y cambiamos su luz corespondiente
                if (hit.collider.tag == "Norte") {
                    northLight.color = toColor(colors[(indexes[0] % 8)]);
                    indexes[0]++;
                } else if (hit.collider.tag == "Sur") {
                    southLight.color = toColor(colors[(indexes[1] % 8)]);
                    indexes[1]++;
                } else if (hit.collider.tag == "Este") {
                    eastLight.color = toColor(colors[(indexes[2] % 8)]);
                    indexes[2]++;
                } else if (hit.collider.tag == "Oeste") {
                    westLight.color = toColor(colors[(indexes[3] % 8)]);
                    indexes[3]++;
                }
                // Comprobación para saber si el código de colores es correcto
                if (northLight.color == Color.red && southLight.color == Color.green && 
                        eastLight.color == Color.cyan && westLight.color == Color.yellow) {
                    doorEvent(); // Disparamos evento correspondiente a la resolución del puzzle
                }
            } 
        }
    }
}
