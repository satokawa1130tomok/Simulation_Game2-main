using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = this.transform.eulerAngles;
        a.y += 1;
        this.transform.eulerAngles = a;
    }
}
