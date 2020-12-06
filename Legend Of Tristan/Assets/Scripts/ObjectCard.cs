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

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Aumentar.contador > 0 && Aumentar.contador - coste >= 0)
        {
            gameManager.PlaceObject();
            gameManager.draggingObject = null;
            Destroy(objectDragInstance);
            Aumentar.contador -= coste;
        }
    }

}
