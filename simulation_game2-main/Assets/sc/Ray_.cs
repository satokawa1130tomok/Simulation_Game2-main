using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_ : MonoBehaviour
{

    public GameObject rayobj;
    public GameObject player;
    public float maxDistance;
    public static GameObject _hit;
    public static int a;
    public Vector3 HitPosition;
    public bool bool_;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CameraControll.active_camera == true)
        {
            if (Tutorial.ray)
            {
                ray();
            }

        }
        else
            a = 0;
    }
    public void ray()
    {
        // Debug.Log(a);
        Vector3 direction = transform.forward;
        Vector3 origin = rayobj.transform.position;
        Ray ray = new Ray(origin, direction);
        // Debug.DrawRay(origin, direction, Color.red, 100);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);

        if (Physics.Raycast(ray, out hit, maxDistance))
        {

            HitPosition = ray.GetPoint(hit.distance);
            _hit = hit.collider.gameObject;
            WorldObject wdata = _hit.gameObject.GetComponent<WorldObject>();
            if (wdata != null)
            {
                if (wdata.ObjectType == "I")
                {
                    a = 1;
                    bool_ = true;
                }
                else if (wdata.ObjectType == "R")
                {
                    a = 2;
                    bool_ = true;
                }
                else if (wdata.ObjectType == "T")
                {
                    a = 3;
                    bool_ = true;
                }
                else if (wdata.ObjectType == "C")
                {
                    a = 4;
                    bool_ = true;
                }
                else if (wdata.ObjectType == "Cr")
                {
                    //Debug.Log("A");
                    a = 5;
                    bool_ = true;
                }
                else if (_hit.gameObject.tag == "Ground")
                {
                    bool_ = true;
                }

                else
                {
                    bool_ = false;
                }
            }
            else
            {
                _hit = null;
                a = 0;
                bool_ = true;
                HitPosition = ray.GetPoint(maxDistance);

            }
            

            //Debug.Log(wdata.ObjectType);

        }
        else
        {
            //Debug.Log(HitPosition);
            _hit = null;
            a = 0;
            bool_ = true;
            HitPosition = ray.GetPoint(maxDistance);

        }
    }
}
