using System.Collections;
using UnityEngine;

static class Analizador
{

    static public int index = 0;
    static public int offsetPrevio = 0;

    static Analizador()
    {

    }
    public enum letra
    {
        vocal = 1,
        acento,
        dieresis,
        consonantes,

    };

    public static void Analisis()
    {
        Son son = new Son(); 
        for (int i = 0; i < Parcer.listaPalabras[index].palabra.Length; i++)
        {
            if (checaSiFunciona(6))
            {
                Debug.Log(offsetPrevio);
                son.silabas(6);
                Debug.Log(offsetPrevio);
            }
            else if (checaSiFunciona(5))
            {
                Debug.Log(offsetPrevio);
                son.silabas(5);
                Debug.Log(offsetPrevio);
            }
            else if (checaSiFunciona(4))
            {
                Debug.Log(offsetPrevio);
                son.silabas(4);
                Debug.Log(offsetPrevio);
            }
            else if (checaSiFunciona(3))
            {
                Debug.Log(offsetPrevio);
                son.silabas(3);
                Debug.Log(offsetPrevio);
            }
            else if (checaSiFunciona(2))
            {
                Debug.Log(offsetPrevio);
                son.silabas(2);
                Debug.Log(offsetPrevio);
            }
            else if (checaSiFunciona(1))
            {
                Debug.Log(offsetPrevio);
                son.silabas(1);
                Debug.Log(offsetPrevio);
            }
            if(offsetPrevio >= Parcer.listaPalabras[index].palabra.Length)
            {   
                offsetPrevio = 0;
                index++;
                break;
            }
        }
    }

    public static bool checaSiFunciona(int letraMaxima)
    {
        if (letraMaxima + offsetPrevio <= Parcer.listaPalabras[index].palabra.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

