using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class CheckBox : MonoBehaviour
{
    public bool bool1;

    public static bool bool_;

    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle.isOn = bool_;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnToggleChanged()
    {
        bool1 = toggle.isOn;
        bool_ = bool1;

    }
}
