using System.Collections;
using UnityEngine;

public class highLight : MonoBehaviour {

    //public Texture startTexture;
    //public Texture mouseOverTexture;
    //bool mouseOver = false;
    public Renderer rend;
    //public Color colorPicker;
    public Material highlightMaterial;
    Material baseMaterial;

    void Start()
    {
        //rend = GetComponent<Renderer>();
        baseMaterial = rend.material;
    }

    void OnMouseEnter()
    {
        //rend.material.color = colorPicker;
    }

    void OnMouseOver()
    {
        //rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
        rend.material = highlightMaterial;
    }

    void OnMouseExit() {
        //rend.material.color = Color.white;
        rend.material = baseMaterial;
    }
}
