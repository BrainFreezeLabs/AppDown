using UnityEngine;
using System.Collections;

public class TextoEnGUI : MonoBehaviour {

    Master master;

    /// <summary>
    /// variables de BotonesCorrectoIncorrecto
    /// </summary>

    //variables para probar las posiciones, alto y ancho del boton Correcto
    //float botonCorrectoXPos = Screen.width / 2 + 100;
    //float botonCorrectoYpos = Screen.height / 2;
    public float botonCorrectoWidth;
    public float botonCorrectoHeight;

    //variables para probar las posiciones, alto y ancho del boton Incorrecto
    //float botonIncorrectoXPos = Screen.width / 2 - 200;
    //float botonIncorrectoYpos = Screen.height / 2;
    public float botonIncorrectoWidth;
    public float botonIncorrectoHeight;

    //Salvando el valor de la respuesta
    static public string respuesta;
    static public string[] salvandoPalabra = new string[80];
    static public int iteradorPalabra = 0;
    //banderas para la activacion del canvas
    public bool botonPrecionado;

    void Awake()
    {   
        master = GetComponent<Master>();
        
    }

    void OnGUI()
    {
        GUI_Information();
        HUD_Vaca_Perro();
    }

    void GUI_Information()
    {
        GUI.Label(new Rect(0, 0, 1000, 100), "Tiempo de pregunta " + Master.pmilitrans);
        GUI.Label(new Rect(0, 10, 1000, 100), "Numero de ensayo " + Master.VecesJugadas);
        GUI.Label(new Rect(0, 20, 1000, 100), "Numero de pregunta " + Master.NumeroDeEnsayos);
        GUI.Label(new Rect(0, 30, 1000, 100), "Veces que perro habla " + Master.VecesQuePerroHabla);
        GUI.Label(new Rect(0, 40, 1000, 100), "Veces que vaca habla " + Master.VecesQueVacaHabla);
        GUI.Label(new Rect(0, 50, 1000, 100), "Respuestas correctas " + Master.vecesCorrectas);
        GUI.Label(new Rect(0, 60, 1000, 100), "Respuestas Incorrectas " + Master.vecesErroneas);
        GUI.Label(new Rect(0, 70, 1000, 100), "Respuestas NO Contestadas " + Master.ensayosNoContestados);
    }

    void HUD_Vaca_Perro()
    {
        if (!Master.InteligenciaArtificial.jugadorDiagnosticado)
        {
            if (master.perroHabla)
            {   
                //TODO cambiar: cuando hable perro escalarlo y reproducir audio de la palabra
                GUI.Button(new Rect(50, 200, 200, 50), Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraPerro]);
                salvandoPalabra[iteradorPalabra] = Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraPerro];
                iteradorPalabra++;
            }
            else if (master.vacaHabla)
            {   
                //TODO cambiar: cuando hable vaca escalarla y reproducir audio de la palabra
                GUI.Button(new Rect(550, 200, 200, 50), Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraVaca]);
                salvandoPalabra[iteradorPalabra] = Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraVaca];
                iteradorPalabra++;
            }
        }
        else
        { 
            if (Master.InteligenciaArtificial.jugadorMalo)
            {
                if (master.perroHabla)
                {
                    GUI.Button(new Rect(50, 200, 200, 50), Master.InteligenciaArtificial.malo[Master.InteligenciaArtificial.contadorPalabraPerro]);
                    salvandoPalabra[iteradorPalabra] = Master.InteligenciaArtificial.malo[Master.InteligenciaArtificial.contadorPalabraPerro];
                    iteradorPalabra++;
                }
                else if (master.vacaHabla)
                {
                    GUI.Button(new Rect(550, 200, 200, 50), Master.InteligenciaArtificial.malo[Master.InteligenciaArtificial.contadorPalabraVaca]);
                    salvandoPalabra[iteradorPalabra] = Master.InteligenciaArtificial.malo[Master.InteligenciaArtificial.contadorPalabraVaca];
                    iteradorPalabra++;
                }
            }
            else if (Master.InteligenciaArtificial.jugadorRegular)
            {
                if (master.perroHabla)
                {
                    GUI.Button(new Rect(50, 200, 200, 50), Master.InteligenciaArtificial.regular[Master.InteligenciaArtificial.contadorPalabraPerro]);
                    salvandoPalabra[iteradorPalabra] = Master.InteligenciaArtificial.regular[Master.InteligenciaArtificial.contadorPalabraPerro];
                    iteradorPalabra++;
                }
                else if (master.vacaHabla)
                {
                    GUI.Button(new Rect(550, 200, 200, 50), Master.InteligenciaArtificial.regular[Master.InteligenciaArtificial.contadorPalabraVaca]);
                    salvandoPalabra[iteradorPalabra] = Master.InteligenciaArtificial.regular[Master.InteligenciaArtificial.contadorPalabraVaca];
                    iteradorPalabra++;
                }
            }
            else if (Master.InteligenciaArtificial.jugadorBueno)
            {
                if (master.perroHabla)
                {
                    GUI.Button(new Rect(50, 200, 200, 50), Master.InteligenciaArtificial.bueno[Master.InteligenciaArtificial.contadorPalabraPerro]);
                    salvandoPalabra[iteradorPalabra] = Master.InteligenciaArtificial.bueno[Master.InteligenciaArtificial.contadorPalabraPerro];
                    iteradorPalabra++;
                }
                else if (master.vacaHabla)
                {
                    GUI.Button(new Rect(550, 200, 200, 50), Master.InteligenciaArtificial.bueno[Master.InteligenciaArtificial.contadorPalabraVaca]);
                    salvandoPalabra[iteradorPalabra] = Master.InteligenciaArtificial.bueno[Master.InteligenciaArtificial.contadorPalabraVaca];
                    iteradorPalabra++;
                }
            }
        }
    }
}
