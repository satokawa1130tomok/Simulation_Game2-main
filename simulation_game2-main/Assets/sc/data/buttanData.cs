using UnityEngine;
using UnityEngine.UI;

public class buttanData : MonoBehaviour
{
    public int _number;
    public int number
    {
        get { return _number; }
        set { _number = value; }
    }
    public string _name;
    public string name_
    {
        get { return _name; }
        set { _name = value; }
    }
    public GameObject obj_;
    public GameObject obj
    {
        get { return obj_; }
        set { obj_ = value; }
    }

    public GameObject thisButton;
    public static bool a;

    public Button DropButton;
    public player2 _player2;
    public bool ButtonPo_;
    public bool ButtonPo
    {
        get { return ButtonPo_; }
        set { ButtonPo_ = value; }
    }
    public bool Former = false;




    // Start is called before the first frame update
    void Start()
    {

        a = false;


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player2.a);
        //if (Input.GetKeyDown(KeyCode.E) && player2.a)
        //{
        //    Debug.Log("buttondata");
        //    Debug.Log(this.gameObject);
        //    Destroy(thisButton);
        //    a = true;
        //}
        if (Former)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
        if (_player2.name_ == name_)
        {
            Outline a = this.GetComponent<Outline>();
            a.enabled = true;
        }
        else
        {
            Outline a = this.GetComponent<Outline>();
            a.enabled = false;
        }
    }
    //public void destroybutton()
    //{
    //    Debug.Log("buttondata");
    //    Debug.Log(this.gameObject);
    //    Destroy(this.gameObject);
    //}
    public void OnClick()
    {
        _player2.name_ = name_;
        _player2.MaineInventory = ButtonPo;
        _player2.No = number;
        player2.obj = obj;
    }


}



