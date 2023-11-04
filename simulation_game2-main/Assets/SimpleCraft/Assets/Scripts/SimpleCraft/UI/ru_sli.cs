using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ru_sli : MonoBehaviour
{
    public Slider runslider;

    // Use this for initialization
    void Start()
    {
        runslider = GetComponent<Slider>();
        runslider.value = 1;

    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log("runslider.sc" + "value:" + runslider.value + "player.Run:" + player.Run);

        runslider.value = +1;

        if (player_.Run == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (runslider.value >= -0.59)
                {



                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {

            }
        }
    }

}


