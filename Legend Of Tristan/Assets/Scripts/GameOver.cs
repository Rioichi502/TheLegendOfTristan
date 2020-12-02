using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public int Salud=4;
    public GameObject MenuUI;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {          
            Destroy(collider.gameObject);
            Salud -= 1;
            animator.SetInteger("Salud", Salud);
            if (Salud == 0)
            {
                MenuUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }         
}
