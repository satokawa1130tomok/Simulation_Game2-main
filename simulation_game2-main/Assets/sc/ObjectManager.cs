using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public List<GameObject> obj;
    public List<GameObject> obj2;
    public List<int> number;
    public List<float> position_x;
    public List<float> position_y;
    public List<float> position_z;
    public List<float> rotation_x;
    public List<float> rotation_y;
    public List<float> rotation_z;
    public List<int> invalid;

    public GameObject CloneButton;
    public GameObject content;

    public GameObject SecoundInventoy;
    public player2 _player2;
    public IncentoryCreate _inventoryCrate;
    public InventoryList _inventoryList;

    public static ObjectManager _om;
    public ObjectManager objectManager;
    public ItemSpawn itemSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _om = objectManager;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int add(int n, Vector3 v, Vector3 q, GameObject g)
    {
        // Debug.Log("a");
        number.Add(n);
        position_x.Add(v.x);
        position_y.Add(v.y);
        position_z.Add(v.z);
        rotation_x.Add(q.x);
        rotation_y.Add(q.y);
        rotation_z.Add(q.z);
        obj.Add(g);
        return number.Count;
    }
    public void clear()
    {
        number.Clear();
        position_x.Clear();
        position_y.Clear();
        position_z.Clear();
        rotation_x.Clear();
        rotation_y.Clear();
        rotation_z.Clear();
        foreach (GameObject g in obj)
        {
            Destroy(g);
        }
        obj.Clear();
    }
    public void clearat(int x)
    {

        position_x.RemoveAt(x);
        position_y.RemoveAt(x);
        position_z.RemoveAt(x);
        rotation_x.RemoveAt(x);
        rotation_y.RemoveAt(x);
        rotation_z.RemoveAt(x);
        obj.RemoveAt(x);
        foreach (GameObject a in obj)
        {
            obj2.Add(a);
        }
        number.RemoveAt(x);
        int int1 = 0;
        obj.Clear();
        foreach (GameObject a in obj2)
        {
            //Debug.Log(int1);
            obj.Add(a);
            a.GetComponent<WorldObject>().ListNumber = int1;
            int1++;
        }
        obj2.Clear();

    }

}
