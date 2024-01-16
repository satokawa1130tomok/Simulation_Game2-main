using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PreviewManager : MonoBehaviour
{
    public GameObject ImageObject;
    public GameObject image_;
    public GameObject UIObject;
    public bool preview;
    public player2 _player2;
    public InventoryList _inventoryList;
    public Text NameText;
    public GameObject CloneButton;
    public List<GameObject> button;
    private bool a_;
    private HouseRecipe scriptable;
    public Have _have;
    public Ray_ ray;
    public bool have;
    public GameObject CloneObj;
    public Transform[] children;
    public bool mat;
    public Material red;
    public Material green;
    public Vector3 worldAngle;
    public InputSystem _gameInputs;

    // Start is called before the first frame update
    void Start()
    {
        have = false;
        active(false);
        if (button.Count > 0)
        {
            button.Clear();
        }
        _gameInputs = new InputSystem();
        _gameInputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (have)
        {
            Have();
        }

        if (preview == true && _gameInputs.Player.home.WasPressedThisFrame())
        {
            active(false);
            Cursor.visible = false;
            CameraControll.active_camera = true;
        }
        if (a_ == true)
        {
            if (!_gameInputs.Player.home.WasPressedThisFrame())
            {
                preview = false;
                a_ = false;
            }
        }

        if (!preview && !_player2.inventoy__ && !_player2.Craft_ && _gameInputs.Player.home.WasPressedThisFrame())
        {
            Cursor.visible = true;
            active(true);
            Cursor.visible = true;
            CameraControll.active_camera = false;
        }
    }
    //SceneManager.LoadScene("preview");

    // SceneManager.LoadSceneAsync("preview", LoadSceneMode.Single);
    // SceneManager.UnloadScene("game");

    public void active(bool a)
    {
        // Debug.Log(a);
        if (a == false)
        {
            a_ = true;
        }
        if (a)
        {
            preview = a;
        }

        _player2.Preview = a;
        if (a == true)
        {
            NameText.text = "";
        }

        DestroyButton();

        ImageObject.SetActive(a);
        UIObject.SetActive(a);
    }
    public void image(Sprite texture)
    {
        Image image = image_.gameObject.GetComponent<Image>();
        image.sprite = texture;
    }
    public void Clone(HouseRecipe scriptable_)
    {
        DestroyButton();

        NameText.text = scriptable_.RecipeName;
        int int1 = 0;
        foreach (string a in scriptable_.ItemName)
        {
            Vector3 vector3 = new Vector3(260, 370 - 30 * int1, 0);
            GameObject CloneObject = Instantiate(CloneButton, vector3, Quaternion.identity);
            CloneObject.transform.parent = GameObject.Find("clone").transform;
            GameObject textObj = CloneObject.transform.Find("clonetext").gameObject;
            Text text = textObj.gameObject.GetComponent<Text>();
            int c = _inventoryList.name_.IndexOf(a);
            if (c == -1)
            {
                c = 0;
            }
            else
            {
                // Debug.Log(c + "" + int1);
                c = _inventoryList.count[c];
            }
            string b = (a + "" + scriptable_.ItemCount[int1] + "/" + c);
            text.text = b;
            button.Add(CloneObject);
            int1 += 1;
        }

        scriptable = scriptable_;
    }
    public void DestroyButton()
    {
        if (button.Count > 0)
        {
            foreach (GameObject b in button)
            {
                Destroy(b);
            }
            button.Clear();
        }
    }
    public void Craft()
    {
        int int1 = 0;
        bool HaveItem = false;
        bool check = false;
        foreach (string a in scriptable.ItemName)
        {
            HaveItem = false;
            int b = _inventoryList.name_.IndexOf(a);
            if (b == -1)
            {
                HaveItem = true;
            }
            else if (_inventoryList.count[b] < scriptable.ItemCount[int1])
            {
                //Debug.Log(_inventoryList.count[b] + "" + scriptable.ItemCount[int1]);
                HaveItem = true;
            }

            if (HaveItem)
            {
                button[int1].GetComponent<Outline>().enabled = true;
                check = true;
            }
            else
            {
                button[int1].GetComponent<Outline>().enabled = false;
            }

            int1++;
        }
        if (!check)
        {
            DestroyButton();

            ImageObject.SetActive(false);
            UIObject.SetActive(false);
            Cursor.visible = false;
            CameraControll.active_camera = true;

            player2.obj = scriptable.obj;
            have = true;
            CloneObj_(player2.obj);
            Destroy(CloneObj.GetComponent<Rigidbody>());
            Destroy(CloneObj.GetComponent<BoxCollider>());
            Destroy(CloneObj.GetComponent<SphereCollider>());

            children = new Transform[CloneObj.transform.childCount];

            // åüçıï˚ñ@ÇP
            for (int i = 0; i < CloneObj.transform.childCount; i++)
            {
                children[i] = CloneObj.transform.GetChild(i);

                Destroy(children[i].GetComponent<Rigidbody>());
                Destroy(children[i].GetComponent<BoxCollider>());
                Destroy(children[i].GetComponent<SphereCollider>());
            }
            //Debug.Log(ray.HitPosition);
            //  CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);

        }
       
    }
    public void Have()
    {
        MaterialCollar(true);
        MaterialCollar(false);
        _player2.move();
        ray.maxDistance = 50;
        CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
        float distance = 15;
        if (ray.bool_ && Ray_._hit != null && !_player2.inventoy.activeSelf && ray.distance >= distance)
        {
            MaterialCollar(true);
            CloneObj.SetActive(true);
        }
        else if (ray.bool_ && Ray_._hit == null && !_player2.inventoy.activeSelf && ray.distance >= distance)
        {
            MaterialCollar(false);
            CloneObj.SetActive(true);
        }
        else if (!_player2.inventoy.activeSelf)
        {
            CloneObj.SetActive(false);
        }
        else if (ray.distance <= distance)
        {
            CloneObj.SetActive(false);
        }

        if (_gameInputs.Player.cancel.WasPressedThisFrame())
        {
            Destroy(CloneObj);
            have = false;
            _player2.Preview = false;
            a_ = true;
            ray.maxDistance = ray.InitialValue;
        }

        if (CloneObj.activeSelf == true)
        {

            worldAngle = CloneObj.transform.eulerAngles;
            if (_gameInputs.Player.left.WasPressedThisFrame())
            {
                worldAngle.y += 22.5f;
            }
            if (_gameInputs.Player.right.WasPressedThisFrame())
            {
                worldAngle.y -= 22.5f;
            }
            //if (Input.GetKeyDown(KeyCode.UpArrow))
            //{
            //    worldAngle.x += 45.0f;
            //}
            //if (Input.GetKeyDown(KeyCode.DownArrow))
            //{
            //    worldAngle.x -= 45.0f;
            //}

            CloneObj.transform.eulerAngles = worldAngle; // âÒì]äpìxÇê›íË
        }

        if (_gameInputs.Player.Installation.WasPressedThisFrame())
        {
            Destroy(CloneObj);
            have = false;
            CloneObj_(scriptable.obj);
            CloneObj.transform.position = new Vector3(ray.HitPosition.x, ray.HitPosition.y += 1, ray.HitPosition.z);
            CloneObj.transform.eulerAngles = worldAngle;
            RemoveItem();
            _player2.Preview = false;
            a_ = true;
            ray.maxDistance = ray.InitialValue;
        }

    }
    public void RemoveItem()
    {
        int count = 0;
        foreach (string a in scriptable.ItemName)
        {
            int int1 = _inventoryList.name_.IndexOf(a);
            if (_inventoryList.count[int1] == scriptable.ItemCount[count])
            {
                _inventoryList.name_.RemoveAt(int1);
                _inventoryList.count.RemoveAt(int1);
                _inventoryList.obj.RemoveAt(int1);
                _inventoryList.number.RemoveAt(int1);
            }
            else
            {
                _inventoryList.count[int1] -= scriptable.ItemCount[count];
            }
            count++;
        }
    }
    public void CloneObj_(GameObject clone)
    {


        CloneObj = Instantiate(clone);

    }
    public void MaterialCollar(bool b)
    {
        if (b != mat)
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
