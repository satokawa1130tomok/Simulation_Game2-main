using UnityEngine;

public class Itemdata : MonoBehaviour
{
    [SerializeField]
    public string _name;
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int _number;
    public int number
    {
        get { return _number; }
        set { _number = value; }
    }
    public GameObject _Itemobj;
    public GameObject Itemobj
    {
        get { return _Itemobj; }
        set { _Itemobj = value; }
    }
    public ItemObjData _itemObjData;



    // Start is called before the first frame update
    void Start()
    {
        //Itemobj = _itemObjData.obj[number];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
