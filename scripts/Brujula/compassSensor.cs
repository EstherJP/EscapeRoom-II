using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Clase que nos permite obtener los datos para manejar la brújula
public class compassSensor : MonoBehaviour {

	float lastData = 0;

	void Start()	{
		Input.location.Start();
		Input.compass.enabled = true;
	}

	void Update()	{
		float currentPosition = Mathf.Round(Input.compass.trueHeading);

		// Obtenemos la información del sensor y movemos la aguja de la brújula 
		if (Mathf.Abs(lastData - currentPosition) > 1) {
			transform.RotateAround(transform.position, transform.forward, (lastData - currentPosition));
			lastData = currentPosition;
		}
	}
}
