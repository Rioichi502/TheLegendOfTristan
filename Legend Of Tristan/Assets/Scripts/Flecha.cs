using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{

    public float Velocidad;
    public int Daño;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Velocidad);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            collider.gameObject.GetComponent<EnemyController>().RecibirDaño(Daño);
            Destroy(this.gameObject);
        }
    }

}
