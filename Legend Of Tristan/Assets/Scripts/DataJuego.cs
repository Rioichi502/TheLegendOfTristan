using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class DataJuego : MonoBehaviour
{
    public string puntuacionMaxima = "";

    public static DataJuego estadoJuego;

    private String rutaArchivo;

    void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/datos.dat";
        if (estadoJuego == null)
        {
            estadoJuego = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (estadoJuego != this)
        {
            Destroy(gameObject);
        }
    }


    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(rutaArchivo);

        DatosAGuardar datos = new DatosAGuardar();
        datos.puntuacionMaxima = puntuacionMaxima;

        bf.Serialize(file, datos);

        file.Close();
    }

    public void Cargar()
    {
        if (File.Exists(rutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);

            DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);

            puntuacionMaxima = datos.puntuacionMaxima;

            file.Close();
        }
        else
        {
            puntuacionMaxima = "";
        }
    }
}

[Serializable]
class DatosAGuardar
{
    public string puntuacionMaxima;
}
