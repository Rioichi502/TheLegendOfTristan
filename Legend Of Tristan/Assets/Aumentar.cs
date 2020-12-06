using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aumentar : MonoBehaviour
{

    public static int contador = 0;
    public Text texto;

    public void Start() {
        texto = GetComponent<Text>();
    }

    public void Update() {
        texto.text=contador.ToString();
    }

}
