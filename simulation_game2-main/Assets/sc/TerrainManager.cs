using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject Terrain;
    public GameObject clone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Terrain == null)
        {
            Vector3 vect = new Vector3(70.80122f, 0f, -73.27863f);
            Terrain = Instantiate(clone, vect, Quaternion.identity);
        }
    }
}
