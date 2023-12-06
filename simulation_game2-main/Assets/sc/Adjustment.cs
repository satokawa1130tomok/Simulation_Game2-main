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
        if(g != null)
        {
            if (g.tag != "Ground")
            {
                Vector3 vector3 = this.gameObject.transform.position;
                vector3.y++;
                this.gameObject.transform.position = vector3;
            }
            else
            {
                Destroy(this.GetComponent<Adjustment>());
            }

            if (g.GetComponent<WorldObject>())
            {
                int x = Random.Range(300, 450);
                int z = Random.Range(-20, 100);
                int y = 10;
                Vector3 vector3 = new Vector3(x, y, z);
                GameObject CloneObj = Instantiate(this.gameObject, vector3, Quaternion.identity);
                Adjustment ad = CloneObj.AddComponent<Adjustment>();
                Destroy(this.gameObject);
            }
           
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        g = collision.gameObject;
    }
   
}
