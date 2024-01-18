using UnityEngine;
public class Have : MonoBehaviour
{
    public ObjectManager _objectManager;
    public GameObject obj;
    public int have;
    public GameObject RayObject;
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
    public static bool removeItem_;
    private GameObject child;
    public InputSystem _gameInputs;
    public InventoryList _InventoryList;
    public ObjectManager _ObjectManager;
    void Start()
    {
        have = -1;
        _gameInputs = new InputSystem();
        _gameInputs.Enable();
    }
    public void point()
    {
        if (ray.bool_ && Ray_._hit != null && !player2_.inventoy.activeSelf && CloneObj != null)
        {   //íuÇØÇÈèÛë‘
            CloneObj.SetActive(true);

            //if (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y") != 0)
            // {
            // Debug.Log(ray.);
            CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
            //  }
            ground = true;

            worldAngle = CloneObj.transform.eulerAngles;
            if (_gameInputs.Player.left.WasPressedThisFrame())
            {
                worldAngle.y += 45.0f;
            }
            if (_gameInputs.Player.right.WasPressedThisFrame())
            {
                worldAngle.y -= 45.0f;
            }
            if (_gameInputs.Player.up.WasPressedThisFrame())
            {
                worldAngle.x += 45.0f;
            }
            if (_gameInputs.Player.Down.WasPressedThisFrame())
            {
                worldAngle.x -= 45.0f;
            }

            CloneObj.transform.eulerAngles = worldAngle; // âÒì]äpìxÇê›íË

        }
        else if (ray.bool_ && Ray_._hit == null && !player2_.inventoy.activeSelf)
        { //íàÇ…ïÇÇ¢ÇƒÇ¢ÇÈèÛë‘
            ground = false;
            CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
        }
        else if (!ray.bool_ && Ray_._hit != null && player2_.inventoy.activeSelf)
        { //ï\é¶Ç≥ÇÍÇ»Ç¢éû
            CloneObj.SetActive(false);
        }
        if (_gameInputs.Player.cancel.WasPressedThisFrame())
        { //ÉLÉÉÉìÉZÉãÇ™âüÇ≥ÇÍÇΩ
            Destroy(CloneObj);
            have = 1;
        }
        if (_gameInputs.Player.Installation.WasReleasedThisFrame())
        {
            r = true;
        }
        if (_gameInputs.Player.Installation.WasPressedThisFrame() && r && ground)
        {
            Destroy(CloneObj);
            have = 1;
            CloneObj_(player2.obj);
            CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1.5f, ray.HitPosition.z);
            CloneObj.transform.eulerAngles = worldAngle;
            _InventoryList.RemoveItem(player2_.name_);
            if (removeItem_)
            {
                Destroy(obj);
                player2.anim.SetBool("have", false);
                have = -1;
            }
        }

    }
    void Update()
    {
        if ((have == 0 && CloneObj != null && !player2_.inventoy.activeSelf)) { point(); }
        if (have == 1 && _gameInputs.Player.cancel.WasPressedThisFrame())
        {
            Destroy(obj);
            have = 0;
            player2.anim.SetBool("have", false);
            player2.HaveTool = "";
        }
        if (have == 1 && _gameInputs.Player.Installation.WasPressedThisFrame())
        { //éùÇ¡ÇƒÇ¢ÇÈèÛë‘
            have = 0;
            CloneObj_(player2.obj);
            Destroy(CloneObj.GetComponent<Rigidbody>());
            Destroy(CloneObj.GetComponent<BoxCollider>());
            Destroy(CloneObj.GetComponent<SphereCollider>());
            Destroy(CloneObj.GetComponent<WorldObject>());
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
                }
            }
        }
    }
    public void OnClick()
    {
        if (obj != null)
        {
            Destroy(obj);
        }
        if (player2.obj != null)
        {
            player2.anim.SetBool("have", true);
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
            myTransform.localEulerAngles = localAngle; // âÒì]äpìxÇê›íË
            CloneObj.transform.localPosition = new Vector3(0.04f, -0.0053f, -0.01f);
            CloneObj.transform.localScale = scale / 70;
            obj = CloneObj;
            if (player2.obj.GetComponent<WorldObject>().ObjectType == "T")
            {
                player2.HaveTool = player2.obj.GetComponent<WorldObject>().ToolType;
            }
            have = 1;
        }
        Debug.LogError("HaveItemError");
    }
    void CloneObj_(GameObject clone)
    {
        CloneObj = Instantiate(clone);
    }


}