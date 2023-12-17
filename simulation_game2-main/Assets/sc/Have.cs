using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Have : MonoBehaviour
{
    public ObjectManager objectManager;
    public GameObject obj;
    public int have = -1;
    public GameObject rayobj;
    public Material green;
    public Material red;
    private GameObject CloneObj;
    public player2 player2_;
    public Ray_ ray;

    public Transform[] children;
    private bool r;
    private bool ground;
    private bool mat;
    private Vector3 worldAngle;
    public CraftManager craftManager;
    public RecipieButton recipie;
    private bool removeItem_;
    private GameObject child;
    public InputSystem _gameInputs;
    public InventoryList _InventoryList;
    // Start is called before the first frame update
    void Start()
    {
        have = -1;
        _gameInputs = new InputSystem();
        _gameInputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(have);
        // Debug.Log(r);
        if (have == 1 && _gameInputs.Player.cancel.WasPressedThisFrame())
        {
            Destroy(obj);
            have = 0;
            player2.anim.SetBool("have", false);
        }
        if (have == 1 && _gameInputs.Player.Installation.WasPressedThisFrame())
        {
            have = 0;
            //Debug.Log(CloneObj);
            CloneObj_(player2.obj);
            Destroy(CloneObj.GetComponent<Rigidbody>());
            Destroy(CloneObj.GetComponent<BoxCollider>());
            Destroy(CloneObj.GetComponent<SphereCollider>());
            Destroy(CloneObj.GetComponent<WorldObject>());
            //Debug.Log(ray.HitPosition);
            CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
            r = false;

            for (int i = 0; child == null; i++)
            {
                child = CloneObj.transform.GetChild(i).gameObject;
                if (child != null)
                {

                    Destroy(child.GetComponent<Rigidbody>());
                    Destroy(child.GetComponent<BoxCollider>());
                    Destroy(child.GetComponent<SphereCollider>());
                    //Destroy(child.gameObject.GetComponent<MeshRenderer>());
                    //child.gameObject.AddComponent<MeshRenderer>();
                }
            }






            //CloneObj.GetComponent<Material>().mainTexture
            //   CloneObj.AddComponent<MeshRenderer>();
            MaterialCollar(true);
            MaterialCollar(false);

        }
        //Debug.Log(have + "" + CloneObj != null + "" + !player2_.inventoy.activeSelf);
        if (have == 0 && CloneObj != null && !player2_.inventoy.activeSelf)
        {
            if (_gameInputs.Player.Installation.WasPressedThisFrame())
            {
                r = true;
            }
            if (_gameInputs.Player.Installation.WasPressedThisFrame() && r && ground)
            {
                Destroy(CloneObj);
                have = 1;
                CloneObj_(player2.obj);
                CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
                CloneObj.transform.eulerAngles = worldAngle;
                CloneObj = null;
                RemoveItem(player2_.name_);
                if (removeItem_)
                {
                    Destroy(obj);
                    player2.anim.SetBool("have", false);
                    have = -1;
                }
            }
            //Debug.Log("a");
            //Vector3 direction = transform.right;
            //Vector3 origin = rayobj.transform.position;
            //int maxDistance = 100;
            //Ray ray = new Ray(origin, direction);
            //Debug.DrawRay(ray.origin, ray.direction * maxDistance , Color.red);
            //RaycastHit hit;
            //// レイキャストを実行し、当たった場合にのみ処理を行う
            //if (Physics.Raycast(ray, out hit, maxDistance))
            //{
            //    Debug.Log("b");
            //    // ヒットした点の座標を取得
            //    Vector3 hitPoint = hit.point;

            //    // CloneObjをインスタンス化し、当たった点の座標に配置
            //    Debug.Log(hitPoint);
            //    CloneObj.transform.position = hitPoint;
            //    CloneObj.GetComponent<MeshRenderer>().material = mat;
            //}
            // Debug.Log(ray.bool_);
            // Debug.Log(ray.bool_ + "" + Ray_._hit != null + "" + !player2_.inventoy.activeSelf);
            if (ray.bool_ && Ray_._hit != null && !player2_.inventoy.activeSelf && CloneObj != null)
            {
                CloneObj.SetActive(true);

                //if (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y") != 0)
                // {
                // Debug.Log(ray.);
                CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
                //  }
                ground = true;
                MaterialCollar(true);

                worldAngle = CloneObj.transform.eulerAngles;
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    worldAngle.y += 45.0f;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    worldAngle.y -= 45.0f;
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    worldAngle.x += 45.0f;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    worldAngle.x -= 45.0f;
                }

                CloneObj.transform.eulerAngles = worldAngle; // 回転角度を設定

            }
            else if (ray.bool_ && Ray_._hit == null && !player2_.inventoy.activeSelf)
            {
                ground = false;
                MaterialCollar(false);
                CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);

            }
            else if (!ray.bool_ && Ray_._hit != null && player2_.inventoy.activeSelf)
            {
                CloneObj.SetActive(false);
                //CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
            }
            if (_gameInputs.Player.cancel.WasPressedThisFrame())
            {
                Destroy(CloneObj);
                have = 1;
            }

            // CloneObj.GetComponent<MeshRenderer>().material = mat;
        }


    }


    public void OnClick()
    {
        player2.anim.SetBool("have", true);
        if (obj != null)
        {
            Destroy(obj);
        }

        CloneObj_(player2.obj);
        Destroy(CloneObj.GetComponent<Rigidbody>());
        Destroy(CloneObj.GetComponent<BoxCollider>());
        Destroy(CloneObj.GetComponent<WorldObject>());
        Transform myTransform = CloneObj.transform;
        Vector3 scale = CloneObj.transform.localScale;
        CloneObj.gameObject.transform.parent = GameObject.FindWithTag("HavePosition").transform;
        Vector3 localAngle = myTransform.localEulerAngles;
        localAngle.x = 0.0f;
        localAngle.y = 0.0f;
        localAngle.z = -90.0f;
        myTransform.localEulerAngles = localAngle; // 回転角度を設定
                                                   //  Debug.Log(CloneObj.gameObject.transform.lossyScale.x + "          " + CloneObj.gameObject.transform.lossyScale.x / 2);
        CloneObj.transform.localPosition = new Vector3(0.04f, -0.0053f, -0.01f);
        CloneObj.transform.localScale = scale / 70;
        obj = CloneObj;
        if (player2.obj.GetComponent<WorldObject>().ObjectType == "T")
        {
            player2.HaveTool = player2.obj.GetComponent<WorldObject>().ResourceObjToolType;
        }
        
       
        have = 1;


        //   Debug.Log(player2.obj);

    }
    void CloneObj_(GameObject clone)
    {


        CloneObj = Instantiate(clone);

    }
    public void MaterialCollar(bool b)
    {
        //if (b != mat)
        //{
        //    if (b)
        //    {
        //        CloneObj.GetComponent<MeshRenderer>().material = green;
        //        children = new Transform[CloneObj.transform.childCount];
        //        //children = new Transform[CloneObj.transform.childCount];
        //        for (int i = 0; i < CloneObj.transform.childCount; i++)
        //        {
        //            //   Material[] ma;
        //            // ma[0]
        //            // children[i].GetComponent<MeshRenderer>().materials = green;
        //            GameObject a = children[i].gameObject;
        //            a.GetComponent<MeshRenderer>().material = green;

        //        }
        //    }
        //    if (!b)
        //    {
        //        //children = new Transform[CloneObj.transform.childCount];
        //        children = new Transform[CloneObj.transform.childCount];
        //        CloneObj.GetComponent<MeshRenderer>().material = red;
        //        for (int i = 0; i < CloneObj.transform.childCount; i++)
        //        {
        //            //children[i].GetComponent<MeshRenderer>().materials = null;
        //            GameObject a = children[i].gameObject;
        //            a.GetComponent<MeshRenderer>().material = red;
        //            //  children[i].GetComponent<MeshRenderer>().materials[1] = red;

        //        }
        //    }
        //    mat = b;



        //}
    }
    public void RemoveItem(string name)
    {


        var var_ = recipie.inventoryList.count[recipie.inventoryList.name_.IndexOf(name)];
        recipie.inventoryList.count[recipie.inventoryList.name_.IndexOf(name)] -= 1;
        if (recipie.inventoryList.count[recipie.inventoryList.name_.IndexOf(name)] == 0)
        {
            int a = recipie.inventoryList.name_.IndexOf(name);
            recipie.inventoryList.name_.RemoveAt(a);
            recipie.inventoryList.count.RemoveAt(a);
            recipie.inventoryList.obj.RemoveAt(a);
            removeItem_ = true;

        }
        else
            removeItem_ = false;


    }


}