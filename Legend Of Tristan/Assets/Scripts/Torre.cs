using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public int precio;
    public float frecuenciaDisparo = 1;
    public GameObject bala;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(frecuenciaDisparo);
            GameObject g =Instantiate(bala, transform.position +Vector3.up *Random.Range(0f,1f)+Vector3.left*Random.Range(-1f,1f), bala.transform.rotation);
            //tiempo de vida
            Destroy(g, 10);
        }
    }


    void Update()
    {
        
    }
}
