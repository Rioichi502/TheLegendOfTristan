using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectContainer : MonoBehaviour
{

    public bool ocupado;
    public GameManager gameManager;
    public Image backgroundImage;
    public Spawnpoint spawnpoint;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    //Verifica sobré que casilla estás arrastrando el personaje
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (gameManager.draggingObject != null && ocupado == false)
            {
                gameManager.currentContainer = this.gameObject;
                backgroundImage.enabled = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        gameManager.currentContainer = null;
        backgroundImage.enabled = false;
    }
}
