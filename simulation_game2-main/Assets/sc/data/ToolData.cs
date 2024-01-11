using UnityEngine;

public class ToolData : MonoBehaviour
{
    public string _name;
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public char _type;
    public char type
    {
        get { return _type; }
        set { _type = value; }
    }
    public GameObject _Toolobj;
    public GameObject Toolobj
    {
        get { return _Toolobj; }
        set { _Toolobj = value; }
    }
    public int _number;
    public int number
    {
        get { return _number; }
        set { _number = value; }
    }
    public ItemObjData itemdata;



    // Start is called before the first frame update
    void Start()
    {
        _Toolobj = itemdata.obj[number];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
