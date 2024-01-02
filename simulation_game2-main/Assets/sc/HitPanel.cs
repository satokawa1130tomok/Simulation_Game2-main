using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
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

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Ray_.a);
        // Debug.Log(Ray_._hit);

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
                        _InventoryList.ItemList(wdata);//インベントリに追加
                        _InventoryList.CloneText(wdata._name, 1);
                        Ray_.a = 0;
                        WorldObject w = Ray_._hit.GetComponent<WorldObject>();
                        w._objectManager.clearat(w.ListNumber);
                        Destroy(Ray_._hit);
                        return;
                    }
                }
                else if (Ray_.a == 2 || Ray_.a == 8)//tga == resource　の時
                {
                    Panel.SetActive(true);
                    WorldObject Rdata = Ray_._hit.gameObject.GetComponent<WorldObject>();
                    int i = 0;
                    int ListNumber = 0;
                    WorldObject RRdata = null;
                    foreach (char a in Rdata.ResourceObjToolType)
                    {
                        if (player2.HaveTool == a)
                        {
                            RRdata = Rdata.ResourceObject[i].gameObject.GetComponent<WorldObject>();
                            ListNumber = i;
                        }
                        i++;
                    }
                    text.text = (Rdata.name_);
                    HitText = (Rdata.name_);
                    if (_gameInputs.Player.pickUp.WasPressedThisFrame())
                    {
                        if (Ray_.a == 2)
                        {
                            if (RRdata != null)
                            {
                                //   Debug.Log("A"); 
                                _InventoryList.ResourceList(RRdata, Rdata.ResourceObjCount[ListNumber]);//インベントリに追加}
                                _InventoryList.CloneText(RRdata._name, Rdata.ResourceObjCount[ListNumber]);
                                Ray_.a = 0;
                                Ray_._hit = null;
                                if (Rdata.ResourceCount != 0)
                                {
                                    Rdata.ResourceCount--;
                                }

                            }
                            else { _ErrorMessage._ErrorMessage("tool do not much"); }
                        }


                    }




                }
                else if (Ray_.a == 6)//tga == resourceクールタイムの時
                {
                    Panel.SetActive(true);
                    WorldObject Rdata = Ray_._hit.gameObject.GetComponent<WorldObject>();
                    float a = Rdata.RespawnTime - Rdata.Time_;
                    string b = a.ToString("f2");
                    text.text = (b + "秒後にとれます");
                    HitText = (b + "秒後にとれます");

                }
                else if (Ray_.a == 3)//tag == tool の時
                {
                    string type = "";
                    Panel.SetActive(true);
                    ToolData Tdata = Ray_._hit.gameObject.GetComponent<ToolData>();
                    if (Tdata.type == 'A') { type = "axe"; }
                    if (Tdata.type == 'P') { type = "pickaxe"; }
                    if (Tdata.type == 'S') { type = "shovel"; }
                    text.text = Tdata.name + " (" + type + ")";
                    HitText = Tdata.name + " (" + type + ")";

                    if (_gameInputs.Player.pickUp.WasPressedThisFrame())
                    {
                        _InventoryList.ToolList(Ray_._hit, Tdata);//インベントリに追加
                        _HaveTool.Have(Tdata);//プレイヤーの手に持つ
                        Ray_.a = 0;
                        Ray_._hit = null;

                    }
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
                        _chestManager.Chset(a);
                        //chestリストを表示
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
                        _InventoryList.ItemList(wdata);//インベントリに追加
                        _InventoryList.CloneText(wdata._name, 1);
                        Ray_.a = 0;
                        WorldObject w = Ray_._hit.GetComponent<WorldObject>();
                        w._objectManager.clearat(w.ListNumber);
                        Destroy(Ray_._hit);
                        return;
                    }
                    if (_gameInputs.Player.pickUp.WasPressedThisFrame() && !_gameInputs.Player.shift.WasPressedThisFrame())
                    {
                        // player2_.Craft.SetActive(true);
                        // player2_.Recipe.SetActive(false);
                        // player2_._inventoryCreate.DestroyButton();
                        // if (player2_._recipeButton.CreateButton == false) {player2_._recipeButton.create(); }
                        // Cursor.visible = true;
                        // CameraControll.active_camera = false;
                        // // _inventoryCreate.DestroyButton();
                        // player2_.inventoy.SetActive(false);
                        // RecipieButton.HandCraft = false;
                        // _recipieButton.TableCraft();
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

                    // Debug.Log(wdata.ResourceObject.GetComponent<WorldObject>().CloneObject);
                    string a;
                    Panel.SetActive(true);
                    if (wdata.ResourceCount == wdata.InitialCount)
                    {
                        a = wdata.name_;

                    }
                    else
                    {
                        a = (wdata.name_ + " " + wdata.Time_.ToString("F2"));

                        text.text = a;
                        HitText = a;
                        if (_gameInputs.Player.pickUp.WasPressedThisFrame())
                        {
                            _InventoryList.ClayList(wdata);//インベントリに追加
                            if (wdata.ResourceCount != 0)
                            {
                                wdata.ResourceCount--;
                                wdata.Time_ = 0f;
                            }
                            return;
                        }
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
