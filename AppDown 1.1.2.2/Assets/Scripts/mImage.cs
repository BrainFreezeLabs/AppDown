using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mImage {

    string _name;
    public Image img;
    public float width;
    private float height;
    private string name;
    private bool visible;
    

	public mImage(Image _img)
    {
        img = _img;
        name = img.name;
        width = GetWidth();
        height = GetHeight();
        visible = false;
    }

    public void Rezise()
    {
        if(Screen.width != width)
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
        
        if(Screen.height != height)
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
    }

    public float GetWidth()
    {
        width = img.rectTransform.sizeDelta.x;
        return width;
    }

    public float GetHeight()
    {
        height = img.rectTransform.sizeDelta.y;
        return height;
    }

    public void SetActive(bool _active)
    {
        if(_active == true)
        {
            //img.
        }
        else
        {

        }
    }
}
