using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldName : MonoBehaviour
{
    public InputField inputField;
    public static string text;
    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        text = inputField.text;
        // Debug.Log(text);
    }
}
