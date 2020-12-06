using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{

    public int Salud=7;
    public GameObject flecha;
    public List<GameObject> enemigos;
    public float Cooldown=1.0f;
    private float attackTime;
    public int Daño=50;
    private bool atacando;
    public GameObject arco;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Update() {
        animator.SetBool("Luchando", true);
        if (attackTime <= Time.time)
        {           
            SistemaSonido.ss.PlayAudioArrow();
            GameObject flechaInstance = Instantiate(flecha, arco.transform);
            flechaInstance.GetComponent<Flecha>().Daño = Daño;
            attackTime = Time.time + Cooldown;
        }
    }

    public void RecibirDaño(int daño)
    {
        if (Salud - daño <= 0)
        {
            animator.SetInteger("Salud", 0);
            GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponentInParent<ObjectContainer>().ocupado = false;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("death"))
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Salud = Salud - daño;
        }
    }

}
