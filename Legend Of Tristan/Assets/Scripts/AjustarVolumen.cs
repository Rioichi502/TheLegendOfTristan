using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AjustarVolumen : MonoBehaviour
{

    public AudioMixer audioMixer;
    public GameObject MenuUI;

    public void Volumen(float volumen) {
        audioMixer.SetFloat("volumen", volumen);
    }

    public void setFullScreen(bool FullScreen) {
        Screen.fullScreen = FullScreen;
    }

    public void ResumeGame() {
        MenuUI.SetActive(false);
        Time.timeScale = 1;
    }

}
