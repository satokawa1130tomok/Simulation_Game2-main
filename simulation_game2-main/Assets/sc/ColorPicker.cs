using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public List<Image> Images;
    public FCP_ExampleScript _ExampleScript;
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
      foreach(Image a in Images)
        {
            a.color = _ExampleScript.color;
        }   
      material.color = _ExampleScript.color;
    }
}
