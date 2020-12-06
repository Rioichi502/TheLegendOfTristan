using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{

    public float Velocidad;
    public int Daño;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Velocidad);
    }

}
