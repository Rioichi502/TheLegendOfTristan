using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text textoTimer;
    private float StartTime;

    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - StartTime;
        string minutos = ((int)t / 60).ToString();
        string segundos = (t % 60).ToString("f1");
        textoTimer.text = minutos + ":" + segundos;
    }
}
