using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    // Start is called before the first frame update
    void Start()
    {

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
                if (Ray_.a == 1)//tag == item �̎�
                {
                    Panel.SetActive(true);

                    text.text = wdata.name;
                    HitText = wdata.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        _InventoryList.ItemList(wdata);//�C���x���g���ɒǉ�
                        Ray_.a = 0;
                        WorldObject w = Ray_._hit.GetComponent<WorldObject>();
                        w._objectManager.clearat(w.ListNumber);
                        Destroy(Ray_._hit);
                        return;
                    }
                }
                else if (Ray_.a == 2)//tga == resource�@�̎�
                {
                    Panel.SetActive(true);
                    WorldObject Rdata = Ray_._hit.gameObject.GetComponent<WorldObject>();
                    WorldObject RRdata = Rdata.ResourceObject.gameObject.GetComponent<WorldObject>();
                    text.text = (Rdata.name + " from " + RRdata.name + "  �~ " + Rdata.ResourceObjCount);
                    HitText = (Rdata.name + " from " + RRdata.name + "  �~ " + Rdata.ResourceObjCount);
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Rdata.ResourceObjToolType == player2.HaveTool)
                        {
                            //   Debug.Log("A"); 
                            _InventoryList.ResourceList(Rdata);
                            Ray_.a = 0;
                            Ray_._hit = null;
                            if(Rdata.ResourceCount != 0)
                            {
                                Rdata.ResourceCount --;
                            }
                        }//�C���x���g���ɒǉ�}
                        else { _ErrorMessage._ErrorMessage("tool do not much"); }
                    }
                }
                else if (Ray_.a == 6)//tga == resource�N�[���^�C���̎�
                {
                    Panel.SetActive(true);
                    WorldObject Rdata = Ray_._hit.gameObject.GetComponent<WorldObject>();
                    WorldObject RRdata = Rdata.ResourceObject.gameObject.GetComponent<WorldObject>();
                    float a = Rdata.RespawnTime - Rdata.Time_;
                    string b = a.ToString("f2");
                    text.text = (b +"�b��ɂƂ�܂�");
                    HitText = (b + "�b��ɂƂ�܂�");
                   
                }
                else if (Ray_.a == 3)//tag == tool �̎�
                {
                    string type = "";
                    Panel.SetActive(true);
                    ToolData Tdata = Ray_._hit.gameObject.GetComponent<ToolData>();
                    if (Tdata.type == 'A') { type = "axe"; }
                    if (Tdata.type == 'P') { type = "pickaxe"; }
                    if (Tdata.type == 'S') { type = "shovel"; }
                    text.text = Tdata.name + " (" + type + ")";
                    HitText = Tdata.name + " (" + type + ")";

                    if (Input.GetMouseButtonDown(0))
                    {
                        _InventoryList.ToolList(Ray_._hit, Tdata);//�C���x���g���ɒǉ�
                        _HaveTool.Have(Tdata);//�v���C���[�̎�Ɏ���
                        Ray_.a = 0;
                        Ray_._hit = null;

                    }



                }
                else if (Ray_.a == 4)//tag == chest�̎�
                {
                    Panel.SetActive(true);
                    text.text = wdata.name;
                    HitText = wdata.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        bool a = true;
                        _chestManager = Ray_._hit.GetComponent<ChestManager>();
                        player2_._chestManager = _chestManager;
                        _chestManager.Chset(a);
                        //chest���X�g��\��
                        Ray_.a = 0;
                        Ray_._hit = null;
                        CameraControll.active_camera = false;
                        HitText = "";
                    }
                }
                else if (Ray_.a == 5)
                {
                    Panel.SetActive(true);

                    text.text = wdata.name;
                    HitText = wdata.name;
                    if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
                    {
                        _InventoryList.ItemList(wdata);//�C���x���g���ɒǉ�
                        Ray_.a = 0;
                        WorldObject w = Ray_._hit.GetComponent<WorldObject>();
                        w._objectManager.clearat(w.ListNumber);
                        Destroy(Ray_._hit);
                        return;
                    }
                    if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
                    {
                        player2_.Craft.SetActive(true);
                        player2_.Recipe.SetActive(false);
                        player2_._inventoryCreate.DestroyButton();

                        Cursor.visible = true;
                        CameraControll.active_camera = false;
                        // _inventoryCreate.DestroyButton();
                        player2_.inventoy.SetActive(false);
                        RecipieButton.HandCraft = false;
                        _recipieButton.TableCraft();
                        return;
                    }
                }
                if (Ray_.a == 7)//tag == clay �̎�
                {
                   
                    Debug.Log(wdata.ResourceObject.GetComponent<WorldObject>().CloneObject);
                    string a;
                    Panel.SetActive(true);
                    if(wdata.ResourceCount == wdata.InitialCount)
                    {
                        a = wdata.name;
                        
                    }
                    else
                    {
                        a = (wdata.name +" "+wdata.Time_ .ToString("F2"));
                    }
                    text.text = a;
                    HitText = a;
                    if (Input.GetMouseButtonDown(0))
                    {
                        _InventoryList.ResourceList(wdata);//�C���x���g���ɒǉ�
                        if (wdata.ResourceCount != 0)
                        {
                            wdata.ResourceCount--;
                            wdata.Time_ = 0f;
                        }
                        return;
                    }
                }
            }
            
            if (Ray_.a == 0)//Ray_._hit == null �̎�
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
