using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public int velocidad=10;
    public int daño=1;

    void Update()
    {
        //movimiento de la flecha a la derecha
        transform.position += Vector3.right * velocidad * Time.deltaTime;
    }
}
