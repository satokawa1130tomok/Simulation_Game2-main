using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryList : MonoBehaviour
{
    public List<string> name = new List<string>();
    public List<int> count;
    public List<GameObject> obj;
    public List<int> number;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ItemList(WorldObject wdata)
    {
        //bool bool1;
        ////bool1 = name.Contains(Idata.name);
        //Debug.Log(bool1);
        var var1 = -100;
        var1 = name.IndexOf(wdata.name);
        // Debug.Log(var1);
        if (var1 == -1)
        {
            name.Add(wdata.name);
            count.Add(1);
            obj.Add(wdata.CloneObject);
            number.Add(wdata.ItemObjDataNumber_);
        }
        else
        {
            int i;
            i = count[var1];
            i = i + 1;
            count[var1] = i;
        }


        // Debug.Log(string.Join(",", name.Select(name => name.ToString())));
        // Debug.Log(string.Join(",", count.Select(count => count.ToString())));
    }
    public void ResourceList(WorldObject wdata)
    {
        //bool bool1;
        ////bool1 = name.Contains(Idata.name);
        //Debug.Log(bool1);
        WorldObject Rdata = wdata.ResourceObject.GetComponent<WorldObject>();
        int i;
        for (i = 0; i <= wdata.ResourceObjCount-1; i++)
        {
            ItemList(Rdata);
        }

        //Debug.Log(string.Join(",", name.Select(name => name.ToString())));
        // Debug.Log(string.Join(",", count.Select(count => count.ToString())));
    }
    public void ToolList(GameObject Ihit, ToolData Tdata)
    {
        //bool bool1;
        ////bool1 = name.Contains(Idata.name);
        //Debug.Log(bool1);
        var var1 = -100;
        var1 = name.IndexOf(Tdata.name);
        // Debug.Log(var1);
        if (var1 == -1)
        {
            name.Add(Tdata.name);
            count.Add(1);
            obj.Add(Tdata.Toolobj);
            number.Add(Tdata.number);
        }
        else
        {
            int i;
            i = count[var1];
            i = i + 1;
            count[var1] = i;
        }

        //Debug.Log(string.Join(",", name.Select(name => name.ToString())));
        // Debug.Log(string.Join(",", count.Select(count => count.ToString())));
    }
    public void CraftItem(string name_, int count_, GameObject obj_)
    {
        //bool bool1;
        ////bool1 = name.Contains(Idata.name);
        //   Debug.Log(obj);
        var var1 = -100;
        var1 = name.IndexOf(name_);

        // Debug.Log(var1);
        if (var1 == -1)
        {
            name.Add(name_);
            count.Add(count_);
            obj.Add(obj_);
        }
        else
        {
            int i;
            i = count[var1];
            i = i + count_;
            count[var1] = i;
        }
        //Destroy(Ray_._hit);

        // Debug.Log(string.Join(",", name.Select(name => name.ToString())));
        // Debug.Log(string.Join(",", count.Select(count => count.ToString())));
    }

}
