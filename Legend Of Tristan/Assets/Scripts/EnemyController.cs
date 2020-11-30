using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int Salud;
    public int Daño;
    public float Cooldown;
    public float Velocidad;
    private bool Quieto;

    void Update()
    {
        if (!Quieto)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Velocidad);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 10)
        {
            StartCoroutine(Attack(collider));
            Quieto = true;
        }
    }

    IEnumerator Attack(Collider2D collider) {
        if (collider == null){
            Quieto = false;
        }
        else {
            try { collider.gameObject.GetComponent<ArcherController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<PersonajesController>().RecibirDaño(Daño); } catch { }
            yield return new WaitForSeconds(Cooldown);
            StartCoroutine(Attack(collider));
        }     
    }

    public void RecibirDaño(int daño) {
        if (Salud-daño <= 0) {
            transform.parent.GetComponent<Spawnpoint>().enemigos.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Salud = Salud - daño;
        } 
    }



}
