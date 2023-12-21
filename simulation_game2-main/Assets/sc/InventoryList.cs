using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryList : MonoBehaviour
{
    public List<string> name_ = new List<string>();
    public List<int> count;
    public List<GameObject> obj;
    public List<int> number;
    public GameObject CloneText_;
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
        var1 = name_.IndexOf(wdata.name_);
        // Debug.Log(var1);
        if (var1 == -1)
        {
            name_.Add(wdata.name_);
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
        for (i = 0; i <= wdata.ResourceObjCount - 1; i++)
        {
            ItemList(Rdata);
        }

        //Debug.Log(string.Join(",", name.Select(name => name.ToString())));
        // Debug.Log(string.Join(",", count.Select(count => count.ToString())));
    }
    public void ClayList(WorldObject wdata)
    {
        //bool bool1;
        ////bool1 = name.Contains(Idata.name);
        //Debug.Log(bool1);

        int a = Random.Range(0, wdata.L_ResourceObject.Count());
        WorldObject Rdata = wdata.L_ResourceObject[a].GetComponent<WorldObject>();
        ItemList(Rdata);
        CloneText(Rdata.name_, 1);

        //Debug.Log(string.Join(",", name.Select(name => name.ToString())));
        // Debug.Log(string.Join(",", count.Select(count => count.ToString())));
    }
    public void ToolList(GameObject Ihit, ToolData Tdata)
    {
        //bool bool1;
        ////bool1 = name.Contains(Idata.name);
        //Debug.Log(bool1);
        var var1 = -100;
        var1 = name_.IndexOf(Tdata.name);
        // Debug.Log(var1);
        if (var1 == -1)
        {
            name_.Add(Tdata.name);
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
        var1 = this.name_.IndexOf(name_);

        // Debug.Log(var1);
        if (var1 == -1)
        {
            this.name_.Add(name_);
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
    public void CloneText(string name, int count)
    {
        // PrefabからCloneObjectを生成
        GameObject cloneObject = Instantiate(CloneText_, CloneText_.transform.position, Quaternion.identity);

        // GetItemがアタッチされている場合、コンポーネントへのアクセスを取得
        GetItem g = cloneObject.GetComponent<GetItem>();

        // GetItemがアタッチされていない場合、アタッチして取得
        if (g == null)
        {
            g = cloneObject.AddComponent<GetItem>();
        }

        // 親オブジェクトを設定
        Transform parentTransform = GameObject.Find("GetItem").transform;
        cloneObject.transform.SetParent(parentTransform);

        // 位置を設定
        //cloneObject.transform.position = CloneText_.transform.position;

        // アクティブにする
        cloneObject.SetActive(true);

        // GetItemのプロパティを設定
        g.ItemName = name;
        g.ItemCount = count;

        //GameObject CloneObject = Instantiate(CloneText_);
        //CloneObject.transform.parent = GameObject.Find("GetItem").transform;
        //CloneObject.SetActive(true);
        //CloneObject.transform.position = CloneText_.transform.position;
        //GetItem g = CloneObject.GetComponent<GetItem>();
        //g.ItemName = name;
        //g.ItemCount = count;
    }

}

