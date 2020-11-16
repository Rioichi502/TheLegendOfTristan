using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public List<Torre> torres;

    public GameObject Mazo;
    public GameObject Boton;

    public Text txtDinero;

    int dinero = 100;

    void Start()
    {
        actualizarDinero(0);
        for (int i = 0; i< torres.Count; i++)
        {
            GameObject crear = Instantiate(Boton) as GameObject;
            crear.transform.SetParent(Mazo.transform);
            crear.transform.position = Vector3.zero;
        }
    }

    public void actualizarDinero(int suma)
    {
        dinero += suma;
        txtDinero.text = dinero.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);
            if(hit.collider != null)
            {
                Transform tr = hit.collider.transform;
                if (tr.childCount == 0)
                {
                    GameObject g = Instantiate(torres[0].gameObject, tr.position, gameObject.transform.rotation) as GameObject;
                    g.transform.SetParent(tr);
                }
            }
        }
    }

    void crearTorre(int num, Transform tr)
    {
        if (torres[num].precio > dinero)
            return;
        if (tr.childCount != 0)
            return;

        GameObject g = Instantiate(torres[0].gameObject, tr.position, gameObject.transform.rotation) as GameObject;
        g.transform.SetParent(tr);

        actualizarDinero(- torres[0].precio);
    }
}
