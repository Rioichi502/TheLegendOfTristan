using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : MonoBehaviour
{
    public GameObject moneda;

    public int Salud = 750;
    public int TiempoSpawn = 16;
    public int Daño = 4;
    public float Cooldown = 2;
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
            SistemaSonido.ss.PlayAudioAxe();
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
            animator.SetInteger("Salud", 0);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("death"))
            {
                Instantiate(moneda, this.transform);
                moneda.transform.parent = null;
                Destroy(this.gameObject);
            }
        }
        else
        {
            Salud = Salud - daño;
        }
    }

}
