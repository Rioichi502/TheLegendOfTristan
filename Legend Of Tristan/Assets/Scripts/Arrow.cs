using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    public float Velocidad;

    void Update()
    {
        transform.Translate(new Vector3(Velocidad, 0, 0));
    }
}
