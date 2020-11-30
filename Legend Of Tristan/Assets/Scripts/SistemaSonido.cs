using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaSonido : MonoBehaviour
{

    public static SistemaSonido ss;
    public AudioSource audioSword;
    public AudioSource levelMusic;
    public AudioSource audioFireball;
    public AudioSource audioPhysical;
    public AudioSource audioArrow;
    public AudioSource audioAxe;

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

    public void PlayAudioSword(){
        audioSword.Play();
    }

     public void PlayAudioFireball(){
        audioFireball.Play();
    }

     public void PlayAudioPhysical(){
        audioPhysical.Play();
    }

     public void PlayAudioArrow(){
        audioArrow.Play();
    }

     public void PlayAudioAxe(){
        audioAxe.Play();
    }

    
}
