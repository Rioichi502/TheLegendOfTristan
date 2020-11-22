using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorEscena : MonoBehaviour
{
    public void CambioEscena(string NombreEscena) {
        SceneManager.LoadScene(NombreEscena);
    }
}
