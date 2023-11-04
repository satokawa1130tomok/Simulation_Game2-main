using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject camera;
    public Transform camera_;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldAngle = camera_.eulerAngles;
        worldAngle.y += 1 * Time.deltaTime; //speed 
        camera_.eulerAngles = worldAngle;
    }
}
