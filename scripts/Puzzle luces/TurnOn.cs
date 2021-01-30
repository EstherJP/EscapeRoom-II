using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de encender cada una de las luces cuando el interruptor
// general haya sido pulsado
public class TurnOn : MonoBehaviour {
    public Light light;
    private GameObject actuator;
    private string[] colors;
    // Obtenemos el script que contiene el delegado a usar
    private turnAllLights actuatorScript;

    void Start() { 
        colors = new string[] {"red", "blue", "yellow", "green", "magenta", "white", "cyan", "gray"};
        actuator = GameObject.Find("ActuadorGeneral");
        actuatorScript = actuator.GetComponent<turnAllLights>();
        actuatorScript.TurnOnLights += turnOn; // Suscribimos el método al delegado correspondiente
    }

    public Color toColor(string color) {
        return (Color)typeof(Color).GetProperty(color.ToLowerInvariant()).GetValue(null, null);
    }

    // Método que selecciona un color del array y lo asigna a la luz de forma aleatoria
    void turnOn() {
        int random = (int)Mathf.Floor(Random.Range(0f, 7f));
        light.color = toColor(colors[random]);
        light.intensity = 5;
    }
}
