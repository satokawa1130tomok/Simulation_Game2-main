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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Ray_.a);
        // Debug.Log(Ray_._hit);
        Itemdata Idata = Ray_._hit.gameObject.GetComponent<Itemdata>();
        if (player2_.inventoy.activeSelf == false && (Ray_._hit != null) && Idata.name !=null && have_.have != 0)
        {
            if (Ray_.a == 1)//tag == item の時
            {
                Panel.SetActive(true);
                
                text.text = Idata.name;
                HitText = Idata.name;
                if (Input.GetMouseButtonDown(0))
                {
                    _InventoryList.ItemList(Ray_._hit, Idata);//インベントリに追加
                    Ray_.a = 0;
                    WorldObject w = Ray_._hit.GetComponent<WorldObject>();
                    w._objectManager.clearat(w.number);
                    Destroy(Ray_._hit);
                    return;
                }
            }
            else if (Ray_.a == 2)//tga == resource　の時
            {
                Panel.SetActive(true);
                ResourceData Rdata = Ray_._hit.gameObject.GetComponent<ResourceData>();
                text.text = (Rdata.itemname + " from " + Rdata.resource_name + "  × " + Rdata.quantity);
                HitText = (Rdata.itemname + " from " + Rdata.resource_name + "  × " + Rdata.quantity);
                if (Input.GetMouseButtonDown(0))
                {
                    if (Rdata._Tooltype == player2.HaveTool)
                    {
                        //   Debug.Log("A"); 
                        _InventoryList.ResourceList(Ray_._hit, Rdata);
                        Ray_.a = 0;
                        Ray_._hit = null;
                    }//インベントリに追加}
                    else { _ErrorMessage._ErrorMessage("tool do not much"); }
                }
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

                if (Input.GetMouseButtonDown(0))
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
                chestdata cdata = Ray_._hit.gameObject.GetComponent<chestdata>();
                text.text = cdata.name;
                HitText = cdata.name;
                if (Input.GetMouseButtonDown(0))
                {
                    bool a = true;
                    WorldObject w = Ray_._hit.GetComponent<WorldObject>();
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
