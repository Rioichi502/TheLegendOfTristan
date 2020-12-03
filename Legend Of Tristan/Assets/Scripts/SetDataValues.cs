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
        DataJuego data = new DataJuego();
        //aqui da null
        Debug.Log(data);
        Debug.Log(data.puntuacionMaxima);
        if (data != null)
        {
            record.text = "RECORD: " + data.puntuacionMaxima.ToString();
        }
        
    }
}
