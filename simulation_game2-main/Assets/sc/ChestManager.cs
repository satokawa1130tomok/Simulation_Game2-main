using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChestManager : MonoBehaviour
{
    public List<string> ListName;
    public List<int> ListCount;
    public List<GameObject> ListObj;

    public List<GameObject> but;

    public GameObject CloneButton;
    public GameObject content;

    public GameObject SecoundInventoy;
    public player2 _player2;
    public IncentoryCreate _inventoryCrate;
    public InventoryList _inventoryList;
    public bool a;
    public Animator anim;
    public bool open; public InputSystem _gameInputs;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        CloneButton = ObjectManager._om.CloneButton;
        content = ObjectManager._om.content;
        SecoundInventoy = ObjectManager._om.SecoundInventoy;
        _player2 = ObjectManager._om._player2;
        _inventoryCrate = ObjectManager._om._inventoryCrate;
        _inventoryList = ObjectManager._om._inventoryList;
        _gameInputs = new InputSystem();
        _gameInputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {


        if (_gameInputs.Player.inventory.WasPressedThisFrame())
        {
            if (SecoundInventoy.activeSelf == true)
            {
                bool a = false;
                Chset(a);

                CameraControll.active_camera = true;
            }
        }
        if (a)
        {
            if (!_gameInputs.Player.inventory.WasPressedThisFrame())
            {
                _player2.inventoy__ = true;
                a = false;

            }
        }
        //Debug.Log(open);
        anim.SetBool("open", open);
    }

    public void Chset(bool check)
    {

        WorldObject w = this.GetComponent<WorldObject>();
        //Debug.Log(MyNumebr);
        //if (w.number == MyNumebr)
        // {
        //Debug.Log("a");

        _player2.inventoy.SetActive(check);
        SecoundInventoy.SetActive(check);
        open = check;
        // Debug.Log("b");
        Cursor.visible = check;
        if (check)
        {
            _player2.inventoy__ = false;
            _player2._inventoryCreate.InventoryCreate();
            //ListCerate();
            _player2._chestManager.DestroyButton();
            _player2._chestManager.ListCerate();

            _player2.name_ = "";


        }
        else
        {

            _player2._inventoryCreate.DestroyButton();
            // DestroyButton();
            _player2._chestManager.DestroyButton();
            a = true;

            _player2.name_ = "";


        }


        // }
    }

    public void RemoveButton()
    {
        if (_player2.MaineInventory == true)
        {

            var var1 = -100;
            var1 = ListName.IndexOf(_player2.name_);
            var var2 = _inventoryList.name_.IndexOf(_player2.name_);
            // Debug.Log(var1 + _player2.name);

            if (var1 == -1)
            {
                ListName.Add(_player2.name_);
                ListCount.Add(1);
                ListObj.Add(_inventoryList.obj[var2]);

            }
            else
            {
                int i;
                i = ListCount[var1];
                i = i + 1;
                ListCount[var1] = i;
            }
            _player2._chestManager.DestroyButton();
            _player2._chestManager.ListCerate();
            _player2._chestManager.RemoveInventoryList(_player2.name_);

            _player2.name_ = "";
        }
    }
    public void AddButton()
    {
        if (_player2.MaineInventory == false)
        {
          
            var var1 = -100;
            var1 = _inventoryList.name_.IndexOf(_player2.name_);
            var var2 = ListName.IndexOf(_player2.name_);
            // Debug.Log(var1 + _player2.name);

            if (var1 == -1)
            {
                _inventoryList.name_.Add(_player2.name_);
                _inventoryList.count.Add(1);
                _inventoryList.obj.Add(ListObj[var2]);
            }
            else
            {
                int i;
                i = _inventoryList.count[var1];
                i = i + 1;
                _inventoryList.count[var1] = i;
            }
            _inventoryCrate.DestroyButton();
            _inventoryCrate.InventoryCreate();
            RemoveChestList(_player2.name_);
            DestroyButton();
            ListCerate();

            _player2.name_ = "";
        }
    }
    public void RemoveInventoryList(string a)
    {
        // Debug.Log(a);
        var var1 = -100;
        var1 = ListName.IndexOf(a);
        int int1 = _inventoryList.count[var1];
        if (int1 == 1)
        {
            _inventoryList.name_.RemoveAt(var1);
            _inventoryList.count.RemoveAt(var1);
            _inventoryList.obj.RemoveAt(var1);

        }
        else
        {
            int i;
            i = _inventoryList.count[var1];
            i = i - 1;
            _inventoryList.count[var1] = i;
        }
        _inventoryCrate.DestroyButton();
        _inventoryCrate.InventoryCreate();

        _player2.name_ = "";
    }
    public void RemoveChestList(string a)
    {
        //Debug.Log(a);
        var var1 = -100;
        var1 = _inventoryList.name_.IndexOf(a);
        int int1 = ListCount[var1];
        if (int1 == 1)
        {
            ListName.RemoveAt(var1);
            ListCount.RemoveAt(var1);
            ListObj.RemoveAt(var1);

        }
        else
        {
            int i;
            i = ListCount[var1];
            i = i - 1;
            ListCount[var1] = i;
        }
        DestroyButton();
        ListCerate();

        _player2.name_ = "";
    }
    public void ListCerate()
    {

        // Debug.Log(string.Join(",", but.Select(but => but.ToString())));


        //    int i = 1;
        //    foreach (string a in _InventoryList.name)
        //    {
        //        RectTransform posi = CloneButton.GetComponent<RectTransform>();
        //        CloneButton = (Button)Instantiate(CloneButton_) as Button;//(i+10+interval)*-1
        //        CloneButton.transform.parent = content.transform;
        //        CloneButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (-(i + 1) * 30));

        //        text = CloneButton.gameObject.transform.FindChild("clonetext").gameObject;
        //        Text _text = text.gameObject.GetComponent<Text>();
        //        int b;
        //        b = _InventoryList.count[i - 1];
        //        _text.text = a + " Å~" + b;
        //        i++;
        //        but.Add(CloneButton);

        //        buttanData data = CloneButton.GetComponent<buttanData>();
        //        data.name = a;
        //        data.count = b;
        //        data.obj = _InventoryList.obj[i];


        //    }
        but.Clear();
        int i = 0;
        int C = _player2._chestManager.ListName.Count;
        //Debug.Log("A");
        C = C - 1;

        if (ListName.Count != 100)
        {
            for (i = 0; i < C + 1; i++)
            {
                // Debug.Log(i);

                GameObject cloneButton = Instantiate(CloneButton) as GameObject;
                cloneButton.transform.SetParent(content.transform, false);
                cloneButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(i + 1) * 60);

                GameObject textObj = cloneButton.transform.Find("clonetext").gameObject;
                Text _text = textObj.GetComponent<Text>();

                string a = _player2._chestManager.ListName[i];
                int b = _player2._chestManager.ListCount[i];
                _text.text = a + " Å~" + b;

                but.Add(cloneButton);
                cloneButton.SetActive(true);


                buttanData data = cloneButton.GetComponent<buttanData>();
                data.number = i;
                data.name_ = a;
                data.ButtonPo = false;

                // data.obj = _InventoryList.obj[i];
                // Debug.Log(i + "  " + C);


            }

        }
    }
    public void DestroyButton()
    {
        //// Debug.Log("1  " +(string.Join(",", but.Select(but => but.ToString()))));

        foreach (GameObject a in but)
        {
            Destroy(a.gameObject);

        }
        //   Debug.Log("2  "+(string.Join(",", but.Select(but => but.ToString()))));
    }   //but = new List&It;string&gt();
}
