﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    public void SalirJuego() {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}
