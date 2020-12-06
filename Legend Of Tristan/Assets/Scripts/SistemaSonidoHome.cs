using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaSonidoHome : MonoBehaviour
{
    public static SistemaSonidoHome ss;
    public AudioSource homeMusic;

    void Awake() {
        //datos al iniciar
        DataJuego.dataJuego.Cargar();
        if (ss == null)
        {
            ss = this;
        }else if(ss != this){
            Destroy (gameObject);
        }
    }

    void OnDestroy(){
        ss = null;
    }

    public void PlayHomeMusic(){
        homeMusic.Play();
    }
}
