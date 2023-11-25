using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class WorldObject : MonoBehaviour
{
    //↓全部入力
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
    //↓resourceとC必須
    public int ResourceObjNumber;
    public int ResourceObjCount;
    public char ResourceObjToolType;
    public int ResourceCount;
    public int RespawnTime; 
    //↓入力不要
    public GameObject ResourceObject;
    public float Time_;
    private bool Respawn;
    private int Initial;
    public int InitialCount;
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
        InitialCount = ResourceCount;
        Respawn = false;
        Initial = ResourceCount;
       if(ObjectType != "L")
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
        // DontDestroyOnLoad(this.gameObject);
        // Debug.Log(objectType);
        ItemObjData = player2.itemObjData_;
        CloneObject = ItemObjData.obj[ItemObjDataNumber];
        _objectManager = player2.objectManager_;
        if(ObjectType == "R" || ObjectType == "L")
        {
         //   Debug.Log(ItemObjData.obj[ResourceObjNumber]);
            ResourceObject = ItemObjData.obj[ResourceObjNumber];
         //   Debug.Log(ResourceObject);
        }
      //  Debug.Log(ObjectType);

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
        if(ObjectType == "R" || ObjectType == "NR")
        {
            if (Initial != 0 && ResourceCount == 0 && !Respawn)
            {
                Respawn = true;
                Time_ = 0f;
                ObjectType = "NR";
                ResourceCount = InitialCount;
            }

            if (Respawn)
            {
                //Debug.Log(Time_ + Time.deltaTime);
                Time_ += Time.deltaTime;
                if (Time_ >= RespawnTime)
                {
                    ObjectType = "R";
                    Respawn = false;

                }
            }
        }
        if(ObjectType == "L")
        {
            Vector3 vector3 = this.transform.localScale;
            vector3.y = ResourceCount;
            this.transform.localScale = vector3;

            if (Initial != 0 && ResourceCount < InitialCount && !Respawn)
            {
                Respawn = true;
                Time_ = 0f;
               
            }

            if (Respawn)
            {
                //Debug.Log(Time_ + Time.deltaTime);
                Time_ += Time.deltaTime;
                if (Time_ >= RespawnTime)
                {
                    Respawn = false;
                    ResourceCount++;


                }
            }
        }

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Ground" &&　ObjectType == "H")
        {
            Destroy(this.GetComponent<Rigidbody>());
        }
    }
}
