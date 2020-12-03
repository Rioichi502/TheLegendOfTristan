﻿using System.Collections;
using System.Collections.Generic;
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
                //Debug.Log(timer.text);
                DataJuego data = new DataJuego();
                data.puntuacionMaxima = timer.text;
                //bien guardado
                Debug.Log(data.puntuacionMaxima);
                MenuUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }         
}
