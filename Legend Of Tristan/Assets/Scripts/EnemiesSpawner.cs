using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{

    public Transform[] spawnpoints;

    public GameObject goblin;
    private float tiempoSpawnGoblin = 5;
    private int tiempoGoblin;

    public GameObject ojo;
    private float tiempoSpawnOjo = 6;
    private int tiempoOjo;

    public GameObject brujo;
    private float tiempoSpawnBrujo = 8;
    private int tiempoBrujo;

    public GameObject bs;
    private float tiempoSpawnBs = 9;
    private int tiempoBs;

    public GameObject ss;
    private float tiempoSpawnSs = 11;
    private int tiempoSs;

    public GameObject demonio;
    private float tiempoSpawnDemonio = 15;
    private int tiempoDemonio;

    public GameObject seta;
    private float tiempoSpawnSeta = 10;
    private int tiempoSeta;

    private void Update()
    {
        if ((int)Time.timeSinceLevelLoad % 30 == 0) {
            if (goblin.GetComponent<GoblinController>().TiempoSpawn - 1 != 0)
            {
                tiempoGoblin = goblin.GetComponent<GoblinController>().TiempoSpawn - 1;
            }
            if (goblin.GetComponent<GoblinController>().TiempoSpawn - 1 != 0)
            {
                tiempoOjo = ojo.GetComponent<EyeController>().TiempoSpawn - 1;
            }
            if (goblin.GetComponent<GoblinController>().TiempoSpawn - 1 != 0)
            {
                tiempoBrujo = brujo.GetComponent<WizardController>().TiempoSpawn - 1;
            }
            if (goblin.GetComponent<GoblinController>().TiempoSpawn - 1 != 0)
            {
                tiempoBs = bs.GetComponent<BSController>().TiempoSpawn - 1;
            }
            if (goblin.GetComponent<GoblinController>().TiempoSpawn - 1 != 0)
            {
                tiempoSs = ss.GetComponent<SSController>().TiempoSpawn - 1;
            }
            if (goblin.GetComponent<GoblinController>().TiempoSpawn - 1 != 0)
            {
                tiempoDemonio = demonio.GetComponent<DemonController>().TiempoSpawn - 1;
            }
            if (goblin.GetComponent<GoblinController>().TiempoSpawn - 1 != 0)
            {
                tiempoSeta = seta.GetComponent<SetaController>().TiempoSpawn - 1;
            }
        }
        if (tiempoSpawnGoblin <= Time.timeSinceLevelLoad)
        {
            GameObject intanciaGoblin = Instantiate(goblin, spawnpoints[Random.Range(0,spawnpoints.Length)].transform);
            tiempoSpawnGoblin = Time.timeSinceLevelLoad + tiempoGoblin;
        }

        if (tiempoSpawnOjo <= Time.timeSinceLevelLoad)
        {
            GameObject intanciaOjo = Instantiate(ojo, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnOjo = Time.timeSinceLevelLoad + tiempoOjo;
        }

        if (tiempoSpawnBrujo <= Time.timeSinceLevelLoad)
        {
            GameObject intanciaBrujo = Instantiate(brujo, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnBrujo = Time.timeSinceLevelLoad + tiempoBrujo;
        }

        if (tiempoSpawnBs <= Time.timeSinceLevelLoad)
        {
            GameObject intanciaBs = Instantiate(bs, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnBs = Time.timeSinceLevelLoad + tiempoBs;
        }

        if (tiempoSpawnSs <= Time.timeSinceLevelLoad)
        {
            GameObject intanciaSs = Instantiate(ss, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnSs = Time.timeSinceLevelLoad + tiempoSs;
        }

        if (tiempoSpawnDemonio <= Time.timeSinceLevelLoad)
        {
            GameObject intanciaDemon = Instantiate(demonio, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnDemonio = Time.timeSinceLevelLoad + tiempoDemonio;
        }

        if (tiempoSpawnSeta <= Time.timeSinceLevelLoad)
        {
            GameObject intanciaSeta = Instantiate(seta, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnSeta = Time.timeSinceLevelLoad + tiempoSeta;
        }
    }

}
