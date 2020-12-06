using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoController : MonoBehaviour
{

    public int Salud=10;
    public int Daño=100;
    public float Cooldown=1;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            animator.SetBool("Luchando", true);
            StartCoroutine(Attack(collider));
        }
    }

    IEnumerator Attack(Collider2D collider) { 
        if (collider == null){
            animator.SetBool("Luchando", false);
        }
        else {
            SistemaSonido.ss.PlayAudioSmite();
            try { collider.gameObject.GetComponent<GoblinController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<WizardController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<EyeController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<SetaController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<BSController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<SSController>().RecibirDaño(Daño); } catch { }
            try { collider.gameObject.GetComponent<DemonController>().RecibirDaño(Daño); } catch { }
            yield return new WaitForSeconds(Cooldown);
            StartCoroutine(Attack(collider));
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
