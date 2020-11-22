using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida=5;
    public int velocidad=1;
    public LayerMask layerPersonajes;
    public float frecuenciaDeAtaque=1f;
    public float frecuencia = 0;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, .5f, layerPersonajes);
        //contacto del enemigo con aliado
        if (hit.collider != null)
        {
            frecuencia += Time.deltaTime;
            if (frecuencia >= frecuenciaDeAtaque)
            {
                //reinicio
                frecuencia = 0;
                hit.collider.SendMessage("Atacar");
            }
            else {
                frecuencia = 0;
                transform.position -= Vector3.right * velocidad * Time.deltaTime;
            }
        }
    }



    //si colisiona con flecha se resta 1 de vida
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Flecha"))
        {
            vida--;
            Destroy(col.gameObject);

            //si no tiene vida muere
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
