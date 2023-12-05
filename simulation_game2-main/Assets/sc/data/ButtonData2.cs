using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonData2 : MonoBehaviour
{
    public Text t;
    public Outline o;
    public Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a.SetBool("Click", false);
        o.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(WorldName.text == t.text)
        {
            o.enabled = true;
            a.SetBool("Click", true);
        }
        else
        {
            o.enabled = false;
            a.SetBool("Click", false);
        }
    }
}
