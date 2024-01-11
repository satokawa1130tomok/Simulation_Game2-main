using UnityEngine;

public class ResourceData : MonoBehaviour
{
    public string _resource_name;
    public string resource_name
    {
        get { return _resource_name; }
        set { _resource_name = value; }
    }
    public string _item_name;
    public string itemname
    {
        get { return _item_name; }
        set { _item_name = value; }
    }
    public int _quantity;
    public int quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }
    public GameObject _Resourceobj;
    public GameObject Resourceobj
    {
        get { return _Resourceobj; }
        set { _Resourceobj = value; }
    }
    public GameObject _Itemobj;
    public GameObject Itemobj
    {
        get { return _Itemobj; }
        set { _Itemobj = value; }
    }
    public char _Tooltype;
    public char Tooltype
    {
        get { return _Tooltype; }
        set { _Tooltype = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
