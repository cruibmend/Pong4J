using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porteria : MonoBehaviour
{
    //Si la bola atraviesa la porteria
    void OnTriggerEnter2D(Collider2D Bola) {

    if (Bola.name == "Bola"){
        Bola.GetComponent<Bola>().reiniciarBola();
    }
  }
}
