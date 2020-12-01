using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajesController : MonoBehaviour
{

    public int Salud;
    public int Daño;
    public float Cooldown;

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
            //collider.gameObject.GetComponent<EnemyController>().RecibirDaño(Daño);
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
