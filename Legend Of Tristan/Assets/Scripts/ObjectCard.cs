using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public int coste;
    public Color colorCoste;
    public Color color;
    public Text textoCoste;
    public GameObject objectDrag;
    public GameObject objectGame;
    private GameObject objectDragInstance;
    public Canvas canvas;
    private GameManager gameManager;

    private void Start() {
        gameManager = GameManager.instance;
    }

    //Cambia el color del texto del coste de las cartas en función de si tienes las monedas suficientes o no
    public void Update() {
        if (Aumentar.contador < coste)
        {
            textoCoste.color = color;
        }
        else {
            textoCoste.color = colorCoste;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        try { objectDragInstance.transform.position = Input.mousePosition; } catch { }
    }

    //Al hacer click sobre la carta genera al personaje para poder arrastrarlo a la casilla deseada
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Aumentar.contador >= coste)
        {
            objectDragInstance = Instantiate(objectDrag, canvas.transform);
            objectDragInstance.transform.position = Input.mousePosition;
            objectDragInstance.GetComponent<ObjectDragging>().card = this;
            gameManager.draggingObject = objectDragInstance;
        }
    }

    //Al soltar el ratón coloca la unidad sobre la casilla y te resta las monedas de su coste
    public void OnPointerUp(PointerEventData eventData)
    {
        if (Aumentar.contador > 0 && Aumentar.contador - coste >= 0)
        {
            gameManager.PlaceObject();
            Aumentar.contador -= coste;
            gameManager.draggingObject = null;
            Destroy(objectDragInstance);
        }
    }
}
