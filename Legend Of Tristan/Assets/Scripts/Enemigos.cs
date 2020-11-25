using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Enemigos 
{

    public int SpawnTime;
    public TipoEnemigo tipoEnemigo;
    public int Spawner;
    public bool RandomSpawn;
    public bool isSpawned;

}

public enum TipoEnemigo { 
    Goblin,
    Brujo,
    Demonio,
    EsqueletoGrande,
    EsqueletoPequeño,
    Seta,
    OjoVolador
}
