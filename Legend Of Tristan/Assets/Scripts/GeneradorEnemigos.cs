using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public List<GameObject> enemigosPrefab;
    public List<Enemigos> enemigos;

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

}
