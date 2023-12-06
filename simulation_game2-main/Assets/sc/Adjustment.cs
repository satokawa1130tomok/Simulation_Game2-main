using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjustment : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        g = collision.gameObject;
    }
   
}
