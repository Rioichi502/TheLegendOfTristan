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

    private void Awake() {
        tiempoGoblin = goblin.GetComponent<GoblinController>().TiempoSpawn;
        tiempoOjo = ojo.GetComponent<EyeController>().TiempoSpawn;
        tiempoBrujo = brujo.GetComponent<WizardController>().TiempoSpawn;
        tiempoBs = bs.GetComponent<BSController>().TiempoSpawn;
        tiempoSs = ss.GetComponent<SSController>().TiempoSpawn;
        tiempoDemonio = demonio.GetComponent<DemonController>().TiempoSpawn;
        tiempoSeta = seta.GetComponent<SetaController>().TiempoSpawn;
    }

    private void Update()
    {        
        if (tiempoSpawnGoblin <= Time.timeSinceLevelLoad)
        {
            InvokeRepeating("ReducirtiempoGoblin", 15.0f, 15.0f);
            GameObject intanciaGoblin = Instantiate(goblin, spawnpoints[Random.Range(0,spawnpoints.Length)].transform);
            tiempoSpawnGoblin += tiempoGoblin;
        }
        if (tiempoSpawnOjo <= Time.timeSinceLevelLoad)
        {
            InvokeRepeating("ReducirtiempoOjo", 15.0f, 15.0f);
            GameObject intanciaOjo = Instantiate(ojo, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnOjo += tiempoOjo;
        }
        if (tiempoSpawnBrujo <= Time.timeSinceLevelLoad)
        {
            InvokeRepeating("ReducirtiempoBrujo", 15.0f, 15.0f);
            GameObject intanciaBrujo = Instantiate(brujo, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnBrujo += tiempoBrujo;
        }
        if (tiempoSpawnBs <= Time.timeSinceLevelLoad)
        {
            InvokeRepeating("ReducirtiempoBs", 15.0f, 15.0f);
            GameObject intanciaBs = Instantiate(bs, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnBs += tiempoBs;
        }
        if (tiempoSpawnSs <= Time.timeSinceLevelLoad)
        {
            InvokeRepeating("ReducirtiempoSs", 5.0f, 5.0f);
            GameObject intanciaSs = Instantiate(ss, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnSs += tiempoSs;
        }
        if (tiempoSpawnDemonio <= Time.timeSinceLevelLoad)
        {
            InvokeRepeating("ReducirtiempoDemonio", 5.0f, 5.0f);
            GameObject intanciaDemon = Instantiate(demonio, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnDemonio += tiempoDemonio;
        }

        if (tiempoSpawnSeta <= Time.timeSinceLevelLoad)
        {
            InvokeRepeating("ReducirtiempoSeta", 5.0f, 5.0f);
            GameObject intanciaSeta = Instantiate(seta, spawnpoints[Random.Range(0, spawnpoints.Length)].transform);
            tiempoSpawnSeta += tiempoSeta;
        }
    }

    public void ReducirtiempoGoblin()
    {
        if (tiempoGoblin - 1 != 0) {
            tiempoGoblin -= 1;
        }
    }
    public void ReducirtiempoOjo()
    {
        if (tiempoOjo - 1 != 0)
        {
            tiempoOjo -= 1;
        }
    }
    public void ReducirtiempoBrujo()
    {
        if (tiempoBrujo - 1 != 0)
        {
            tiempoBrujo -= 1;
        }
    }
    public void ReducirtiempoBs()
    {
        if (tiempoBs - 1 != 0)
        {
            tiempoBs -= 1;
        }
    }
    public void ReducirtiempoSs()
    {
        if (tiempoSs - 1 != 0)
        {
            tiempoSs -= 1;
        }
    }
    public void ReducirtiempoDemonio()
    {
        if (tiempoDemonio - 1 != 0)
        {
            tiempoDemonio -= 1;
        }
    }
    public void ReducirtiempoSeta()
    {
        if (tiempoSeta - 1 != 0)
        {
            tiempoSeta -= 1;
        }
    }

}
