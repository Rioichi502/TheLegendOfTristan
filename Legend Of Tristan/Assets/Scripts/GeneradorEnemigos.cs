using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{

<<<<<<< HEAD
    private void Update()
    {
        foreach (Enemigos enemigo in enemigos) {
            if (enemigo.isSpawned == false && enemigo.SpawnTime <= Time.time) {
                GameObject InstanciaEnemigo= Instantiate(enemigosPrefab[(int)enemigo.tipoEnemigo], transform.GetChild(enemigo.Spawner).transform);
                transform.GetChild(enemigo.Spawner).GetComponent<SpawnPoint>().enemigos.Add(InstanciaEnemigo); 
                enemigo.isSpawned = true;

            }
        }
    }
=======
    public List<Enemigos> enemigos;
>>>>>>> parent of f951bc9... Colisiones

}
