using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveTool : MonoBehaviour
{
    public GameObject haveposition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Have(ToolData Tdata)
    {
        //  Ray_._hit.transform.parent = haveposition.transform.parent;
        Debug.Log(Tdata.Toolobj);
        GameObject obj;

        obj = (GameObject)Instantiate(Tdata.Toolobj);
        obj.transform.parent = haveposition.transform;
        Destroy(obj.GetComponent<BoxCollider>());
        Destroy(obj.GetComponent<Rigidbody>());
        obj.transform.localPosition = new Vector3(0, 0, 0);
        Vector3 localAngle = new Vector3(0, -90, 0);
        obj.transform.localEulerAngles = localAngle;
        // player2.HaveTool = Tdata.type;

        //Destroy(Ray_._hit);
    }
}
