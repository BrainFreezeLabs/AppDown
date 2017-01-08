using UnityEngine;
using System.Collections;
public class Son
{

    public Son()
    {

    }

    public void silabas(int _letrasAChecar)
    {
        //declaración de variables. Es importante que se declaren cada vez que se inicia esta función por que 
        //son recursivas, es decir, se reinician a su valor declarado cada vez que se utiliza la función.

        int[] letrasInt = new int[_letrasAChecar];
        char[] letras = new char[_letrasAChecar];

        for (int i = 0; i < _letrasAChecar; i++)
        {
            if (i + Analizador.offsetPrevio < Parcer.listaPalabras[Analizador.index].palabra.Length)
            {
                letrasInt[i] = Parcer.listaPalabras[Analizador.index].palabraAnalizada[i + Analizador.offsetPrevio];
                letras[i] = Parcer.listaPalabras[Analizador.index].palabra[i + Analizador.offsetPrevio];
            }
            else
            {
                break;
            }
        }

        //esta es la parte principal de la funcion.
        switch (_letrasAChecar)
        {

            //solo existen, conocidos 3 patrones de silabras de 6 letras.
            //1) Guiais Gui-gue sin dieresis es inseparable, continua un diptongo y termina en consonante
            //2) A-cahual hay un triptongo cortado por una h, comienza en consonante y termina en consonante
            //3) Criais hay una inseparable, luego un triptongo y finalmente una consonante
            case 6:
                {   
                    //1)
                    if((letras[0] == 'g') && (letras[1] == 'u') && (letras[2] == 'e' || letras[2] == 'i') &&
                       (letrasInt[3] == (int)Analizador.letra.vocal) && 
                       (letrasInt[4] == (int)Analizador.letra.vocal) &&
                       (letrasInt[5] == (int)Analizador.letra.consonantes))
                    {
                        Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3] + "" + letras[4] + "" + letras[5]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 6;
                        break;
                    }
                    //2)
                    else if(letrasInt[0] == (int)Analizador.letra.consonantes &&
                            letrasInt[1] == (int)Analizador.letra.vocal &&
                            letras[2] == 'h' && letrasInt[3] == (int)Analizador.letra.vocal &&
                            letrasInt[4] == (int)Analizador.letra.vocal &&
                            letrasInt[5] == (int)Analizador.letra.consonantes)
                    {
                        Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3] + "" + letras[4] + "" + letras[5]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 6;
                        break;
                    }
                    //3
                    else if((((letras[0] == 'b' || letras[0] == 'c' || letras[0] == 'f' ||
                        letras[0] == 'g' || letras[0] == 'k' || letras[0] == 'p' || letras [0] == 't') &&
                       (letras[1] == 'r' || letras[1] == 'l')) || (letras[0] == 'r' &&
                       letras[1] == 'r') || (letras[0] == 'l' && letras[1] == 'l') ||
                       (letras[0] == 'c' && letras[1] == 'h')) && letrasInt[2] == (int)Analizador.letra.vocal &&
                       letrasInt[3] == (int)Analizador.letra.vocal &&
                       letrasInt[4] == (int)Analizador.letra.vocal &&
                       letrasInt[5] == (int)Analizador.letra.consonantes)
                    {
                        Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3] + "" + letras[4] + "" + letras[5]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 6;
                        break;
                    }
                    //no es ninguna condicion especifica entonces ve a checar con 5
                    else
                    {
                        Debug.Log("baje de caso");
                        goto case 5;
                    }
                }
            
            //solo existen, conocidos, 5 patrones de silabas de 5 letras. 
            //los mostrare con ejemplos para ahorrarme cosas
            //1) cruel 1 inseparable, 1 diptongo y terminacion de la palabra en consonante no junta a otra inseparable. 
            //2) trans-por-te 1 inseparable, una vocal y dos consonantes y en la sexta posicion no hay una vocal.
            //3) Quien 1 consonante, un triptongo y otra consonante no junta a otra inseparable.
            //4) Prohi-bi-do 1 inseparable, 1 diptongo junto con h. 
            case 5:
                {
                    //1)
                    if ((((letras[0] == 'b' || letras[0] == 'c' || letras[0] == 'f' ||
                        letras[0] == 'g' || letras[0] == 'k' || letras[0] == 'p' || letras[0] == 't') &&
                       (letras[1] == 'r' || letras[1] == 'l')) || (letras[0] == 'r' &&
                       letras[1] == 'r') || (letras[0] == 'l' && letras[1] == 'l') ||
                       (letras[0] == 'c' && letras[1] == 'h')) &&
                       letrasInt[2] == (int)Analizador.letra.vocal &&
                       letrasInt[3] == (int)Analizador.letra.vocal &&
                       letrasInt[4] == (int)Analizador.letra.consonantes)
                    {
                        Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3] + "" + letras[4]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 5;
                        break;
                    }
                    //2)
                    else if((((letras[0] == 'b' || letras[0] == 'c' || letras[0] == 'f' ||
                        letras[0] == 'g' || letras[0] == 'k' || letras[0] == 'p' || letras[0] == 't') &&
                       (letras[1] == 'r' || letras[1] == 'l')) || (letras[0] == 'r' &&
                       letras[1] == 'r') || (letras[0] == 'l' && letras[1] == 'l') ||
                       (letras[0] == 'c' && letras[1] == 'h')) && letrasInt[2] == (int)Analizador.letra.vocal &&
                       letrasInt[3] == (int)Analizador.letra.consonantes &&
                       letrasInt[4] == (int)Analizador.letra.consonantes)
                    {
                        if (Analizador.offsetPrevio + 5 < Parcer.listaPalabras[Analizador.index].palabra.Length)
                        {
                            if (letrasInt[5] != (int)Analizador.letra.vocal ||
                                letrasInt[5] != (int)Analizador.letra.acento)
                            {
                                Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3] + "" + letras[4]);
                                Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                                Analizador.offsetPrevio += 5;
                                break;
                            }
                            else
                            {
                                Debug.Log("baje de caso");
                                goto case 4;
                            }
                        }
                        else
                        {
                            Debug.Log("baje de caso");
                            goto case 4;
                        }
                    }
                    //3)
                    else if((letrasInt[0] == (int)Analizador.letra.consonantes && 
                            letrasInt[1] == (int)Analizador.letra.vocal &&
                            letrasInt[2] == (int)Analizador.letra.vocal &&
                            letrasInt[3] == (int)Analizador.letra.vocal && 
                            letrasInt[4] == (int)Analizador.letra.consonantes) ||
                            (letrasInt[0] == (int)Analizador.letra.consonantes &&
                            letrasInt[1] == (int)Analizador.letra.vocal &&
                            letrasInt[2] == (int)Analizador.letra.acento &&
                            letrasInt[3] == (int)Analizador.letra.vocal &&
                            letrasInt[4] == (int)Analizador.letra.consonantes))
                    {
                        Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3] + "" + letras[4]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 5;
                        break;
                    }
                    //4)
                    else if((((letras[0] == 'b' || letras[0] == 'c' || letras[0] == 'f' ||
                        letras[0] == 'g' || letras[0] == 'k' || letras[0] == 'p' || letras[0] == 't') &&
                       (letras[1] == 'r' || letras[1] == 'l')) || (letras[0] == 'r' &&
                       letras[1] == 'r') || (letras[0] == 'l' && letras[1] == 'l') ||
                       (letras[0] == 'c' && letras[1] == 'h')) &&
                       letrasInt[2] == (int)Analizador.letra.vocal && letras[3] == 'h' &&
                       letrasInt[4] == (int)Analizador.letra.vocal)
                    {
                        Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3] + "" + letras[4]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 5;
                        break;
                    }
                    //no es ninguna condicion especifica entonces ve a 4
                    else
                    {
                        Debug.Log("baje de caso");
                        goto case 4;
                    }
                }

            //solo existen, conocidos, 4 patrones de silabas para 4 letras
            //los mostrare en ejemplos para ahorrarme cosas
            //1) blan-co 1 inseparable, una vocal y una consonante y en la 5ta posicion no hay una vocal
            //2) lien-zo 1 consonante, un diptongo y despues una consonante y en la 5ta posicion no hay una vocal
            //3) guau 1 consonante y triptongo, puede ser con y tambien. 
            //4) fray 1 inseparable y diptongo.
            case 4:
                {
                    //1)
                    if ((((letras[0] == 'b' || letras[0] == 'c' || letras[0] == 'f' ||
                            letras[0] == 'g' || letras[0] == 'k' || letras[0] == 'p' || letras[0] == 't') &&
                           (letras[1] == 'r' || letras[1] == 'l')) || (letras[0] == 'r' &&
                           letras[1] == 'r') || (letras[0] == 'l' && letras[1] == 'l') ||
                           (letras[0] == 'c' && letras[1] == 'h')) && (letrasInt[2] == (int)Analizador.letra.vocal ||
                           letrasInt[3] == (int)Analizador.letra.vocal) &&
                           letrasInt[3] == (int)Analizador.letra.consonantes)
                    {
                        if (Analizador.offsetPrevio + 4 < Parcer.listaPalabras[Analizador.index].palabra.Length)
                        {
                            if (letrasInt[4] != (int)Analizador.letra.vocal ||
                                letrasInt[4] != (int)Analizador.letra.acento)
                            {
                                Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3]);
                                Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                                Analizador.offsetPrevio += 4;
                                break;
                            }
                            else
                            {
                                Debug.Log("baje de caso");
                                goto case 3;
                            }
                        }
                        else
                        {
                            Debug.Log("baje de caso");
                            goto case 3;
                        }
                    }
                    //2)
                    else if (letrasInt[0] == (int)Analizador.letra.consonantes &&
                            letrasInt[1] == (int)Analizador.letra.vocal &&
                           (letrasInt[2] == (int)Analizador.letra.vocal ||
                           letrasInt[2] == (int)Analizador.letra.acento) &&
                            letrasInt[3] == (int)Analizador.letra.consonantes)
                    {
                        if (Analizador.offsetPrevio + 4 < Parcer.listaPalabras[Analizador.index].palabra.Length)
                        {
                            if (letrasInt[4] != (int)Analizador.letra.vocal ||
                                letrasInt[4] != (int)Analizador.letra.acento)
                            {
                                Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3]);
                                Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                                Analizador.offsetPrevio += 4;
                                break;
                            }
                            else
                            {
                                Debug.Log("baje de caso");
                                goto case 3;
                            }
                        }
                        else
                        {
                            Debug.Log("baje de caso");
                            goto case 3;
                        }

                    }
                    //3)
                    else if (letrasInt[0] == (int)Analizador.letra.consonantes &&
                            letrasInt[1] == (int)Analizador.letra.vocal &&
                            letrasInt[2] == (int)Analizador.letra.vocal &&
                            (letrasInt[3] == (int)Analizador.letra.vocal || letrasInt[3] == 'y'))
                    {
                        Debug.Log(letras[0] + "" + letras[1] + "" + letras[2] + "" + letras[3]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 4;
                        break;
                    }
                    //no es ninguna condicion especifica entonces ve a 3
                    else
                    {
                        Debug.Log("baje de caso");
                        goto case 3;
                    }
                }
            //solo existen, conocidos, 3 patrones de silabas
            //los mostraré en ejemplos para ahorrarme cosas
            //1) bri-ta-ni-co inseparable seguida de vocal
            //2) fan-tas-ti-co consonante seguida de una vocal y con otra consonante despues
            //3) e-cua-to-ria-no consonante seguida de un diptongo.

            case 3:
                {
                    //1)
                    if ((((letras[0] == 'b' || letras[0] == 'c' || letras[0] == 'f' ||
                            letras[0] == 'g' || letras[0] == 'k' || letras[0] == 'p' || letras[0] == 't') &&
                           (letras[1] == 'r' || letras[1] == 'l')) || (letras[0] == 'r' &&
                           letras[1] == 'r') || (letras[0] == 'l' && letras[1] == 'l') ||
                           (letras[0] == 'c' && letras[1] == 'h')) && 
                           (letrasInt[2] == (int)Analizador.letra.vocal || 
                           letrasInt[2] == (int)Analizador.letra.acento))
                    {
                        Debug.Log(letras[0] + "" + letras[1] + "" + letras[2]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 3;
                        break;
                    }
                    //2)
                    else if(letrasInt[0] == (int)Analizador.letra.consonantes &&
                           (letrasInt[1] == (int)Analizador.letra.vocal ||
                            letrasInt[1] == (int)Analizador.letra.acento) &&
                            letrasInt[2] == (int)Analizador.letra.consonantes)
                    {
                        if (Analizador.offsetPrevio + 3 < Parcer.listaPalabras[Analizador.index].palabra.Length)
                        {
                            if (letrasInt[3] != (int)Analizador.letra.consonantes)
                            {
                                Debug.Log("baje de caso");
                                goto case 2;
                            }
                            else
                            {
                                //en el dado caso de que haya una inseparable existe esta excepción.
                                if ((((letras[2] == 'b' || letras[2] == 'c' || letras[2] == 'f' ||
                                    letras[2] == 'g' || letras[2] == 'k' || letras[2] == 'p' || letras[2] == 't') &&
                                    (letras[3] == 'r' || letras[3] == 'l')) || (letras[2] == 'r' &&
                                    letras[3] == 'r') || (letras[2] == 'l' && letras[3] == 'l') ||
                                    (letras[2] == 'c' && letras[3] == 'h')))
                                {
                                    Debug.Log("baje de caso");
                                    goto case 2;
                                }
                                //si todo va normal usar esto.
                                else {
                                    Debug.Log(letras[0] + "" + letras[1] + "" + letras[2]);
                                    Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                                    Analizador.offsetPrevio += 3;
                                    break;
                                }

                            }
                        }

                        else
                        {
                            Debug.Log(letras[0] + "" + letras[1] + "" + letras[2]);
                            Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                            Analizador.offsetPrevio += 3;
                            break;
                        }
                    }
                    //3)
                    else if(letrasInt[0] == (int)Analizador.letra.consonantes &&
                            letrasInt[1] == (int)Analizador.letra.vocal &&
                           (letrasInt[2] == (int)Analizador.letra.vocal ||
                            letrasInt[2] == (int)Analizador.letra.acento))
                    {
                        Debug.Log(letras[0] + "" + letras[1] + "" + letras[2]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 3;
                        break;
                    }
                    //si no es ninguna especifica baja a 2
                    else
                    {
                        Debug.Log("baje de caso");
                        goto case 2;
                    }
                }

            //solo existen, conocidos, 3 patrones de silaba para 2 letras
            //los mostraré en ejemplo para ahorrarme cosas
            //1) ta-ra-rear consonante-letra
            //2) as-tral letra consonante solo si no sigue una vocal en la 3era posición
            //3) ai-re diptongo seguido de una consonante y despues una vocal
            case 2:
                {
                    //1)
                    if(letrasInt[0] == (int)Analizador.letra.consonantes &&
                      (letrasInt[1] == (int)Analizador.letra.vocal ||
                      letrasInt[1] == (int)Analizador.letra.acento))
                    {
                        Debug.Log(letras[0] + "" + letras[1]);
                        Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                        Analizador.offsetPrevio += 2;
                        break;
                    }
                    //2)
                    else if((letrasInt[0] == (int)Analizador.letra.vocal ||
                            letrasInt[0] == (int)Analizador.letra.acento) &&
                            letrasInt[1] == (int)Analizador.letra.consonantes)
                    {
                        if (Analizador.offsetPrevio + 2 < Parcer.listaPalabras[Analizador.index].palabra.Length)
                        {
                            if (letrasInt[2] != (int)Analizador.letra.vocal ||
                                letrasInt[2] != (int)Analizador.letra.acento)
                            {
                                Debug.Log(letras[0] + "" + letras[1]);
                                Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                                Analizador.offsetPrevio += 2;
                                break;
                            }
                            else
                            {
                                Debug.Log("baje de caso");
                                goto case 1;
                            }
                        }
                        else
                        {
                            Debug.Log("baje de caso");
                            goto case 1;
                        }
                    }
                    //3)
                    else if(letrasInt[0] == (int)Analizador.letra.vocal &&
                            letrasInt[1] == (int)Analizador.letra.vocal)
                           
                    {
                        if (Analizador.offsetPrevio + 3 < Parcer.listaPalabras[Analizador.index].palabra.Length)
                        {
                            if ((letrasInt[2] != (int)Analizador.letra.vocal ||
                            letrasInt[2] != (int)Analizador.letra.acento) &&
                            letrasInt[3] != (int)Analizador.letra.consonantes)
                            {
                                Debug.Log(letras[0] + "" + letras[1]);
                                Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                                Analizador.offsetPrevio += 2;
                                break;
                            }
                            else
                            {
                                Debug.Log("baje de caso");
                                goto case 1;
                            }
                        }
                        else
                        {
                            Debug.Log("baje de caso");
                            goto case 1;
                        }
                    }
                    //si no es ninguno de esos casos ve a 1
                    else
                    {
                        Debug.Log("baje de caso");
                        goto case 1;
                    }
                }

            //solo existe 1 caso para silabas de una vocal
            //ejemplo:
            //a-ta-que solo sucede si hay una consonante entre dos vocales.
            case 1:
                if((letrasInt[0] == (int)Analizador.letra.vocal || 
                    letrasInt[0] == (int)Analizador.letra.acento))
                {
                    if (Analizador.offsetPrevio + 2 < Parcer.listaPalabras[Analizador.index].palabra.Length)
                    {
                        if ((letrasInt[1] != (int)Analizador.letra.vocal ||
                        letrasInt[1] != (int)Analizador.letra.acento) &&
                        letrasInt[2] != (int)Analizador.letra.consonantes)
                        {
                            Debug.Log(letras[0]);
                            Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                            Analizador.offsetPrevio += 1;
                            break;
                        }
                        else
                        {
                            Debug.Log("baje de caso");
                            goto case 0;
                        }
                    }
                    else
                    {
                        Debug.Log("baje de caso");
                        goto case 0;
                    }
                }
                else
                {
                    Debug.Log("baje de caso");
                    goto case 0;
                }

            case 0:
                if (Analizador.offsetPrevio + 2 <= Parcer.listaPalabras[Analizador.index].TamañoDePalabra)
                {
                    //comprobar si hay otro caso que no sea este. 
                    //Debug.Log(letras[Analizador.offsetPrevio] + "" + letras[Analizador.offsetPrevio + 1] /*+ "" + letras[Analizador.offsetPrevio + 2]*/);
                    Parcer.listaPalabras[Analizador.index].numerosDeSilabas++;
                    Analizador.offsetPrevio += Parcer.listaPalabras[Analizador.index].TamañoDePalabra - Analizador.offsetPrevio;
                    break;
                }
                else {
                    break;
                }
        }
    }
}
