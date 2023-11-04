using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ActionText : MonoBehaviour
{
    public HitPanel _HitPanel;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text.text = _HitPanel.HitText;
    }
}
