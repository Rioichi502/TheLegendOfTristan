﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandidoController : MonoBehaviour
{

    public int Salud=7;
    public int Daño=50;
    public float Cooldown=0.5f;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            StartCoroutine(Attack(collider));
        }
    }

    IEnumerator Attack(Collider2D collider) { 
        if (collider == null){
            
        }
        else {
            SistemaSonido.ss.PlayAudioSword();
            try { collider.gameObject.GetComponent<GoblinController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<WizardController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<EyeController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<SetaController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<BSController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<SSController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<DemonController>().RecibirDaño(Daño); } catch { }
            yield return new WaitForSeconds(Cooldown);
            StartCoroutine(Attack(collider));
        }     
    }

    public void RecibirDaño(int daño) {
        if (Salud-daño <= 0) {
            Destroy(this.gameObject);
        }
        else
        {
            Salud = Salud - daño;
        } 
    }



}