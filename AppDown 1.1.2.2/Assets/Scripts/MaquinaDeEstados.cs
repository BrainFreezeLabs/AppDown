using UnityEngine;
using System.Collections;

public class MaquinaDeEstados : MonoBehaviour
{
    public static int estado = 0;
    public enum estados
    {
        menuPrincipal,
        inicioTiempoPerroHabla,
        vacaHabla,
        inicioTiempoVacaHabla,
        perroHabla,
        randomizandoPosicionBotones,
        UIrespuesta,
    };

    
}
