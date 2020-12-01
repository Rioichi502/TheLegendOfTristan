using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    public int Salud=150;
    public int Daño=1;
    public float Cooldown=1;
    public float Velocidad=20;
    private bool Quieto=false;

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

    IEnumerator Attack(Collider2D collider)
    {
        if (collider == null)
        {
            Quieto = false;
        }
        else
        {
            try { collider.gameObject.GetComponent<ArcherController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<PersonajesController>().RecibirDaño(Daño); } catch { }
            yield return new WaitForSeconds(Cooldown);
            StartCoroutine(Attack(collider));
        }
    }

    public void RecibirDaño(int daño)
    {
        if (Salud - daño <= 0)
        {
            transform.parent.GetComponent<Spawnpoint>().enemigos.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Salud = Salud - daño;
        }
    }
}
