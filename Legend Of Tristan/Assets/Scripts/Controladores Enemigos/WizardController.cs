﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    public GameObject moneda;

    public int Salud = 350;
    public int TiempoSpawn = 9;
    public int Daño = 5;
    public float Cooldown = 2;
    public float Velocidad = 15;
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
            Quieto = false;
        }
        else
        {
            SistemaSonido.ss.PlayAudioFireball();
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
            Aumentar.contador += 15;
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
