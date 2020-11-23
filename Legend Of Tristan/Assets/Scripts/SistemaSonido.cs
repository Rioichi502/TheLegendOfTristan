using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaSonido : MonoBehaviour
{

    public static SistemaSonido ss;
    public AudioSource audioKingAtack;
    public AudioSource levelMusic;

    void Awake() {
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

    public void PlayLevelMusic(){
        levelMusic.Play();
    }

    public void PlayKingAtack(){
        audioKingAtack.Play();
    }

    
}
