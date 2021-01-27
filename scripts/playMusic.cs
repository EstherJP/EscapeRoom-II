using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que reproduce la música del menú
public class playMusic : MonoBehaviour
{
    void Start() {
        AudioSource audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
}
