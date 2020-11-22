using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arquero : MonoBehaviour
{
    public int precio;
    public float frecuenciaDisparo = 1;
    public GameObject Flecha;//bala || dinero
    public Transform arco;
    public LayerMask layerEnemigo;

    IEnumerator Start()
    {
        while (true) { 
        yield return new WaitForSeconds(frecuenciaDisparo);
        //disparo desde posición inicio a posición final
        RaycastHit2D hit = Physics2D.Raycast(arco.position, Vector3.right*10, layerEnemigo);
        //El numero 10 es la distancia máxima calculada en el mapa hasta donde llegará la flecha
        if (hit.collider != null)
        {
            GameObject g = Instantiate(Flecha, arco.position, Flecha.transform.rotation) as GameObject;
            //tiempo de vida
            Destroy(g, 10);
        }

      }
    }

}
