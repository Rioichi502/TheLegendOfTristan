using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoController : MonoBehaviour
{

    public int Salud=10;
    public int Daño=100;
    public float Cooldown=1;
    public GameObject lapida;
    public GameObject pies;
    private Vector3 posicion;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        posicion = new Vector3(pies.transform.position.x, pies.transform.position.y, pies.transform.position.z);
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
            SistemaSonido.ss.PlayAudioSword();
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

    public void RecibirDaño(int daño) {
        if (Salud-daño <= 0) {
            animator.SetInteger("Salud", 0);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("death"))
            {
                Instantiate(lapida, posicion, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Salud = Salud - daño;
        } 
    }



}
