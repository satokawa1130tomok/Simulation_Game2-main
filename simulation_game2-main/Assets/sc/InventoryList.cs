using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    public List<string> name_ = new List<string>();
    public List<int> count;
    public List<GameObject> obj;
    public List<int> number;
    public GameObject CloneText_;
    public RecipieButton recipie;
    public ObjectManager _ObjectManager;
    // Start is called before the first frame update
    public void AddItem(string ItemName, int Count_, GameObject ItemObj_, int ListNunber_, bool active = true)
    {
        var var1 = -100;
        var1 = name_.IndexOf(ItemName);
        if (var1 == -1)
        {
            name_.Add(ItemName);
            count.Add(Count_);
            obj.Add(ItemObj_);
            number.Add(ListNunber_);
        }
        else
        {
            int i;
            i = count[var1];
            i = i + 1;
            count[var1] = i;
        }
        if (active) { CloneText(ItemName, Count_); }
    }
    public void CloneText(string name, int count)
    {
        // Prefab����CloneObject�𐶐�
        GameObject cloneObject = Instantiate(CloneText_, CloneText_.transform.position, Quaternion.identity);

        // GetItem���A�^�b�`����Ă���ꍇ�A�R���|�[�l���g�ւ̃A�N�Z�X���擾
        GetItem g = cloneObject.GetComponent<GetItem>();

        // GetItem���A�^�b�`����Ă��Ȃ��ꍇ�A�A�^�b�`���Ď擾
        if (g == null)
        {
            g = cloneObject.AddComponent<GetItem>();
        }
        // �e�I�u�W�F�N�g��ݒ�
        Transform parentTransform = GameObject.Find("GetItem").transform;
        cloneObject.transform.SetParent(parentTransform);
        // �A�N�e�B�u�ɂ���
        cloneObject.SetActive(true);

        // GetItem�̃v��@�p�e�B��ݒ�
        g.ItemName = name;
        g.ItemCount = count;

    }
    public void RemoveItem(string name)
    {
        int ListCount = recipie.inventoryList.name_.IndexOf(name);
        recipie.inventoryList.count[ListCount] -= 1;
        if (recipie.inventoryList.count[recipie.inventoryList.name_.IndexOf(name)] == 0)
        {
            int a = recipie.inventoryList.name_.IndexOf(name);
            recipie.inventoryList.name_.RemoveAt(a);
            recipie.inventoryList.count.RemoveAt(a);
            recipie.inventoryList.obj.RemoveAt(a);
            recipie.inventoryList.number.RemoveAt(a);
            _ObjectManager.clearat(a);
            Have.removeItem_ = true;
        }
        else
            Have.removeItem_ = false;
    }

}

