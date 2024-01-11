using System.Collections.Generic;
using SimpleCraft.Core;
using UnityEngine;
using System.Linq;

public class inventoy_list : MonoBehaviour
{
    [SerializeField]
    public List<string> inve_name = new List<string>();
    public List<int> inve_count;

    public List<string> a;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is
    // called once per frame



    public void add_i(string name)
    {

        inve_name.Add(name);
        Debug.Log(inve_name.Count + "a");
        Debug.Log(name);
        Debug.Log(string.Join(",", inve_name.Select(inve_name => inve_name.ToString())));
        //bool bool1 ;
        //bool1 = inve_name.Contains(name);
        //Debug.Log(bool1);
        //inve_name.Add(name);




        //if (!bool1)
        //{ 
        //    inve_name.Add(name);
        //    inve_count.Add(1);



        //}
        //if (bool1)
        //{
        //    var index = inve_name.IndexOf(name);
        //    inve_count[index] = inve_count[index] + 1;

        //}


    }
    public void add_r(GameObject hit)
    {
        Resource resource = hit.GetComponent<Resource>();
        Item re_item = resource.GetComponent<Item>();
        string name = re_item.ItemName;
        bool bool1 = inve_name.Contains(name);
        if (!bool1)
        {
            inve_name.Add(name);
            inve_count.Add(1);
        }
        if (bool1)
        {
            var index = inve_name.IndexOf(name);
            inve_count[index] = inve_count[index] + 1;

        }
        Destroy(hit);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(inve_name.Count + "b");

            //Debug.Log(string.Join(",", inve_name.Select(inve_name => inve_name.ToString())));
            //foreach (string name in inve_name)
            //{
            //    Debug.Log(name);
            //}
            //foreach (string name in inve_name)
            //{
            //    Debug.Log(name);
            //}


        }
    }
}
