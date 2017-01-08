using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

public class CapturaNombre : MaquinaDeEstados {
   
    //variable para almacenar el texto que el jugador ingrese en el IputField del juego (nombreJugador)
    [SerializeField]
    public Text nombre;

    //string que almacena el nombre del jugador ingresado en "public text nombre"
    //de forma estatica para poderla accesar desde los demas scripts
    public static string nombreJugador;

    [HideInInspector]
    //public static string nombre;

    void Awake()
    {
        BaseDeDatos.inicializar();
        BaseDeDatos.splittear();
       
    }

    
	public void GuardarNombre()
    {
        nombreJugador = nombre.text;

        if (File.Exists(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador))
        {
            //Debug.Log("Ahuevo si lo lei");
            Master.VecesJugadas = File.ReadAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador);
            int.TryParse(Master.VecesJugadas, out Master.VecesJugadasint);
            Master.LecturaDeVecesCorrectas();
                Master.InteligenciaArtificial.DiagnosticarJugador();
                Master.vecesCorrectas = 0;

        }
        
        else
        {
            //Debug.Log("No mames no lei nada");
            Master.VecesJugadas = "0";
            int.TryParse(Master.VecesJugadas, out Master.VecesJugadasint);
            Master.vecesCorrectasS = "0";
            int.TryParse(Master.vecesCorrectasS, out Master.vecesCorrectas);
            Master.InteligenciaArtificial.DiagnosticarJugador();
        }
        estado = (int)estados.inicioTiempoPerroHabla;
    }
}
