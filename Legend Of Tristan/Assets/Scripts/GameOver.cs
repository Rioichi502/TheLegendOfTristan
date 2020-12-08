using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public int Salud=4;
    public GameObject MenuUI;
    public Slider barraSalud;
    public Text timer;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Al colisonar un enemigo con la tienda de campaña, éste se destruye y 
    //Dla tienda pierde salud hasta quedar a 0 y hacer aparecer el panel y guadar el tu tiempo de juego
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {          
            Destroy(collider.gameObject);
            Salud -= 1;
            barraSalud.value = Salud;
            animator.SetInteger("Salud", Salud);
            if (Salud == 0)
            {
                DataJuego.dataJuego.puntuacionMaxima = timer.text;
                DataJuego.dataJuego.Guardar();
                MenuUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }         
}
