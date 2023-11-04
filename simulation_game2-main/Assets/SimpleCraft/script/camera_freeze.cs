using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_freeze : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveSelf.inv_activeSelf == true)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;

        }
        if (ActiveSelf.inv_activeSelf == false)
        {
            rb.constraints = RigidbodyConstraints.None;

        }
    }
}
