using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class save : MonoBehaviour
{

    public FileStream fs;
    public StreamWriter w;
    public FileStream fs2;
    public StreamWriter w2;
    public StreamReader r;
    public InventoryList _InventoryList;
    public ItemObjData _itemObjData;
    public ObjectManager _objectManager;
    public string[] road_List;
    public int line;
    public ChestManager TargetChest;
    public GameObject image;
    public GameObject player;

    public string WorldName_;
    void Start()
    {
        if (WorldName.text == null)
        {
            SceneManager.LoadScene("start");
            WorldName.text = "a";

        }
        WorldName_ = WorldName.text;
        image.SetActive(false);
        //string path = Application.persistentDataPath + "file.txt";
        //File.WriteAllText(path, "hoge");
        if (WorldName.road == true)
        {
            road();
        }

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
            //fs = new FileStream("FileManager.txt", FileMode.Append);
            //w = new StreamWriter(fs); ;
            //w.Write(WorldName_);
            //w.Close();
            //fs.Close();
            fs2 = new FileStream("save/FileManager.txt", FileMode.OpenOrCreate);
            w2 = new StreamWriter(fs);
            w2.Write("\n" + WorldName_);
            w2.Close();
            fs2.Close();
            fs2 = null;
            w2 = null;


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

        fs = new FileStream("save/" + WorldName_ + "/file.txt", FileMode.OpenOrCreate);
        w = new StreamWriter(fs);

        w.Write("PlayerPosition");
        write(player.transform.position.x.ToString());
        write(player.transform.position.y.ToString());
        write(player.transform.position.z.ToString());
        write(player.transform.eulerAngles.y.ToString());
        write("PlayerData");
        foreach (string a in _InventoryList.name_)
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
        road_List = File.ReadAllLines("save/" + WorldName_ + "/file.txt");
        int step = -1;
        _InventoryList.name_.Clear();
        _InventoryList.count.Clear();
        _InventoryList.obj.Clear();
        _InventoryList.number.Clear();
        _objectManager.clear();
        //Debug.Log(_objectManager.obj.Count);
        foreach (string a in road_List)
        {
            if (a == "PlayerPosition" && step == -1)
            {
                Vector3 vector = new Vector3(float.Parse(road_List[1]), float.Parse(road_List[2]), float.Parse(road_List[3]));
                player.transform.position = vector;
                Vector3 quaternion = player.transform.eulerAngles;
                quaternion.y = float.Parse(road_List[4]);
                player.transform.eulerAngles = quaternion;
            }
            //else if(a != "PlayerPosition" && step == -1)
            //{
            //    continue;
            //}





            if (a == "PlayerData")
            {
                step = 0;
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
                    _InventoryList.name_.Add(a);
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
                        f.GetComponent<WorldObject>().List = true;
                        f.GetComponent<WorldObject>().ListNumber = _objectManager.obj.Count;
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
