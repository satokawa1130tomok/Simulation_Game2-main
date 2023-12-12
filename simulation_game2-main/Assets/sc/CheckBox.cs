using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class CheckBox : MonoBehaviour
{
    public bool bool1_t;
    public bool bool1_d;

    public static bool bool_t;
    public static bool bool_d;

    public Toggle toggle_t;
    public Toggle toggle_d;
    // Start is called before the first frame update
    void Start()
    {
        toggle_t.isOn = bool_t;
        toggle_d.isOn = bool_d;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnToggleChanged()
    {
        bool1_t = toggle_t.isOn;
        bool_t = bool1_t;

    }
    public void device()
    {
        bool1_d = toggle_d.isOn;
        bool_d = bool1_d;
    }
}
