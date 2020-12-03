using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDataValues : MonoBehaviour
{
    public TextMesh record;

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
        if (DataJuego.estadoJuego != null)
        {
            record.text = "RECORD: " + DataJuego.estadoJuego.puntuacionMaxima.ToString();
        }
        
    }
}
