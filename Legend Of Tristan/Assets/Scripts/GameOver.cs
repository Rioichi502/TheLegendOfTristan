using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public int Salud;
    public GameObject MenuUI;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        { 
            Destroy(collider.gameObject);
        Salud -= 1;
        if (Salud == 0)
        {
            MenuUI.SetActive(true);
            Time.timeScale = 0;
        }
        }
    }         
}
