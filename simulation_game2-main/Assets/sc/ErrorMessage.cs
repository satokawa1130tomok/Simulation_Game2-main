using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour
{
    public Text _text;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void _ErrorMessage(string Message)
    {
        CancelInvoke();
        obj.SetActive(true);
        _text.text = Message;
        Invoke(nameof(a), 1.0f);

    }
    private void a()
    {
        obj.SetActive(false);
    }
}
