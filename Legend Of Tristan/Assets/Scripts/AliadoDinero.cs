using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliadoDinero : MonoBehaviour
{
    public int precio;
    public float frecuenciaDisparo = 1;
    public GameObject coin;//bala || dinero

    IEnumerator Start()
    {
        while (true)
        {
            //genera monedas
            yield return new WaitForSeconds(frecuenciaDisparo);
            GameObject g =Instantiate(coin, transform.position +Vector3.up *Random.Range(0f,1f)+Vector3.left*Random.Range(-1f,1f), coin.transform.rotation);
            //tiempo de vida
            Destroy(g, 10);
        }
    }


    void Update()
    {
        
    }
}
