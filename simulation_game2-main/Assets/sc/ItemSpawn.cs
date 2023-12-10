using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public List<int> CloneObjectNumber;//クローンするobj
    public List<int> Clone;//一度にクローンする数
    public List<int> Execution;//実行する数
    public ObjectManager _ObjectManager;
    public ItemObjData _itemObjData;
    public List<int> number;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        number = _ObjectManager.number;

        int int1 = 0;
        foreach (int a in CloneObjectNumber)
        {
            int count = 0;
            foreach (int b in number)
            {
                if (a == b)
                {
                    count++;
                }
            }


            if (count <= Execution[int1])
            {

                // Debug.Log(Clone[int1]);
                for (int i = 0; i <= Clone[int1]; i++)
                {
                    int x = Random.Range(300, 450);
                    int z = Random.Range(-20, 100);
                    int y = 10;
                    Vector3 vector3 = new Vector3(x, y, z);
                    GameObject CloneObj = Instantiate(_itemObjData.obj[a], vector3, Quaternion.identity);
                    Adjustment ad = CloneObj.AddComponent<Adjustment>();


                }
            }
            int1++;
        }
    }





}

