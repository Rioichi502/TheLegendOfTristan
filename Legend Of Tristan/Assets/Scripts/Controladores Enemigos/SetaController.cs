﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaController : MonoBehaviour
{
    public GameObject moneda;

    public int Salud = 500;
    public int TiempoSpawn = 11;
    public int Daño = 1;
    public float Cooldown = 1;
    public float Velocidad = 10;
    private bool Quieto = false;
    public ArcherController arquero;

    Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

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
            animator.SetBool("Luchando", true);
            StartCoroutine(Attack(collider));
            Quieto = true;
        }

        if (collider.gameObject.layer == 12)
        {
            RecibirDaño(arquero.Daño);
            Destroy(collider.gameObject);
        }

    }

    IEnumerator Attack(Collider2D collider)
    {
        if (collider == null)
        {
            animator.SetBool("Luchando", false);
            Quieto = false;
        }
        else
        {
            SistemaSonido.ss.PlayAudioPhysical();
            try { collider.gameObject.GetComponent<ArcherController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<BandidoController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<ReyController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<CaballeroController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<MagoController>().RecibirDaño(Daño); } catch { }
            yield return new WaitForSeconds(Cooldown);
            StartCoroutine(Attack(collider));
        }
    }

    public void RecibirDaño(int daño)
    {
        if (Salud - daño <= 0)
        {
            Aumentar.contador += 10;
            animator.SetInteger("Salud", 0);
            Quieto = true;
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
