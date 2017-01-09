using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour {

    private static int PreguntasPorSesion /*= 60*/;
    private static double TiempoMaximoDeRespuesta = 10000f;
    bool YaCorrio;
    string FechaDelSistema;
    public GameObject CanvasMenuPrincipal, Botones, canvasBotones;
    double tiempoInicial, tiempoFinal, tiempoTranscurrido, milisegundosTranscurridos;
    GameObject ConsigueRespuesta;
    static public int NumeroDeEnsayos, VecesQuePerroHabla, VecesQueVacaHabla, vecesCorrectas, vecesErroneas;
    static public int VecesJugadasint;
    static public int ensayosNoContestados;
    int iteradorParaExportar = 0;
    public float tiempoHablaPerroVaca = 1.5f; //milisegundos
    public bool perroHabla;
    public bool vacaHabla;
    //static bool PrimeraVezCorre, PrimeraVezIncorre;
    static public string VecesJugadas, vecesCorrectasS, vecesErroneasS, pmilitrans, dificultad, conNoCon, esperada;
    string[] propiedadesPalabra = new string[40];
    public static int respuestasCorrectas;

    // Use this for initialization

    GameObject capNombre;
    void Awake()
    {
        InteligenciaArtificial ia = new InteligenciaArtificial();
    }


    void Start() {
        FechaDelSistema = System.DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
        NumeroDeEnsayos = 0;
        vecesCorrectas = 0;
        vecesErroneas = 0;
        capNombre = GameObject.Find("Menu principal UI");
        //capNombre.SetActive(true);
        YaCorrio = false;
        //PrimeraVezCorre = true;
        //PrimeraVezIncorre = true;
        perroHabla = false;
        vacaHabla = false;

        ensayosNoContestados = 0;

        PreguntasPorSesion = InteligenciaArtificial.jugadorDiagnosticado ? 32 : 30; //la bandera jugador diagnosticado tiene que ser leida del archivo e inicializada en el primer script que sea ejecutado por Unity
        Debug.Log("PREGUNTAS POR SESION");
    }

    // Update is called once per frame
    void FixedUpdate() {

        RayCast();



        if (NumeroDeEnsayos < PreguntasPorSesion)
        {
            if (MaquinaDeEstados.estado == (int)MaquinaDeEstados.estados.menuPrincipal)
            {
                capNombre.SetActive(true);
                
            }
            else if (MaquinaDeEstados.estado == (int)MaquinaDeEstados.estados.inicioTiempoPerroHabla)
            {
                tiempoInicial = DateTime.Now.Ticks;
                tiempoTranscurrido = 0;
                MaquinaDeEstados.estado = (int)MaquinaDeEstados.estados.perroHabla;
            }
            
            else if (MaquinaDeEstados.estado == (int)MaquinaDeEstados.estados.perroHabla)
            {
                perroHabla = true;
                CanvasMenuPrincipal.SetActive(false);

                if (TiempoTranscurrido() >= tiempoHablaPerroVaca)
                {
                    VecesQuePerroHabla += 1;
                    perroHabla = false;
                    InteligenciaArtificial.contadorPalabraPerro += 2;
                    MaquinaDeEstados.estado = (int)MaquinaDeEstados.estados.inicioTiempoVacaHabla;
                }
            }
            else if (MaquinaDeEstados.estado == (int)MaquinaDeEstados.estados.inicioTiempoVacaHabla)
            {
                tiempoInicial = DateTime.Now.Ticks;
                tiempoTranscurrido = 0;
                MaquinaDeEstados.estado = (int)MaquinaDeEstados.estados.vacaHabla;
            }
            else if (MaquinaDeEstados.estado == (int)MaquinaDeEstados.estados.vacaHabla)
            {
                vacaHabla = true;
                if (TiempoTranscurrido() >= tiempoHablaPerroVaca)
                {
                    VecesQueVacaHabla += 1;
                    vacaHabla = false;
                    InteligenciaArtificial.contadorPalabraVaca += 2;
                    MaquinaDeEstados.estado = (int)MaquinaDeEstados.estados.randomizandoPosicionBotones;
                }
            }
            if (MaquinaDeEstados.estado == (int)MaquinaDeEstados.estados.randomizandoPosicionBotones)
            {
                tiempoInicial = DateTime.Now.Ticks;
                tiempoTranscurrido = 0;
                //Botones.GetComponent<BotonesCorrectoIncorrecto>().randomizadorDePosicionBotones();
                MaquinaDeEstados.estado = (int)MaquinaDeEstados.estados.UIrespuesta;
            }
            if (MaquinaDeEstados.estado == (int)MaquinaDeEstados.estados.UIrespuesta)
            {
                canvasBotones.SetActive(true);

                //tengo 10 segundos para presionar algun boton si no la 
                //pregunta se toma como no contestada y se pasa al sig estado


                if (Botones.GetComponent<BotonesCorrectoIncorrecto>().botonPrecionado)
                {
                    tiempoFinal = DateTime.Now.Ticks;
                    tiempoTranscurrido = tiempoFinal - tiempoInicial;
                    milisegundosTranscurridos = tiempoTranscurrido / TimeSpan.TicksPerMillisecond;
                    pmilitrans = milisegundosTranscurridos.ToString();
                    // Debug.Log("timepo trancurrido " + milisegundosTranscurridos);


                    canvasBotones.SetActive(false);
                    Botones.GetComponent<BotonesCorrectoIncorrecto>().botonPrecionado = false;
                    NumeroDeEnsayos++;
                    Parser();
                    MaquinaDeEstados.estado = (int)MaquinaDeEstados.estados.inicioTiempoPerroHabla;
                    //Debug.Log(NumeroDeEnsayos);



                }
                else
                {
                    tiempoFinal = DateTime.Now.Ticks;
                    tiempoTranscurrido = tiempoFinal - tiempoInicial;
                    milisegundosTranscurridos = tiempoTranscurrido / TimeSpan.TicksPerMillisecond;
                    //Debug.Log(milisegundosTranscurridos);
                    pmilitrans = milisegundosTranscurridos.ToString();
                    if (milisegundosTranscurridos >= TiempoMaximoDeRespuesta)
                    {
                        // Debug.Log("que me la he pelado tio");
                        NumeroDeEnsayos++;
                        BotonesCorrectoIncorrecto.respuesta = "No contestada";
                        ensayosNoContestados++;
                        Parser();
                        //Parcer:: ensayo no contestado = "Z"
                        //Debug.Log(NumeroDeEnsayos);
                        canvasBotones.SetActive(false);
                        MaquinaDeEstados.estado = (int)MaquinaDeEstados.estados.inicioTiempoPerroHabla;
                    }
                }
            }

        }

        else
        {
            if (YaCorrio == false)
            {
                ConteoDeVecesJugadas();
            }
            ConteoDeVecesCorrectas();
            ConteoDeVecesErroneas();
            TextoEnGUI.iteradorPalabra = 0;
            iteradorParaExportar = 0;
            MaquinaDeEstados.estado = (int)MaquinaDeEstados.estados.menuPrincipal;
            SceneManager.LoadScene(0);

            
            //falta reiniciar las variables de la inteligencia artificial.
            //fata definir si la inteligenciaArtificial va a ser dinamica o se actualizara
            //hasta que se termine el ensayo para asi comenzar el siguiente ensayo con la
            //el nuevo nivel adquirido.

        }

    }


    double TiempoTranscurrido()
    {
        tiempoFinal = DateTime.Now.Ticks;
        tiempoTranscurrido = tiempoFinal - tiempoInicial;
        milisegundosTranscurridos = tiempoTranscurrido / TimeSpan.TicksPerMillisecond;
        pmilitrans = milisegundosTranscurridos.ToString();
        return milisegundosTranscurridos;
    } //actualizar funcion con los ciclos del update

    GameObject RayCast()
    {
        GameObject golpeado = null;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                golpeado = hit.transform.gameObject;

            }
        }

        if (golpeado == null)
        {
            return null;
        }
        else
        {
            Debug.Log(golpeado.transform.name);
            return golpeado;
        }
    }

    void contains()
    {
        for(int i = 0; i < BaseDeDatos.db1s.Length; i++)
        {
            if(TextoEnGUI.salvandoPalabra[iteradorParaExportar] == BaseDeDatos.db1s[i,0] && TextoEnGUI.salvandoPalabra[iteradorParaExportar +1] == BaseDeDatos.db1s[i, 1])
            {
                propiedadesPalabra[i] = BaseDeDatos.dbPropiedades[0];
            }

        }
        for (int i = 0; i < BaseDeDatos.db2s.Length; i++)
        {
            if (TextoEnGUI.salvandoPalabra[iteradorParaExportar] == BaseDeDatos.db2s[i, 0] && TextoEnGUI.salvandoPalabra[iteradorParaExportar + 1] == BaseDeDatos.db2s[i, 1])
            {
                propiedadesPalabra[i] = BaseDeDatos.dbPropiedades[1];
            }

        }
        for (int i = 0; i < BaseDeDatos.db3s.Length; i++)
        {
            if (TextoEnGUI.salvandoPalabra[iteradorParaExportar] == BaseDeDatos.db3s[i, 0] && TextoEnGUI.salvandoPalabra[iteradorParaExportar + 1] == BaseDeDatos.db3s[i, 1])
            {
                propiedadesPalabra[i] = BaseDeDatos.dbPropiedades[2];
            }

        }
        for (int i = 0; i < BaseDeDatos.db4s.Length; i++)
        {
            if (TextoEnGUI.salvandoPalabra[iteradorParaExportar] == BaseDeDatos.db4s[i, 0] && TextoEnGUI.salvandoPalabra[iteradorParaExportar + 1] == BaseDeDatos.db4s[i, 1])
            {
                propiedadesPalabra[i] = BaseDeDatos.dbPropiedades[3];
            }

        }
        for (int i = 0; i < BaseDeDatos.db5s.Length; i++)
        {
            if (TextoEnGUI.salvandoPalabra[iteradorParaExportar] == BaseDeDatos.db5s[i, 0] && TextoEnGUI.salvandoPalabra[iteradorParaExportar + 1] == BaseDeDatos.db5s[i, 1])
            {
                propiedadesPalabra[i] = BaseDeDatos.dbPropiedades[4];
            }

        }
        for (int i = 0; i < BaseDeDatos.db6s.Length; i++)
        {
            if (TextoEnGUI.salvandoPalabra[iteradorParaExportar] == BaseDeDatos.db6s[i, 0] && TextoEnGUI.salvandoPalabra[iteradorParaExportar + 1] == BaseDeDatos.db6s[i, 1])
            {
                propiedadesPalabra[i] = BaseDeDatos.dbPropiedades[5];
            }

        }
        for (int i = 0; i < BaseDeDatos.db7s.Length; i++)
        {
            if (TextoEnGUI.salvandoPalabra[iteradorParaExportar] == BaseDeDatos.db7s[i, 0] && TextoEnGUI.salvandoPalabra[iteradorParaExportar + 1] == BaseDeDatos.db7s[i, 1])
            {
                propiedadesPalabra[i] = BaseDeDatos.dbPropiedades[6];
            }

        }
        if(TextoEnGUI.salvandoPalabra[iteradorParaExportar] == TextoEnGUI.salvandoPalabra[iteradorParaExportar + 1])
        {
            esperada = "Correcta";
        }
        if(TextoEnGUI.salvandoPalabra[iteradorParaExportar] != TextoEnGUI.salvandoPalabra[iteradorParaExportar + 1])
        {
            esperada = "Incorrecta";
        }
    }


    void Parser() // pasar a una archivo aparte y ponerla como clase estatica!
    {
        contains();
        if(BotonesCorrectoIncorrecto.respuesta == "Correcta" || BotonesCorrectoIncorrecto.respuesta == "Incorrecta")
        {
            conNoCon = "Contestada";
        }
        if(BotonesCorrectoIncorrecto.respuesta == "No Contestada")
        {
            conNoCon = "No Contestada";
        }
        //Inicializando variables
        string NombreDelArchivo = CapturaNombre.nombreJugador + ".CSV", RutaArchivo = Application.persistentDataPath + @"\Exportandos CSV\Test\", Delimitador = ",";

        //Revizando si existe el directorio, si no existe creandolo
        if (!Directory.Exists(RutaArchivo))

        {
            Directory.CreateDirectory(RutaArchivo);
        }

        if (!File.Exists(RutaArchivo + NombreDelArchivo))
        {

            //Creando el contenido del CSV
            string[][] Exportando = new string[][]{
             new string[]{ "ID Participante", "Nombre del jugador","Hora de juego","Secuencia", "Numero de ensayo",
                           "Respuesta o no respuesta", "Palabra Input", "Palabra Output", "Real o Pseudopalabra",
                           "Respuesta input", "Respuesta output", "Tipo de respuesta", "Tiempo de respuesta",
                           "Palabra original o modificada", "Palabra bisilabica o trisilabica", "Palabra facil o dificil", "Tipo de cambio" },

             new string[]{"",CapturaNombre.nombreJugador, FechaDelSistema,VecesJugadas,NumeroDeEnsayos.ToString(),conNoCon,
                 TextoEnGUI.salvandoPalabra[iteradorParaExportar], TextoEnGUI.salvandoPalabra[iteradorParaExportar +1],
                 propiedadesPalabra[iteradorParaExportar], esperada, BotonesCorrectoIncorrecto.respuestajugador,
                 BotonesCorrectoIncorrecto.respuesta, milisegundosTranscurridos.ToString(),"","","",""}
         };

            //Sacando el tamaño del contenido
            int tamaño = Exportando.GetLength(0);
            //inicializando variable StringBuilder para alocar contenido
            StringBuilder ExportadoDeStream = new StringBuilder();

            //Repitiendo para grabar contenido con el StringBuilder
            for (int i = 0; i < tamaño; i++)
            {
                ExportadoDeStream.AppendLine(string.Join(Delimitador, Exportando[i]));
            }

            //Grabando el archivo a el lugar deseado, creandolo si no existe
            File.WriteAllText(RutaArchivo + NombreDelArchivo, ExportadoDeStream.ToString());


            iteradorParaExportar += 2;
        }
        else if (NumeroDeEnsayos + 1 == PreguntasPorSesion)
        {
            string[][] Exportando = new string[][]{
             new string[]{ "", CapturaNombre.nombreJugador, FechaDelSistema, VecesJugadas, NumeroDeEnsayos.ToString(), conNoCon,
                 TextoEnGUI.salvandoPalabra[iteradorParaExportar], TextoEnGUI.salvandoPalabra[iteradorParaExportar+1],
                 propiedadesPalabra[iteradorParaExportar], esperada, BotonesCorrectoIncorrecto.respuestajugador,
                 BotonesCorrectoIncorrecto.respuesta, milisegundosTranscurridos.ToString(), "", "", "", "", "veces bien contestadas =",
                 vecesCorrectas.ToString(), "veces mal contestadas =", vecesErroneas.ToString(), "Dificultad =", dificultad}
         };
            //inicializando variable StringBuilder para alocar contenido
            StringBuilder ExportadoDeStream = new StringBuilder();

            //Repitiendo para grabar contenido con el StringBuilder
            ExportadoDeStream.AppendLine(string.Join(Delimitador, Exportando[0]));


            //Agregando texto al archivo sin sobreescribir el texto pasado dejando una linea entre cada ejecusión
            File.AppendAllText(RutaArchivo + NombreDelArchivo, ExportadoDeStream.ToString());

        }
        else
        {
            //Creando el contenido del CSV
            string[][] Exportando = new string[][]{
             new string[]{ "", CapturaNombre.nombreJugador, FechaDelSistema, VecesJugadas, NumeroDeEnsayos.ToString(), conNoCon,
                 TextoEnGUI.salvandoPalabra[iteradorParaExportar], TextoEnGUI.salvandoPalabra[iteradorParaExportar+1],
                 propiedadesPalabra[iteradorParaExportar], esperada, BotonesCorrectoIncorrecto.respuestajugador,
                 BotonesCorrectoIncorrecto.respuesta, milisegundosTranscurridos.ToString(), "", "", "", "" }
         };
            //inicializando variable StringBuilder para alocar contenido
            StringBuilder ExportadoDeStream = new StringBuilder();

            //Repitiendo para grabar contenido con el StringBuilder
            ExportadoDeStream.AppendLine(string.Join(Delimitador, Exportando[0]));


            //Agregando texto al archivo sin sobreescribir el texto pasado dejando una linea entre cada ejecusión
            File.AppendAllText(RutaArchivo + NombreDelArchivo, ExportadoDeStream.ToString());
            iteradorParaExportar += 2;



        }
    }

    void ConteoDeVecesJugadas()
    {
        //Leyendo cuantas veces ha jugado el niño
        //Primero creando un string para grabar
        if (File.Exists(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador))
        {
            //Debug.Log("Ahuevo si lo lei");
            VecesJugadas = File.ReadAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador);
            int.TryParse(VecesJugadas, out VecesJugadasint);
        }
        else
        {
            //Debug.Log("No mames no lei nada");
            VecesJugadas = "0";
            int.TryParse(VecesJugadas, out VecesJugadasint);
        }

        //creando directorio
        if (!Directory.Exists(Application.persistentDataPath + @"\No Modificar\"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + @"\No Modificar\");

        }

        //Escribiendo por primera vez el archivo
        if (!File.Exists(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador))
        {
            File.WriteAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador, VecesJugadas);

        }

        //Sumando 1 a la cuenta de veces jugadas
        VecesJugadasint++;
        //Transformando el int a string y grabandolo en el string
        VecesJugadas = VecesJugadasint.ToString();
        //Grabando el archivo de config
        File.WriteAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador, VecesJugadas);
        YaCorrio = true;


    }

    static public void ConteoDeVecesCorrectas()
    {
        //if (PrimeraVezCorre == true)
        //{
        //    //esta funcion se llama cada vez que alguien pica un boton, así lleva la cuenta por medios externos y no hay que leer un chingo de archivos
        //    if (File.Exists(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "vc"))
        //    {
        //        //Debug.Log("Ahuevo si lo lei");
        //        VecesJugadas = File.ReadAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "vc");
        //        int.TryParse(vecesCorrectasS, out vecesCorrectas);
        //    }
        //    else
        //    {
        //        //Debug.Log("No mames no lei nada");
        //        vecesCorrectasS = "0";
        //        int.TryParse(vecesCorrectasS, out vecesCorrectas);
        //    }

            //creando directorio
            if (!Directory.Exists(Application.persistentDataPath + @"\No Modificar\"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + @"\No Modificar\");

            }

            //Escribiendo por primera vez el archivo
            if (!File.Exists(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "vc"))
            {
                File.WriteAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "vc", vecesCorrectasS);

            }

        //    PrimeraVezCorre = false;
        //}
        vecesCorrectasS = vecesCorrectas.ToString();
        //Grabando el archivo de config
        File.WriteAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "vc", vecesCorrectasS);
    }
    static public void ConteoDeVecesErroneas()
    {
        //if (PrimeraVezIncorre == true)
        //{
        //    if (File.Exists(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "ivc"))
        //    {
        //        //Debug.Log("Ahuevo si lo lei");
        //        VecesJugadas = File.ReadAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "ivc");
        //        int.TryParse(vecesErroneasS, out vecesErroneas);
        //    }
        //    else
        //    {
        //        //Debug.Log("No mames no lei nada");
        //        vecesErroneasS = "0";
        //        int.TryParse(vecesErroneasS, out vecesErroneas);
        //    }

            //creando directorio
            if (!Directory.Exists(Application.persistentDataPath + @"\No Modificar\"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + @"\No Modificar\");

            }

            //Escribiendo por primera vez el archivo
            if (!File.Exists(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "ivc"))
            {
                File.WriteAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador +"ivc", vecesErroneasS);

            }
        //    PrimeraVezIncorre = false;
        //}
        //esta funcion se llama cada vez que alguien pica un boton, así lleva la cuenta por medios externos y no hay que leer un chingo de archivos
        vecesErroneasS = vecesErroneas.ToString();
        //Grabando el archivo de config
        File.WriteAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador+ "ivc", vecesErroneasS);
    }

    static public void LecturaDeVecesCorrectas()
    {
        if (!File.Exists(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "vc"))
        {
            File.Create(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador+ "vc");
        }
        //solo llamar a esta funcion cuando sea necesario saber el numero previo, recomiendo preguntar antes si ha jugado previamente el jugador
        //asi no hay embrollos.
        vecesCorrectasS = File.ReadAllText(Application.persistentDataPath + @"\No Modificar\"  + CapturaNombre.nombreJugador + "vc");
        int.TryParse(vecesCorrectasS, out vecesCorrectas);
    }
    static public void LecturaDeVecesIncorrectas()
    {
        if (!File.Exists(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador  + "ivc"))
        {
            File.Create(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador  + "ivc");
        }
        //solo llamar a esta funcion cuando sea necesario saber el numero previo, recomiendo preguntar antes si ha jugado previamente el jugador
        //asi no hay embrollos.
        vecesErroneasS = File.ReadAllText(Application.persistentDataPath + @"\No Modificar\" + CapturaNombre.nombreJugador + "ivc");
        int.TryParse(vecesErroneasS, out vecesErroneas);
    }

    public class InteligenciaArtificial  //cambiar clase a su propio script y hacerla estatica! !Urgente!
    {
        private int palabrasPorArreglo;

        static public bool jugadorDiagnosticado; //realizar validacion preguntando: if nombreYa existe en la base de datos False else true

        static public bool jugadorMalo;
        static public bool jugadorRegular;
        static public bool jugadorBueno;

        public static string[] diagnostico;
        public static string[] malo;
        public static string[] regular;
        public static string[] bueno;

        public static int contadorPalabraPerro;
        public static int contadorPalabraVaca;

        int c1;
        int c4;
        int c5;
        int c6;
        int c7;
        int c8;
        int c9;

        int it_c1;
        int it_c4;
        int it_c5;
        int it_c6;
        int it_c7;
        int it_c8;
        int it_c9;

        public InteligenciaArtificial()
        {
            palabrasPorArreglo = 64;

            jugadorDiagnosticado = false; // esta bandera tiene que ser leida del archivo con la  informacion del jugador

            jugadorMalo = false;
            jugadorRegular = false;
            jugadorBueno = false;

            diagnostico = new string [palabrasPorArreglo];
            malo = new string [palabrasPorArreglo];
            regular = new string [palabrasPorArreglo];
            bueno = new string [palabrasPorArreglo];

            contadorPalabraPerro = 0;
            contadorPalabraVaca = 1;

            c1 = 0;
            c4 = 0;
            c5 = 0;
            c6 = 0;
            c7 = 0;
            c8 = 0;
            c9 = 0;

            it_c1 = 0;
            it_c4 = 0;
            it_c5 = 0;
            it_c6 = 0;
            it_c7 = 0;
            it_c8 = 0;
            it_c9 = 0;

            Debug.Log("IA inicializada");
            Diagnostico();
            Malo();
            Regular();
            Bueno();
        }


        public static void DiagnosticarJugador()
        {

            if (NumeroDeEnsayos < PreguntasPorSesion)
            {
                if (vecesCorrectas < 11 && VecesJugadasint != 0)
                {
                    jugadorMalo = true;
                    jugadorDiagnosticado = true;
                    dificultad = "Para malo";
                    Debug.Log(jugadorMalo + " malo");
                }
                else if (vecesCorrectas > 10 && vecesCorrectas < 21 && VecesJugadasint != 0)
                {
                    jugadorRegular = true;
                    jugadorDiagnosticado = true;
                    dificultad = "Para regular";
                    Debug.Log(jugadorRegular + " regular");
                }
                else if (vecesCorrectas > 20 && VecesJugadasint != 0)
                {
                    jugadorBueno = true;
                    jugadorDiagnosticado = true;
                    dificultad = "Para bueno";
                    Debug.Log(jugadorBueno + " bueno");
                }
                else if (VecesJugadasint == 0)
                {
                    jugadorDiagnosticado = false;
                    dificultad = "diag";
                    Debug.Log(jugadorDiagnosticado + " diag");
                }
            }
        }


        private void Diagnostico()
        {
            c1 = 32;
            c4 = 6;
            c5 = 6;
            c6 = 6;
            c7 = 6;
            c8 = 4;
            c9 = 4;

            for(int i = 0; i < palabrasPorArreglo; i += 2)
            {
                if (i < c1)
                {
                    diagnostico[i] = BaseDeDatos.db1s[it_c1, 0];
                    diagnostico[i + 1] = BaseDeDatos.db1s[it_c1, 1];
                    ++it_c1;
                }
                else if ((i >= c1) && (i < c1 + c4))
                {
                    diagnostico[i] = BaseDeDatos.db2s[it_c4, 0];
                    diagnostico[i + 1] = BaseDeDatos.db2s[it_c4, 1];
                    ++it_c4;
                }
                else if((i >= c1 + c4) && (i < c1 + c4 + c5))
                {
                    diagnostico[i] = BaseDeDatos.db3s[it_c5, 0];
                    diagnostico[i + 1] = BaseDeDatos.db3s[it_c5, 1];
                    ++it_c5;
                }
                else if((i >= c1 + c4 +c5) && (i < c1 + c4 + c5 + c6))
                {
                    diagnostico[i] = BaseDeDatos.db3s[it_c6, 0];
                    diagnostico[i + 1] = BaseDeDatos.db3s[it_c6, 1];
                    ++it_c6;
                }
                else if ((i >= c1 + c4 + c5 + c6) && (i < c1 + c4 + c5 + c6 + c7))
                {
                    diagnostico[i] = BaseDeDatos.db3s[it_c7, 0];
                    diagnostico[i + 1] = BaseDeDatos.db3s[it_c7, 1];
                    ++it_c7;
                }
                else if ((i >= c1 + c4 + c5 + c6 + c7) && (i < c1 + c4 + c5 + c6 + c7 + c8))
                {
                    diagnostico[i] = BaseDeDatos.db3s[it_c8, 0];
                    diagnostico[i + 1] = BaseDeDatos.db3s[it_c8, 1];
                    ++it_c8;
                }
                else if ((i >= c1 + c4 + c5 + c6 + c7 + c8) && (i < c1 + c4 + c5 + c6 + c7 + c8 + c9))
                {
                    diagnostico[i] = BaseDeDatos.db3s[it_c9, 0];
                    diagnostico[i + 1] = BaseDeDatos.db3s[it_c9, 1];
                    ++it_c9;
                }

            }

            //Debug.Log("comienza el arreglo Diagnostico");
            //for (int i = 0; i < diagnostico.Length; ++i)
            //{
            //    if (diagnostico[i] != null)
            //    Debug.Log(diagnostico[i] + " " + i);
            //}
        }

        private void Malo()
        {
            c1 = 32;
            c4 = 8;
            c5 = 8;
            c6 = 4;
            c7 = 4;
            c8 = 4;
            c9 = 4;

            for (int i = 0; i < palabrasPorArreglo; i += 2)
            {
                if (i < c1)
                {
                    malo[i] = BaseDeDatos.db1s[it_c1, 0];
                    malo[i + 1] = BaseDeDatos.db1s[it_c1, 1];
                    ++it_c1;
                }
                else if ((i >= c1) && (i < c1 + c4))
                {
                    malo[i] = BaseDeDatos.db2s[it_c4, 0];
                    malo[i + 1] = BaseDeDatos.db2s[it_c4, 1];
                    ++it_c4;
                }
                else if ((i >= c1 + c4) && (i < c1 + c4 + c5))
                {
                    malo[i] = BaseDeDatos.db3s[it_c5, 0];
                    malo[i + 1] = BaseDeDatos.db3s[it_c5, 1];
                    ++it_c5;
                }
                else if ((i >= c1 + c4 + c5) && (i < c1 + c4 + c5 + c6))
                {
                    malo[i] = BaseDeDatos.db3s[it_c6, 0];
                    malo[i + 1] = BaseDeDatos.db3s[it_c6, 1];
                    ++it_c6;
                }
                else if ((i >= c1 + c4 + c5 + c6) && (i < c1 + c4 + c5 + c6 + c7))
                {
                    malo[i] = BaseDeDatos.db3s[it_c7, 0];
                    malo[i + 1] = BaseDeDatos.db3s[it_c7, 1];
                    ++it_c7;
                }
                else if ((i >= c1 + c4 + c5 + c6 + c7) && (i < c1 + c4 + c5 + c6 + c7 + c8))
                {
                    malo[i] = BaseDeDatos.db3s[it_c8, 0];
                    malo[i + 1] = BaseDeDatos.db3s[it_c8, 1];
                    ++it_c8;
                }
                else if ((i >= c1 + c4 + c5 + c6 + c7 + c8) && (i < c1 + c4 + c5 + c6 + c7 + c8 + c9))
                {
                    malo[i] = BaseDeDatos.db3s[it_c9, 0];
                    malo[i + 1] = BaseDeDatos.db3s[it_c9, 1];
                    ++it_c9;
                }

            }

            //Debug.Log("comienza el arreglo Malo");
            //for (int i = 0; i < malo.Length; ++i)
            //{
            //    if (malo[i] != null)
            //        Debug.Log(malo[i] + " " + i);
            //}
        }

        private void Regular()
        {
            c1 = 32;
            c4 = 4;
            c5 = 4;
            c6 = 8;
            c7 = 8;
            c8 = 4;
            c9 = 4;

            for (int i = 0; i < palabrasPorArreglo; i += 2)
            {
                if (i < c1)
                {
                    regular[i] = BaseDeDatos.db1s[it_c1, 0];
                    regular[i + 1] = BaseDeDatos.db1s[it_c1, 1];
                    ++it_c1;
                }
                else if ((i >= c1) && (i < c1 + c4))
                {
                    regular[i] = BaseDeDatos.db2s[it_c4, 0];
                    regular[i + 1] = BaseDeDatos.db2s[it_c4, 1];
                    ++it_c4;
                }
                else if ((i >= c1 + c4) && (i < c1 + c4 + c5))
                {
                    regular[i] = BaseDeDatos.db3s[it_c5, 0];
                    regular[i + 1] = BaseDeDatos.db3s[it_c5, 1];
                    ++it_c5;
                }
                else if ((i >= c1 + c4 + c5) && (i < c1 + c4 + c5 + c6))
                {
                    regular[i] = BaseDeDatos.db3s[it_c6, 0];
                    regular[i + 1] = BaseDeDatos.db3s[it_c6, 1];
                    ++it_c6;
                }
                else if ((i >= c1 + c4 + c5 + c6) && (i < c1 + c4 + c5 + c6 + c7))
                {
                    regular[i] = BaseDeDatos.db3s[it_c7, 0];
                    regular[i + 1] = BaseDeDatos.db3s[it_c7, 1];
                    ++it_c7;
                }
                else if ((i >= c1 + c4 + c5 + c6 + c7) && (i < c1 + c4 + c5 + c6 + c7 + c8))
                {
                    regular[i] = BaseDeDatos.db3s[it_c8, 0];
                    regular[i + 1] = BaseDeDatos.db3s[it_c8, 1];
                    ++it_c8;
                }
                else if ((i >= c1 + c4 + c5 + c6 + c7 + c8) && (i < c1 + c4 + c5 + c6 + c7 + c8 + c9))
                {
                    regular[i] = BaseDeDatos.db3s[it_c9, 0];
                    regular[i + 1] = BaseDeDatos.db3s[it_c9, 1];
                    ++it_c9;
                }

            }

            //Debug.Log("comienza el arreglo Regular");
            //for (int i = 0; i < regular.Length; ++i)
            //{
            //    if (regular[i] != null)
            //        Debug.Log(regular[i] + " " + i);
            //}
        }

        private void Bueno()
        {
            c1 = 32;
            c4 = 4;
            c5 = 4;
            c6 = 4;
            c7 = 4;
            c8 = 8;
            c9 = 8;

            for (int i = 0; i < palabrasPorArreglo; i += 2)
            {
                if (i < c1)
                {
                    bueno[i] = BaseDeDatos.db1s[it_c1, 0];
                    bueno[i + 1] = BaseDeDatos.db1s[it_c1, 1];
                    ++it_c1;
                }
                else if ((i >= c1) && (i < c1 + c4))
                {
                    bueno[i] = BaseDeDatos.db2s[it_c4, 0];
                    bueno[i + 1] = BaseDeDatos.db2s[it_c4, 1];
                    ++it_c4;
                }
                else if ((i >= c1 + c4) && (i < c1 + c4 + c5))
                {
                    bueno[i] = BaseDeDatos.db3s[it_c5, 0];
                    bueno[i + 1] = BaseDeDatos.db3s[it_c5, 1];
                    ++it_c5;
                }
                else if ((i >= c1 + c4 + c5) && (i < c1 + c4 + c5 + c6))
                {
                    bueno[i] = BaseDeDatos.db3s[it_c6, 0];
                    bueno[i + 1] = BaseDeDatos.db3s[it_c6, 1];
                    ++it_c6;
                }
                else if ((i >= c1 + c4 + c5 + c6) && (i < c1 + c4 + c5 + c6 + c7))
                {
                    bueno[i] = BaseDeDatos.db3s[it_c7, 0];
                    bueno[i + 1] = BaseDeDatos.db3s[it_c7, 1];
                    ++it_c7;
                }
                else if ((i >= c1 + c4 + c5 + c6 + c7) && (i < c1 + c4 + c5 + c6 + c7 + c8))
                {
                    bueno[i] = BaseDeDatos.db3s[it_c8, 0];
                    bueno[i + 1] = BaseDeDatos.db3s[it_c8, 1];
                    ++it_c8;
                }
                else if ((i >= c1 + c4 + c5 + c6 + c7 + c8) && (i < c1 + c4 + c5 + c6 + c7 + c8 + c9))
                {
                    bueno[i] = BaseDeDatos.db3s[it_c9, 0];
                    bueno[i + 1] = BaseDeDatos.db3s[it_c9, 1];
                    ++it_c9;
                }

            }

            //Debug.Log("comienza el arreglo Bueno");
            //for (int i = 0; i < diagnostico.Length; ++i)
            //{
            //    if (bueno[i] != null)
            //        Debug.Log(bueno[i] + " " + i);
            //}
        }
    }
}