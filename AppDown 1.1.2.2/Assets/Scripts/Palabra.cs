using UnityEngine;
using System.Collections;

public class Palabra {

    public string palabra;
    public int[] palabraAnalizada;
   public int numerosDeSilabas;
   public int tipoDePalabra;
   public int tipoDeCambio;
   public string dificultad;
   public int TamañoDePalabra;

    public Palabra(string _palabra)
    {
        palabra = _palabra;
        palabraAnalizada = new int[palabra.Length];
        TamañoDePalabra = _palabra.Length;
        inicializarPalabra();
        
    }

    void inicializarPalabra()
    {
        int i = 0;
        foreach (char letra in palabra)
        {
            
            if ((letra == 'A' || letra == 'a') || (letra == 'E' || letra == 'e') || (letra == 'I' || letra == 'i') || (letra == 'O' || letra == 'o') || (letra == 'U' || letra == 'u'))
            {
                palabraAnalizada[i] = (int)Analizador.letra.vocal;
                i++;
                //Debug.Log("Soy vocal");
            }
            else if (letra == 'á' || letra == 'é' || letra == 'í' || letra == 'ó' || letra == 'ú' ||
                     letra == 'Á' || letra == 'É' || letra == 'Í' || letra == 'Ó' || letra == 'Ú')
            {
                palabraAnalizada[i] = (int)Analizador.letra.acento;
                i++;
                //Debug.Log("Estoy acentuada!");
            }
            else if (letra == 'ü' || letra == 'Ü')
            {

                palabraAnalizada[i] = (int)Analizador.letra.dieresis;
                i++;
                //Debug.Log("tengo dieresis"); 
            }
            
            else if ((((letra <= 'Z' && letra > 'A')) || (letra <= 'z' && letra > 'a')) &&
                       (letra != 'A' && letra != 'E' && letra != 'I' && letra != 'O' && letra != 'U' &&
                        letra != 'a' && letra != 'e' && letra != 'i' && letra != 'o' && letra != 'u' && 
                        letra != 'á' && letra != 'é' && letra != 'í' && letra != 'ó' && letra != 'ú' &&
                        letra != 'Á' && letra != 'É' && letra != 'Í' && letra != 'Ó' && letra != 'Ú' && 
                        letra != 'ü' && letra != 'Ü'))
            {
                palabraAnalizada[i] = (int)Analizador.letra.consonantes;
                i++;
                //Debug.Log("Soy consonante");
            }
        }
    }

}
