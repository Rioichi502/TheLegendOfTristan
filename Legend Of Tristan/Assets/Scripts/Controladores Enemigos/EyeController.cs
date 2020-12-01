using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{

    public int Salud = 200;
    public int TiempoSpawn = 3;
    public int Daño = 2;
    public float Cooldown = 1;
    public float Velocidad = 20;
    private bool Quieto = false;
    public ArcherController arquero;

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

        if (collider.gameObject.layer == 12)
        {
            RecibirDaño(arquero.Daño);
            Destroy(collider.gameObject);
        }

    }

    IEnumerator Attack(Collider2D collider) {
        if (collider == null){
            Quieto = false;
        }
        else {
            try { collider.gameObject.GetComponent<ArcherController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<BandidoController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<ReyController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<CaballeroController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<MagoController>().RecibirDaño(Daño); } catch { }
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
