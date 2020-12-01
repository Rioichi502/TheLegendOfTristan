using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{

    public int Salud=7;
    public GameObject flecha;
    public List<GameObject> enemigos;
    public float Cooldown=1.5f;
    private float attackTime;
    public int Daño=50;
    private bool atacando;

    public void Update() {
        if (enemigos.Count > 0 && atacando == false)
        {
            atacando = true;
        }
        else if (enemigos.Count == 0 && atacando == true) {
            atacando = false;
        }
        if (atacando == true ) {
            if(attackTime <= Time.time) {
                SistemaSonido.ss.PlayAudioArrow();
                GameObject flechaInstance= Instantiate(flecha, transform);
                flechaInstance.GetComponent<Flecha>().Daño = Daño;
                attackTime = Time.time + Cooldown;
            }
        }
    }

    public void RecibirDaño(int daño)
    {
        if (Salud - daño <= 0)
        {          
            Destroy(this.gameObject);
        }
        else
        {
            Salud = Salud - daño;
        }
    }

}
