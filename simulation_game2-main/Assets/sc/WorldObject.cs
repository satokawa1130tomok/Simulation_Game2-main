using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class WorldObject : MonoBehaviour
{

    public string _name;
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int ItemObjDataNumber_;
    public int ItemObjDataNumber
    {
        get { return ItemObjDataNumber_; }
        set { ItemObjDataNumber_ = value; }
    }

    public string ObjectType;
    public int ResourceObjNumber;
    public int ResourceObjCount;
    public char ResourceObjToolType;
    public GameObject ResourceObject;
    public int ResourceCount;
    public int RespawnTime;
    private float Time;
    private bool Respawn;
    private int Initial;
    public GameObject CloneObject;
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
    public ItemObjData ItemObjData;
    public int number_;
     public int ListNumber
    {
        get { return number_; }
        set { number_ = value; }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        Respawn = false;
        Initial = ResourceCount;
        this.GetComponent<Rigidbody>().isKinematic = false;
        // DontDestroyOnLoad(this.gameObject);
        // Debug.Log(objectType);
        ItemObjData = player2.itemObjData_;
        CloneObject = ItemObjData.obj[ItemObjDataNumber];
        _objectManager = player2.objectManager_;
        if(ObjectType == "R")
        {
            ResourceObject = ItemObjData.obj[ResourceObjNumber];
        }
       

        //if (type == "I")
        //{
        //    Itemdata itemdata = this.GetComponent<Itemdata>();
        //    ObjNumber = itemdata.number;
        //}
        //if (type == "T")
        //{
        //    ToolData toolData = this.GetComponent<ToolData>();
        //    ObjNumber = toolData.number;
        //}
        //if (type == "C")
        //{
        //    chestdata ChestData = this.GetComponent<chestdata>();
        //    ObjNumber = ChestData.number;
        //}
        Transform transform = this.GetComponent<Transform>();
        position = transform.position;
        rotation = this.transform.eulerAngles;
        ListNumber = _objectManager.add(ItemObjDataNumber, position, rotation, this.gameObject);
        ListNumber -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Initial != 0 && ResourceCount == 0)
        {
            Respawn = true;
            Time = 0f;
            ObjectType = "";
        }
        if (Respawn)
        {
            Time += 0.01f;
            if(Time == RespawnTime)
            {
                ObjectType = "R";
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Ground" &&Å@ObjectType == "H")
        {
            Destroy(this.GetComponent<Rigidbody>());
        }
    }
}
