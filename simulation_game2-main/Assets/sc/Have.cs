using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(have);
        Debug.Log(r);
        if (have == 1 && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(obj);
            have = 0;
            player2.anim.SetBool("have", false);
        }
        if (have == 1 && Input.GetKeyDown(KeyCode.R))
        {
            have = 0;
            //Debug.Log(CloneObj);
            CloneObj_(player2.obj);
            Destroy(CloneObj.GetComponent<Rigidbody>());
            Destroy(CloneObj.GetComponent<BoxCollider>());
            Destroy(CloneObj.GetComponent<SphereCollider>());
            //Debug.Log(ray.HitPosition);
            CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
            r = false;


            children = new Transform[CloneObj.transform.childCount];

            // 検索方法１
            for (int i = 0; i < CloneObj.transform.childCount; i++)
            {
                children[i] = CloneObj.transform.GetChild(i);
               
                Destroy(children[i].GetComponent<Rigidbody>());
                Destroy(children[i].GetComponent<BoxCollider>());
                Destroy(children[i].GetComponent<SphereCollider>());
            }

        }
        //Debug.Log(have + "" + CloneObj != null + "" + !player2_.inventoy.activeSelf);
        if (have == 0 && CloneObj != null && !player2_.inventoy.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                r = true;
            }
            if (Input.GetKeyDown(KeyCode.R) && r && ground)
            {
                Destroy(CloneObj);
                have = 1;
                CloneObj_(player2.obj);
                CloneObj.transform.position =  new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
                CloneObj.transform.eulerAngles = worldAngle;
                CloneObj = null;
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
            if (ray.bool_ && Ray_._hit != null && !player2_.inventoy.activeSelf)
            {
                CloneObj.SetActive(true);

                //if (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y") != 0)
               // {
                    Debug.Log(Ray_._hit);
                    CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
                //  }
                ground = true;
                MaterialCollar(true);

                 worldAngle = CloneObj.transform.eulerAngles;
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    worldAngle.y += 1.0f;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    worldAngle.y -= 1.0f;
                }
                if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightShift))
                {
                    worldAngle.x += 1.0f;
                }
                if (Input.GetKey(KeyCode.DownArrow) &&!Input.GetKey(KeyCode.RightShift))
                {
                    worldAngle.x -= 1.0f;
                }
                if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightShift))
                {
                    worldAngle.z += 1.0f;
                }
                if (Input.GetKey(KeyCode.DownArrow)&& Input.GetKey(KeyCode.RightShift))
                {
                    worldAngle.z -= 1.0f;
                }
                CloneObj.transform.eulerAngles = worldAngle; // 回転角度を設定

            }
            else if( ray.bool_ && Ray_._hit == null && !player2_.inventoy.activeSelf)
            {
                ground = false;
                MaterialCollar(false) ; 
                CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);

            }
            else if (!ray.bool_ && Ray_._hit != null && player2_.inventoy.activeSelf)
            {
                CloneObj.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Z))
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
        have = 1;


    }
    void CloneObj_(GameObject clone)
    {


        CloneObj = Instantiate(clone);

    }
    public void MaterialCollar(bool b)
    {
        if(b != mat)
        {
            if (b)
            {
                //children = new Transform[CloneObj.transform.childCount];
                for (int i = 0; i < CloneObj.transform.childCount; i++)
                {
                    children[i].GetComponent<MeshRenderer>().material = green;

                }
            }
            if (!b)
            {
                //children = new Transform[CloneObj.transform.childCount];
                for (int i = 0; i < CloneObj.transform.childCount; i++)
                {
                    children[i].GetComponent<MeshRenderer>().material = red;

                }
            }
            mat = b;

            
          
        }
    }
    

}