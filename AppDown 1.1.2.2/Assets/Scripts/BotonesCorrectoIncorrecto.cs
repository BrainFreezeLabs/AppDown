using UnityEngine;
using System.Collections;

public class BotonesCorrectoIncorrecto : MonoBehaviour {

    //variables para probar las posiciones, alto y ancho del boton Correcto
    float botonCorrectoXPos = Screen.width / 2 + 100;
    float botonCorrectoYpos = Screen.height / 2;
    public float botonCorrectoWidth;
    public float botonCorrectoHeight;

    //variables para probar las posiciones, alto y ancho del boton Incorrecto
    float botonIncorrectoXPos = Screen.width / 2 - 200;
    float botonIncorrectoYpos = Screen.height / 2;
    public float botonIncorrectoWidth;
    public float botonIncorrectoHeight;

    //Salvando el valor de la respuesta
    static public string respuesta, respuestajugador;

    //banderas para la activacion del canvas
    public bool botonPrecionado;

    void Start()
    {
        botonPrecionado = false;
    }

    public void randomizadorDePosicionBotones()
    {
        //cambio de posicion inicial de los botones del canvas 
        float randPos = Random.Range(0, 3);
        Debug.Log(randPos);
        //Debug.Log("randomize");
        if (randPos == 1 || randPos == 2)
        {
            botonCorrectoXPos = Screen.width / 2 - 200;
            botonIncorrectoXPos = Screen.width / 2 + 100;
        }
    }


    void OnGUI()
    {
        /////////////
        // Botones //
        /////////////

        /*       botonIncorrecto/correctowidth

          *(xpos,ypos)
          *_________________________________________     _
          |                                        |    |
          |                                        |    |
          |               "texto"                  |    | botonIncorrecto/correctoHeight
          |                                        |    |
          |________________________________________|    L                               */


        if (GUI.Button(new Rect(botonCorrectoXPos, botonCorrectoYpos,
                                botonCorrectoWidth, botonCorrectoHeight), "Correcto"))
        {
            botonPrecionado = true;
            respuestajugador = "Correcta";
            Debug.Log("PERRO" + Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraPerro - 2] + " \n VACA " + Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraVaca - 2]);
            Debug.Log("BOTON CORRECTO PRESIONADO RESPUESTA:");

            if (!Master.InteligenciaArtificial.jugadorDiagnosticado)
            {
                if (Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraPerro - 2] ==
                    Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraVaca - 2])
                {
                    respuesta = "Correcta";
                    Debug.Log("CORECTA");
                    Master.vecesCorrectas++;
                    //Master.ConteoDeVecesCorrectas();
                }
                else
                {
                    respuesta = "Incorrecta";
                    Debug.Log("INCORECTA");
                    Master.vecesErroneas++;
                    //Master.ConteoDeVecesErroneas();
                }
            }
            else
            {
                if (Master.InteligenciaArtificial.jugadorMalo)
                {
                    if (Master.InteligenciaArtificial.malo[Master.InteligenciaArtificial.contadorPalabraPerro - 2] ==
                        Master.InteligenciaArtificial.malo[Master.InteligenciaArtificial.contadorPalabraVaca - 2])
                    {
                        respuesta = "Correcta";
                        Debug.Log("CORECTA");
                        Master.vecesCorrectas++;
                        //Master.ConteoDeVecesCorrectas();
                    }
                    else
                    {
                        respuesta = "Incorrecta";
                        Debug.Log("INCORECTA");
                        Master.vecesErroneas++;
                        //Master.ConteoDeVecesErroneas();
                    }
                }
                else if (Master.InteligenciaArtificial.jugadorRegular)
                {
                    if (Master.InteligenciaArtificial.regular[Master.InteligenciaArtificial.contadorPalabraPerro - 2] ==
                        Master.InteligenciaArtificial.regular[Master.InteligenciaArtificial.contadorPalabraVaca - 2])
                    {
                        respuesta = "Correcta";
                        Debug.Log("CORECTA");
                        Master.vecesCorrectas++;
                        //Master.ConteoDeVecesCorrectas();
                    }
                    else
                    {
                        respuesta = "Incorrecta";
                        Debug.Log("INCORECTA");
                        Master.vecesErroneas++;
                       //Master.ConteoDeVecesErroneas();
                    }
                }
                else if (Master.InteligenciaArtificial.jugadorBueno)
                {
                    if (Master.InteligenciaArtificial.bueno[Master.InteligenciaArtificial.contadorPalabraPerro - 2] ==
                        Master.InteligenciaArtificial.bueno[Master.InteligenciaArtificial.contadorPalabraVaca - 2])
                    {
                        respuesta = "Correcta";
                        Debug.Log("CORECTA");
                        Master.vecesCorrectas++;
                        //Master.ConteoDeVecesCorrectas();
                    }
                    else
                    {
                        respuesta = "Incorrecta";
                        Debug.Log("INCORECTA");
                        Master.vecesErroneas++;
                        //Master.ConteoDeVecesErroneas();
                    }
                }
            }
        }

        //boton Incorrecto
        else if (GUI.Button(new Rect(botonIncorrectoXPos, botonIncorrectoYpos,
                                    botonIncorrectoWidth, botonIncorrectoHeight), "Incorrecto"))
        {
            botonPrecionado = true;
            Debug.Log("PERRO" + Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraPerro - 2] + " \n VACA " + Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraVaca - 2]);
            Debug.Log("BOTON INCORRECTO PRESIONADO RESPUESTA:");
            respuestajugador = "Incorrecta";
            if (!Master.InteligenciaArtificial.jugadorDiagnosticado)
            {
                if (Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraPerro - 2] !=
                    Master.InteligenciaArtificial.diagnostico[Master.InteligenciaArtificial.contadorPalabraVaca - 2])
                {

                    respuesta = "Correcta";
                    Debug.Log("CORECTA");
                    Master.vecesCorrectas++;
                    //Master.ConteoDeVecesCorrectas();
                }
                else
                {
                    respuesta = "Incorrecta";
                    Debug.Log("INCORECTA");
                    Master.vecesErroneas++;
                    //Master.ConteoDeVecesErroneas();
                }
            }
            else
            { 
                if (Master.InteligenciaArtificial.jugadorMalo)
                {
                    if (Master.InteligenciaArtificial.malo[Master.InteligenciaArtificial.contadorPalabraPerro - 2] !=
                        Master.InteligenciaArtificial.malo[Master.InteligenciaArtificial.contadorPalabraVaca - 2])
                    {
                        respuesta = "Correcta";
                        Debug.Log("CORECTA");
                        Master.vecesCorrectas++;
                        //Master.ConteoDeVecesCorrectas();
                    }
                    else
                    {
                        respuesta = "Incorrecta";
                        Debug.Log("INCORECTA");
                        Master.vecesErroneas++;
                        //Master.ConteoDeVecesErroneas();
                    }
                }
                else if (Master.InteligenciaArtificial.jugadorRegular)
                {
                    if (Master.InteligenciaArtificial.regular[Master.InteligenciaArtificial.contadorPalabraPerro - 2] !=
                        Master.InteligenciaArtificial.regular[Master.InteligenciaArtificial.contadorPalabraVaca - 2])
                    {
                        respuesta = "Correcta";
                        Debug.Log("CORECTA");
                        Master.vecesCorrectas++;
                        //Master.ConteoDeVecesCorrectas();
                    }
                    else
                    {
                        respuesta = "Incorrecta";
                        Debug.Log("INCORECTA");
                        Master.vecesErroneas++;
                        //Master.ConteoDeVecesErroneas();
                    }
                }
                else if (Master.InteligenciaArtificial.jugadorBueno)
                {
                    if (Master.InteligenciaArtificial.bueno[Master.InteligenciaArtificial.contadorPalabraPerro - 2] !=
                        Master.InteligenciaArtificial.bueno[Master.InteligenciaArtificial.contadorPalabraVaca - 2])
                    {

                        respuesta = "Correcta";
                        Debug.Log("CORECTA");
                        Master.vecesCorrectas++;
                        //Master.ConteoDeVecesCorrectas();
                    }
                    else
                    {
                        respuesta = "Incorrecta";
                        Debug.Log("INCORECTA");
                        Master.vecesErroneas++;
                        //Master.ConteoDeVecesErroneas();
                    }
                }
            }
        }
    }
}
