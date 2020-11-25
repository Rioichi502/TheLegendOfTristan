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

    public void PlaceObject() {
        if (draggingObject != null  && currentContainer != null) {
            GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.objectGame, currentContainer.transform);
            objectGame.GetComponent<ArqueroController>().enemigos = currentContainer.GetComponent<ObjectContainer>().spawnPoint.enemigos;
            currentContainer.GetComponent<ObjectContainer>().ocupado = true;
        }
    }

}
