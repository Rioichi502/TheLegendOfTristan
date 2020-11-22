using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpciones : MonoBehaviour
{

    public GameObject MenuUI;

   public void Opciones()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0;
    }
}
