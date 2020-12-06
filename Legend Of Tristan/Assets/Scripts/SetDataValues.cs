using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDataValues : MonoBehaviour
{
    public Text record;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {        
        if (DataJuego.dataJuego.puntuacionMaxima != null)
        {
            //record.text = "Tu duración máxima en una partida es:   " + DataJuego.dataJuego.puntuacionMaxima;
            record.text = "Tu última duración fue:   " + DataJuego.dataJuego.puntuacionMaxima;
        }
        
    }
}
