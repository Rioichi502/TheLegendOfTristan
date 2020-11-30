using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{

    public int Salud;
    public GameObject flecha;
    public List<GameObject> enemigos;
    public float Cooldown;
    private float attackTime;
    public int Daño;
    public bool atacando;
    public GameObject objetivo;
    public int daño;

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
                GameObject flechaInstance= Instantiate(flecha, transform);
                flechaInstance.GetComponent<Flecha>().Daño = daño;
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
