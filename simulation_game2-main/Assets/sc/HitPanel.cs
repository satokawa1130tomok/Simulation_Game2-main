using UnityEngine;
using TMPro;
public class HitPanel : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI text;
    public InventoryList _InventoryList;
    public HaveTool _HaveTool;
    public ErrorMessage _ErrorMessage;
    public player2 player2_;
    public ChestManager _chestManager;
    public string HitText;
    public Have have_;
    public RecipieButton _recipieButton;
    public PreviewManager _previewManager;
    public InputSystem _gameInputs;
    // Start is called before the first frame update
    void Start()
    {
        _gameInputs = new InputSystem();
        _gameInputs.Enable();
    }
    public void pickUp()
    {
        Ray_.a = 0;
        WorldObject w = Ray_._hit.GetComponent<WorldObject>();
        w._objectManager.clearat(w.ListNumber);
        Destroy(Ray_._hit);
    }
    // Update is called once per frame
    void Update()
    {
        if (player2_.inventoy.activeSelf == false && Ray_._hit != null && have_.have != 0 && !_previewManager.have)
        {
            WorldObject wdata = Ray_._hit.gameObject.GetComponent<WorldObject>();
            if (wdata != null)
            {
                if (Ray_.a == 1)//tag == item の時
                {
                    Panel.SetActive(true);
                    text.text = wdata.name_;
                    HitText = wdata.name_;
                    if (_gameInputs.Player.pickUp.WasPressedThisFrame())
                    {
                        _InventoryList.AddItem(wdata.name_, 1, wdata.CloneObject, wdata.ListNumber);
                        pickUp();
                    }
                }
                else if (Ray_.a == 2)//tga == resource　の時
                {
                    Panel.SetActive(true);
                    int i = 0;
                    int ListNumber = 0;
                    WorldObject RRdata = null;
                    foreach (string a in wdata.ResourceObjToolType)
                    {
                        if (player2.HaveTool == a)
                        {
                            RRdata = wdata.ResourceObject[i].gameObject.GetComponent<WorldObject>();
                            ListNumber = i;
                        }
                        i++;
                    }
                    text.text = (wdata.name_);
                    HitText = (wdata.name_);
                    if (_gameInputs.Player.pickUp.WasPressedThisFrame())
                    {

                        if (RRdata != null)
                        {
                            _InventoryList.AddItem(RRdata.name_, wdata.ResourceObjCount[ListNumber], RRdata.CloneObject, RRdata.ItemObjDataNumber);
                            if (wdata.ResourceCount != 0) { wdata.ResourceCount--; }
                        }
                        else { _ErrorMessage._ErrorMessage("tool do not much"); }
                    }
                }
                else if (Ray_.a == 6)//tga == resourceクールタイムの時
                {
                    Panel.SetActive(true);
                    float a = wdata.RespawnTime - wdata.Time_;
                    string b = a.ToString("f2");
                    text.text = (b + "秒後にとれます");
                    HitText = (b + "秒後にとれます");

                }
                else if (Ray_.a == 4)//tag == chestの時
                {
                    Panel.SetActive(true);
                    text.text = wdata.name_;
                    HitText = wdata.name_;
                    if (_gameInputs.Player.pickUp.WasPressedThisFrame())
                    {
                        bool a = true;
                        _chestManager = Ray_._hit.GetComponent<ChestManager>();
                        player2_._chestManager = _chestManager;
                        _chestManager.Chset(a);//chestリストを表示
                        Ray_.a = 0;
                        Ray_._hit = null;
                        CameraControll.active_camera = false;
                        HitText = "";
                    }
                }
                else if (Ray_.a == 5)//cr
                {
                    Panel.SetActive(true);
                    text.text = wdata.name_;
                    HitText = wdata.name_;
                    if (_gameInputs.Player.pickUp.WasPressedThisFrame() && _gameInputs.Player.shift.WasPressedThisFrame())
                    {
                        _InventoryList.AddItem(wdata.name_, 1, wdata.CloneObject, wdata.ListNumber);
                        pickUp();
                    }
                    if (_gameInputs.Player.pickUp.WasPressedThisFrame() && !_gameInputs.Player.shift.WasPressedThisFrame())
                    {
                        player2_.Craft_ = true;
                        player2_.Craft.SetActive(true);
                        player2_.Recipe.SetActive(false);
                        if (player2_._recipeButton.CreateButton == false) { player2_._recipeButton.create(); }
                        Cursor.visible = true;
                        CameraControll.active_camera = false;
                        RecipieButton.HandCraft = false;
                        return;
                    }
                }
                else if (Ray_.a == 7)//tag == clay の時
                {
                    Panel.SetActive(true);
                    string a;
                    if (wdata.ResourceCount != wdata.InitialCount)
                    {
                        a = (wdata.name_ + " " + wdata.Time_.ToString("F2"));
                    }
                    else
                    {
                        a = wdata.name_;
                    }
                    text.text = a;
                    HitText = a;
                    if (_gameInputs.Player.pickUp.WasPressedThisFrame())
                    {
                        int b = Random.Range(0, wdata.L_ResourceObject.Count);
                        WorldObject Rdata = wdata.L_ResourceObject[b].GetComponent<WorldObject>();
                        _InventoryList.AddItem(Rdata.name_, 1, Rdata.CloneObject, Rdata.ListNumber);
                        if (wdata.ResourceCount != 0)
                        {
                            wdata.ResourceCount--;
                            wdata.Time_ = 0f;
                        }
                        return;
                    }
                }
                else if (Ray_.a == 0)//Ray_._hit == null の時
                {
                    Panel.SetActive(false);
                    text.text = "";
                    HitText = "";
                }
            }
            else
            {
                Panel.SetActive(false);
                text.text = "";
                HitText = "";
            }


        }
    }
    public void ChestButton(bool a)
    {
        if (a)
        {
            player2_._chestManager.AddButton();
        }
        else
        {
            player2_._chestManager.RemoveButton();
        }
    }

}
