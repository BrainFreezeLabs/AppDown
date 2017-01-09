using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Background_manager : MonoBehaviour {


    public Image granja;
    public Image espacio;
    public Image vaca;
    public Image pinguino;

    mImage[] images;

    void Awake()
    {
        images = new mImage[] { new mImage(granja), new mImage(espacio), new mImage(vaca), new mImage(pinguino) };
    }

    // Update is called once per frame
    void Update()
    {
        foreach (mImage img in images)
        {
            if (img.tag == "background")
            {
                img.Rezise();
            }
        }
    }



}
