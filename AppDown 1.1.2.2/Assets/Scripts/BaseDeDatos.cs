using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;
static public class BaseDeDatos
{
    //static string path = Application.persistentDataPath + @"\No Modificar\db\   ";
    static string[] db1;
    static string[] db2;
    static string[] db3;
    static string[] db4;
    static string[] db5;
    static string[] db6;
    static string[] db7;

    static public string[,] db1s;
    static public string[,] db2s;
    static public string[,] db3s;
    static public string[,] db4s;
    static public string[,] db5s;
    static public string[,] db6s;
    static public string[,] db7s;

    static public string[] dbPropiedades = new string[7];

    //solo se llama una vez cuando el programa toca menu inicial.
    static public void inicializar()
    {
        ////inicializar bases de datos

        //for(int i = 1; i <= 7; )
        //{
        //    if (!File.Exists(path + @"\db" + i + ".csv") || !Directory.Exists(path))
        //    {
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }

        //        File.Copy(Application.streamingAssetsPath + @"\db" + i + ".csv", path + "db" + i + ".csv", true);
        //        i++;
        //        Debug.Log("Archivos copiados");


        //    }
        //    else
        //    {
        //        File.Delete(path + "db" + i + ".csv");
        //        File.Copy(Application.streamingAssetsPath + @"\db" + i + ".csv", path + "db" + i + ".csv", true);
        //        i++;
        //        Debug.Log("Archivos copiados");
        //    }
        //}


        //string[] tomaDeDB1 = File.ReadAllLines(path + "db1.csv");
        //string[] tomaDeDB2 = File.ReadAllLines(path + "db2.csv");
        //string[] tomaDeDB3 = File.ReadAllLines(path + "db3.csv");
        //string[] tomaDeDB4 = File.ReadAllLines(path + "db4.csv");
        //string[] tomaDeDB5 = File.ReadAllLines(path + "db5.csv");
        //string[] tomaDeDB6 = File.ReadAllLines(path + "db6.csv");
        //string[] tomaDeDB7 = File.ReadAllLines(path + "db7.csv");
        //Debug.Log("Bases de datos inicializadas");

        for(int i = 0; i < dbPropiedades.Length; i++)
        {
            dbPropiedades[i] = "Real";
        }

        string[] tomaDeDB1 = new string[DBs.DB1.Length];
        string[] tomaDeDB2 = new string[DBs.DB2.Length];
        string[] tomaDeDB3 = new string[DBs.DB3.Length];
        string[] tomaDeDB4 = new string[DBs.DB4.Length];
        string[] tomaDeDB5 = new string[DBs.DB5.Length];
        string[] tomaDeDB6 = new string[DBs.DB6.Length];
        string[] tomaDeDB7 = new string[DBs.DB7.Length];

        for (int i = 0; i < DBs.DB1.Length; i ++)
        {
            tomaDeDB1[i] = DBs.DB1[i][0];
        }

        for (int i = 0; i < DBs.DB2.Length; i ++)
        {
            tomaDeDB2[i] = DBs.DB2[i][0];
        }

        for (int i = 0; i < DBs.DB3.Length; i++)
        {
            tomaDeDB3[i] = DBs.DB3[i][0];
        }
        for (int i = 0; i < DBs.DB4.Length; i++)
        {
            tomaDeDB4[i] = DBs.DB4[i][0];
        }
        for (int i = 0; i < DBs.DB5.Length; i++)
        {
            tomaDeDB5[i] = DBs.DB5[i][0];
        }
        for (int i = 0; i < DBs.DB6.Length; i++)
        {
            tomaDeDB6[i] = DBs.DB6[i][0];
        }
        for (int i = 0; i < DBs.DB7.Length; i++)
        {
            tomaDeDB7[i] = DBs.DB7[i][0];
        }


        Debug.Log("bases de datos inicalizadas");

        //sort
        //1)
        for (int k = 0; k < tomaDeDB1.Length; k++)
        {
            int sorter;
            string save = tomaDeDB1[k];
            do
            {
                sorter = UnityEngine.Random.Range(0, tomaDeDB1.Length - 1);
            } while (save == tomaDeDB1[sorter]);
            tomaDeDB1[k] = tomaDeDB1[sorter];
            tomaDeDB1[sorter] = save;
        }

        //2)
        for (int k = 0; k < tomaDeDB2.Length; k++)
        {
            int sorter;
            string save = tomaDeDB2[k];
            do
            {
                sorter = UnityEngine.Random.Range(0, tomaDeDB2.Length - 1);
            } while (save == tomaDeDB2[sorter]);
            tomaDeDB2[k] = tomaDeDB2[sorter];
            tomaDeDB2[sorter] = save;
        }

        //3)
        for (int k = 0; k < tomaDeDB3.Length; k++)
        {
            int sorter;
            string save = tomaDeDB3[k];
            do
            {
                sorter = UnityEngine.Random.Range(0, tomaDeDB3.Length - 1);
            } while (save == tomaDeDB3[sorter]);
            tomaDeDB3[k] = tomaDeDB3[sorter];
            tomaDeDB3[sorter] = save;
        }

        //4)
        for (int k = 0; k < tomaDeDB4.Length; k++)
        {
            int sorter;
            string save = tomaDeDB4[k];
            do
            {
                sorter = UnityEngine.Random.Range(0, tomaDeDB4.Length - 1);
            } while (save == tomaDeDB4[sorter]);
            tomaDeDB4[k] = tomaDeDB4[sorter];
            tomaDeDB4[sorter] = save;
        }

        //5)
        for (int k = 0; k < tomaDeDB5.Length; k++)
        {
            int sorter;
            string save = tomaDeDB5[k];
            do
            {
                sorter = UnityEngine.Random.Range(0, tomaDeDB5.Length - 1);
            } while (save == tomaDeDB5[sorter]);
            tomaDeDB5[k] = tomaDeDB5[sorter];
            tomaDeDB5[sorter] = save;
        }

        //6)
        for (int k = 0; k < tomaDeDB6.Length; k++)
        {
            int sorter;
            string save = tomaDeDB6[k];
            do
            {
                sorter = UnityEngine.Random.Range(0, tomaDeDB6.Length - 1);
            } while (save == tomaDeDB6[sorter]);
            tomaDeDB6[k] = tomaDeDB6[sorter];
            tomaDeDB6[sorter] = save;
        }

        //7)
        for (int k = 0; k < tomaDeDB7.Length; k++)
        {
            int sorter;
            string save = tomaDeDB7[k];
            do
            {
                sorter = UnityEngine.Random.Range(0, tomaDeDB7.Length - 1);
            } while (save == tomaDeDB7[sorter]);
            tomaDeDB7[k] = tomaDeDB7[sorter];
            tomaDeDB7[sorter] = save;
        }

        Debug.Log("sorteadito");
        //asigna los valores a las publicas

        db1 = tomaDeDB1;
        db2 = tomaDeDB2;
        db3 = tomaDeDB3;
        db4 = tomaDeDB4;
        db5 = tomaDeDB5;
        db6 = tomaDeDB6;
        db7 = tomaDeDB7;

        string[,] _db1s = new string[db1.Length,2];
        string[,] _db2s = new string[db2.Length,2];
        string[,] _db3s = new string[db3.Length,2];
        string[,] _db4s = new string[db4.Length,2];
        string[,] _db5s = new string[db5.Length,2];
        string[,] _db6s = new string[db6.Length,2];
        string[,] _db7s = new string[db7.Length,2];

        db1s = _db1s;
        db2s = _db2s;
        db3s = _db3s;
        db4s = _db4s;
        db5s = _db5s;
        db6s = _db6s;
        db7s = _db7s;
    }

    //solo se llama una vez cuando el programa toca menu inicial y esta función crea una base de datos en un arreglo bidimensional
    //Ya viene completamente sorteada
    static public void splittear()
    {
        int i = 0, i1 = 0, i2 = 0, i3 = 0, i4 = 0, i5 = 0, i6 = 0;
        foreach (string aunNo in db1)
        {
            string[] casi = aunNo.Split(',');
            int k = 0;
            foreach (string yaMerito in casi)
            {
                db1s[i,k] = yaMerito;
                
                k++;
            }
            //Debug.Log(db1s[i, 0] + " " + db1s[i, 1]);
            i++;
        }

        foreach (string aunNo in db2)
        {
            string[] casi = aunNo.Split(',');
            int k = 0;
            foreach (string yaMerito in casi)
            {
                db2s[i1,k] = yaMerito;
                k++;
            }

            //Debug.Log(db2s[i1, 0] + " " + db2s[i1, 1]);

            i1++;
        }

        foreach (string aunNo in db3)
        {
            string[] casi = aunNo.Split(',');
            int k = 0;
            foreach (string yaMerito in casi)
            {
                db3s[i2,k] = yaMerito;
                k++;
            }
            i2++;
        }

        foreach (string aunNo in db4)
        {
            string[] casi = aunNo.Split(',');
            int k = 0;
            foreach (string yaMerito in casi)
            {
                db4s[i3,k] = yaMerito;
                k++;
            }
            i3++;
        }

        foreach (string aunNo in db5)
        {
            string[] casi = aunNo.Split(',');
            int k = 0;
            foreach (string yaMerito in casi)
            {
                db5s[i4,k] = yaMerito;
                k++;
            }
            i4++;
        }

        foreach (string aunNo in db6)
        {
            string[] casi = aunNo.Split(',');
            int k = 0;
            foreach (string yaMerito in casi)
            {
                db6s[i5,k] = yaMerito;
                k++;
            }
            i5++;
        }

        foreach (string aunNo in db7)
        {
            string[] casi = aunNo.Split(',');
            int k = 0;
            foreach (string yaMerito in casi)
            {
                db7s[i6,k] = yaMerito;
                k++;
            }
            i6++;
        }
    }

}

