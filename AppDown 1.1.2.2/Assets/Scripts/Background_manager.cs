using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Background_manager : MonoBehaviour {

    public Image granja;
    public Image espacio;

    mImage [] fondos ;

    

	// Use this for initialization
	void Start () {

        fondos = new mImage[] { new mImage(granja), new mImage(espacio) };

        for (int i = 0; i < fondos.Length; ++i)
        {
            fondos[i].img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
            fondos[i].img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
        }

        //granja.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
        //granja.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);

    }

    // Update is called once per frame
    void Update () {

        //fondos[0].Rezise();
        //Debug.Log("la granja tiene una resolucion de " + fondos[0].GetWidth() + "x" + fondos[1].GetHeight());

    }



}
