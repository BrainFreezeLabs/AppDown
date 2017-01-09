using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mImage {

    string _name;
    public Image img;
    GameObject canvas;

    private float _width;
    public float width { set { _width = value; } get { return GetWidth(); } }

    private float _height;
    public float height { set { _height = value; } get { return GetHeight(); } }

    private string name;
    private bool visible;

    public string tag;
    

	public mImage(Image _img)
    {
        img = _img;
        name = img.name;
        visible = false;
        canvas = GameObject.Find("Canvas" + name);
        tag = img.transform.tag;
    }

    public void Rezise()
    {
        if (Screen.width != width)
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);

        if (Screen.height != height)
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
        }
    }

    public float GetWidth()
    {
        return img.rectTransform.sizeDelta.x; 
    }

    public float GetHeight()
    {
        return img.rectTransform.sizeDelta.y;
    }

    public void SetActive(bool _active)
    { 
        canvas.SetActive(_active);
    }
}
