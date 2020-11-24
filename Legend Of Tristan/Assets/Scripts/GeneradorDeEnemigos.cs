using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeEnemigos : MonoBehaviour
{
    public int[] segundos;

    public float frecuenciaEnemigos = 10;
    public GameObject Enemigo;

    void Update()
    {   
        for(int i = 0; i< segundos.Length; i++)
        {
            //Invoke("InstanciarEnemigo", segundos[i]);
            InstanciarEnemigo();
        }     
    }

    void InstanciarEnemigo()
    {
        Instantiate(Enemigo, transform.position, Enemigo.transform.rotation);
        Debug.Log("Generando enemigo");
    }
}
