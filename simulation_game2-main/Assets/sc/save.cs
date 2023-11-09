using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class save : MonoBehaviour
{

    public FileStream fs;
    public StreamWriter w;
    public StreamReader r;
    public InventoryList _InventoryList;
    public ItemObjData _itemObjData;
    public ObjectManager _objectManager;
    public string[] road_List;
    public int line;
    public ChestManager TargetChest;
    public GameObject image;

    public string WorldName_;
    void Start()
    {

        WorldName_ = WorldName.text;
        image.SetActive(false);
        //string path = Application.persistentDataPath + "file.txt";
        //File.WriteAllText(path, "hoge");

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(TargetChest.ListName.Count);
    }
    public void save_()
    {
        if (!System.IO.Directory.Exists("save/" + WorldName_))
        {
            System.IO.Directory.CreateDirectory("save/" + WorldName_);
        }

        if (!System.IO.File.Exists("save/" + WorldName_ + "/file.txt"))
        {
            System.IO.File.Create("save/" + WorldName_ + "/file.txt");
        }


        image.SetActive(true);
        if (_objectManager.invalid.Count != 0)
        {

            foreach (int x in _objectManager.invalid)//拾ったアイテムを削除
            {
                _objectManager.position_x.RemoveAt(x);
                _objectManager.position_y.RemoveAt(x);
                _objectManager.position_z.RemoveAt(x);
                _objectManager.rotation_x.RemoveAt(x);
                _objectManager.rotation_y.RemoveAt(x);
                _objectManager.rotation_z.RemoveAt(x);
                _objectManager.obj.RemoveAt(x);
                _objectManager.number.RemoveAt(x);


            }
            _objectManager.invalid.Clear();
        }

        fs = new FileStream("save/" + WorldName_ + "/file.txt", FileMode.Create);
        w = new StreamWriter(fs); ;
        w.Write("PlayerData");
        foreach (string a in _InventoryList.name)
        {
            write(a);
        }
        write("");
        foreach (int b in _InventoryList.count)
        {
            string c = b.ToString();
            //  Debug.Log(c);
            write(c);
        }
        write("");
        foreach (int c in _InventoryList.number)
        {
            string b = c.ToString();
            // Debug.Log(c);
            write(b);
        }
        write("WorldData");

        foreach (int c in _objectManager.number)
        {
            string b = c.ToString();
            write(b);
        }
        write("");
        foreach (float c in _objectManager.position_x)
        {
            string b = c.ToString();
            write(b);
        }
        write("");
        foreach (float c in _objectManager.position_y)
        {
            string b = c.ToString();
            write(b);
        }
        write("");
        foreach (float c in _objectManager.position_z)
        {
            string b = c.ToString();
            write(b);
        }
        write("");
        foreach (float c in _objectManager.rotation_x)
        {
            string b = c.ToString();
            write(b);
        }
        write("");
        foreach (float c in _objectManager.rotation_y)
        {
            string b = c.ToString();
            write(b);
        }
        write("");
        foreach (float c in _objectManager.rotation_z)
        {
            string b = c.ToString();
            write(b);
        }
        //   write("Chest");
        int int1 = 0;
        int int2 = 0;
        write("");
        foreach (int a in _objectManager.number)//チェストの中身
        {
            if (a == 3)
            {

                ChestManager chestManager = _objectManager.obj[int1].GetComponent<ChestManager>();
                if (chestManager.ListName.Count != 0)
                {
                    // Debug.Log("A");
                    write("ChestList");
                    write(int1.ToString());
                    foreach (string a1 in chestManager.ListName)
                    {
                        write(a1);
                    }
                    foreach (int a2 in chestManager.ListCount)
                    {
                        write(a2.ToString());
                    }
                    foreach (GameObject a2 in chestManager.ListObj)
                    {
                        WorldObject worldObject = a2.GetComponent<WorldObject>();
                        write(worldObject.ItemObjDataNumber.ToString());
                    }
                    int2 += 1;
                }


            }
            int1 += 1;
        }
        write("");

        w.Close();
        fs.Close();

        image.SetActive(false);
    }
    public void road()
    {

        image.SetActive(true);
        road_List = File.ReadAllLines("file.txt");
        int step = 0;
        _InventoryList.name.Clear();
        _InventoryList.count.Clear();
        _InventoryList.obj.Clear();
        _InventoryList.number.Clear();
        foreach (string a in road_List)
        {
            if (a == "PlayerData")
            {
                continue;
            }
            if (step == 0)
            {
                if (a == "")
                {
                    step = 1;
                    continue;
                }
                else
                {
                    _InventoryList.name.Add(a);
                }
            }
            if (step == 1)
            {
                if (a == "")
                {
                    step = 2;
                    continue;
                }
                else
                {
                    _InventoryList.count.Add(int.Parse(a));
                }
            }
            if (step == 2)
            {
                if (a == "WorldData")
                {
                    step = 3;
                    _objectManager.clear();
                    continue;
                }
                else
                {

                    GameObject b = _itemObjData.obj[int.Parse(a)];
                    _InventoryList.obj.Add(b);
                    _InventoryList.number.Add(int.Parse(a));
                }
            }
            if (step == 3)
            {
                if (a == "")
                {
                    step = 4;
                    continue;
                }
                else
                {
                    int b = int.Parse(a);
                    _objectManager.number.Add(b);

                }
            }
            if (step == 4)
            {
                if (a == "")
                {
                    step = 5;
                    continue;
                }
                else
                {
                    float b = float.Parse(a);
                    _objectManager.position_x.Add(b);
                }
            }
            if (step == 5)
            {
                if (a == "")
                {
                    step = 6;
                    continue;
                }
                else
                {
                    float b = float.Parse(a);
                    _objectManager.position_y.Add(b);
                }
            }
            if (step == 6)
            {
                if (a == "")
                {
                    step = 7;
                    continue;
                }
                else
                {
                    float b = float.Parse(a);
                    _objectManager.position_z.Add(b);
                }
            }
            if (step == 7)
            {
                if (a == "")
                {
                    step = 8;
                    continue;
                }
                else
                {
                    float b = float.Parse(a);
                    _objectManager.rotation_x.Add(b);
                }
            }
            if (step == 8)
            {
                if (a == "")
                {
                    step = 9;
                    continue;
                }
                else
                {
                    float b = float.Parse(a);
                    _objectManager.rotation_y.Add(b);
                }
            }

            if (step == 9)
            {
                if (a == "")
                {
                    //Debug.Log("c");
                    step = 10;
                    int aa = 0;
                    foreach (int b in _objectManager.number)
                    {
                        //Debug.Log(aa);
                        GameObject c = _itemObjData.obj[b];
                        Vector3 d = new Vector3(_objectManager.position_x[aa], _objectManager.position_y[aa], _objectManager.position_z[aa]);
                        Quaternion e = Quaternion.Euler(_objectManager.rotation_x[aa], _objectManager.rotation_y[aa], _objectManager.rotation_x[aa]);
                        // Debug.Log(d +""+ e);
                        GameObject f = Instantiate(c, d, e);
                        _objectManager.obj.Add(f);
                        aa += 1;
                    }
                    line = -1;
                    continue;

                }
                else
                {
                    float b = float.Parse(a);
                    _objectManager.rotation_z.Add(b);
                }
            }
            if (step == 10)
            {

                if (a == "ChestList")
                {
                    line = 0;
                    continue;
                }
                else if (line == 0)
                {

                    TargetChest = _objectManager.obj[int.Parse(a)].GetComponent<ChestManager>();

                    line = 1;
                    continue;
                }
                else if (line == 1)
                {
                    TargetChest.ListName.Add(a);
                    line = 2;
                    continue;
                }
                else if (line == 2)
                {
                    TargetChest.ListCount.Add(int.Parse(a));
                    line = 3;
                    continue;
                }
                else if (line == 3)
                {
                    if (a == "")
                    {
                        break;
                    }
                    else
                    {
                        TargetChest.ListObj.Add(_itemObjData.obj[int.Parse(a)]);
                        continue;
                    }
                }





            }
        }

        image.SetActive(false);

    }
    public void write(string a)
    {
        w.Write("\n" + a);
    }
}
