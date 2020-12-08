using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject draggingObject;
    public GameObject currentContainer;

    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    //Método para poder desplegar la unidad en la casilla sobre la que estamos poniendo el ratón
    public void PlaceObject() {
        if (draggingObject != null && currentContainer != null)
        {
            GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.objectGame, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().ocupado = true;
        }
    }

}
