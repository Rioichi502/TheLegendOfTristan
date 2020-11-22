using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public Sprite carta;
    public int precio;
    public int vida;

    void Atacar()
    {
        vida--;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
