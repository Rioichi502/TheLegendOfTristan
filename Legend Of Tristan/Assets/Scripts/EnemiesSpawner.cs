using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{

    public List<GameObject> enemigosPrefab;
    public List<Enemigos> enemigos;
    private float tiempoSpawn;

    private void Update()
    {
        Debug.Log(Time.time);
        foreach (Enemigos enemigo in enemigos)
        {
            if (enemigo.SpawnTime <= Time.time)
            {
                enemigo.SpawnTime += enemigo.SpawnTime;
                if (enemigo.RandomSpawn) {
                    enemigo.Spawner = Random.Range(0, transform.childCount);
                }
                GameObject InstanciaEnemigo = Instantiate(enemigosPrefab[(int)enemigo.tipoEnemigo], transform.GetChild(enemigo.Spawner).transform);
                transform.GetChild(enemigo.Spawner).GetComponent<Spawnpoint>().enemigos.Add(InstanciaEnemigo);
                enemigo.isSpawned = true;
            }
        }
    }
}
//if (Time.time > nextSpawn)
//           {
//               nextSpawn = Time.time + enemigo.SpawnTime;