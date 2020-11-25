using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int Salud;
    public int Daño;
    public float Velocidad;
    private bool Quieto;
    
    void Update()
    {
        if (!Quieto)
        {
            transform.Translate(new Vector3(Velocidad * -1, 0, 0));
        }
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 10) {
            Quieto = true;
        }
    }

}
