using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_manager : MonoBehaviour
{
    public bool a;
    public GameObject canvas_;


    // Start is called before the first frame update
    void Start()
    {
        a = false;
    }

    // Update is called once per frame
    void Update()
    {
        canvas_.SetActive(a);
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (a == false && Input.GetKeyDown(KeyCode.E)) { a = true; CameraControll.active_camera = false; }
            else
        if (a == true && Input.GetKeyDown(KeyCode.E)) { a = false; CameraControll.active_camera = true; }
        }


    }

}
