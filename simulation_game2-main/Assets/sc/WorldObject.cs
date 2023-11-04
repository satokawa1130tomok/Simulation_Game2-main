using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public int number_;
    public int number
    {
        get { return number_; }
        set { number_ = value; }
    }
    public int ObjNumber_;
    public int ObjNumber
    {
        get { return ObjNumber_; }
        set { ObjNumber_ = value; }
    }
    public Vector3 rotation_;
    public Vector3 rotation
    {
        get { return rotation_; }
        set { rotation_ = value; }
    }
    public Vector3 position_;
    public Vector3 position
    {
        get { return position_; }
        set { position_ = value; }
    }
    public ObjectManager _objectManager;
    public string type;


    // Start is called before the first frame update
    void Start()
    {


        _objectManager = player2.objectManager_;
        if (type == "I")
        {
            Itemdata itemdata = this.GetComponent<Itemdata>();
            ObjNumber = itemdata.number;
        }
        if (type == "T")
        {
            ToolData toolData = this.GetComponent<ToolData>();
            ObjNumber = toolData.number;
        }
        if (type == "C")
        {
            chestdata ChestData = this.GetComponent<chestdata>();
            ObjNumber = ChestData.number;
        }
        Transform transform = this.GetComponent<Transform>();
        position = transform.position;
        rotation = this.transform.eulerAngles;
        number = _objectManager.add(ObjNumber, position, rotation, this.gameObject);
        number -= 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
