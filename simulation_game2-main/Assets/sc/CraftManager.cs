using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    public RecipieButton recipie;
    public bool craft;
    public bool removeItem_;
    private int Time;
    private int EventTime;
    private bool b;
    public List<GameObject> button;

    // Start is called before the first frame update
    void Start()
    {
        b = false;
        //if(button.Count != 0)
        //{
        //    button.Clear();
        //}
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Onclick()
    {
        craft = true;
        if (recipie.ButtonCount == 1)//ボタンの数が1
        {
            //Debug.Log("A");
            check(recipie.name1, recipie.count1, recipie.ItemButton1);
        }
        if (recipie.ButtonCount == 2)//ボタンの数が2
        {
            check(recipie.name1, recipie.count1, recipie.ItemButton1);

            check(recipie.name2, recipie.count2, recipie.ItemButton2);
        }
        if (recipie.ButtonCount == 3)//ボタンの数が2
        {
            check(recipie.name1, recipie.count1, recipie.ItemButton1);
            check(recipie.name2, recipie.count2, recipie.ItemButton2);
            check(recipie.name3, recipie.count3, recipie.ItemButton3);
        }
       // Debug.Log(craft);
        if (craft)//全部持っていたら
        {
            Craft();
            if (recipie.ButtonCount == 1)//ボタンの数が1
            {
                RemoveList(recipie.name1, recipie.count1);
            }
            if (recipie.ButtonCount == 2)//ボタンの数が2
            {
                RemoveList(recipie.name1, recipie.count1);

                RemoveList(recipie.name2, recipie.count2);
            }
            if (recipie.ButtonCount == 3)//ボタンの数が2
            {
                RemoveList(recipie.name1, recipie.count1);
                RemoveList(recipie.name2, recipie.count2);
                RemoveList(recipie.name3, recipie.count3);
            }
            recipie.road();
        }

    }
    public void return_()
    { 
        foreach(GameObject a  in button)
        {
            Destroy(a.GetComponent<Outline>());
        }
    }
    public void check(string item, int count, GameObject obj)
    {
        //if (craft)
        //{
            var var_ = 0;
            if (recipie.inventoryList.name_.IndexOf(item) == -1)
            {
                var_ = 0;
            }
            else
            {
                var_ = recipie.inventoryList.count[recipie.inventoryList.name_.IndexOf(item)];
            }
          //  Debug.Log(var_);
            
            if (var_ >= count)//必要な量を満たしている
            {
                //craft = true;
                return;
            }
            else if(var_ >= 0)//アイテムを持っていない
            {
                craft = false;
                Return(1, obj);
                return;
            }
            else if (var_ < count)//足りない
            {
                craft = false;
                Return(2, obj);
                return;
            }
            else
            {
                craft = false;
                Return(3, null);
                return;
            }

        //}
        //else
        //{
        //    return;
        //}

    }
    public void Craft()
    {
        WorldObject world = recipie.obj_.GetComponent<WorldObject>();
        recipie.inventoryList.AddItem(recipie.name_, recipie.CraftCount, recipie.obj_, world.ListNumber);
    }
    public void RemoveList(string name, int count)
    {
        var var_ = recipie.inventoryList.count[recipie.inventoryList.name_.IndexOf(name)];
        if (var_ == count)
        {
            removeItem_ = false;
            int a = recipie.inventoryList.name_.IndexOf(name);
            recipie.inventoryList.name_.RemoveAt(a);
            recipie.inventoryList.count.RemoveAt(a);
            recipie.inventoryList.obj.RemoveAt(a);
            recipie.inventoryList.number.RemoveAt(a);
        }
        else
        {
            recipie.inventoryList.count[recipie.inventoryList.name_.IndexOf(name)] = var_ - count;
            removeItem_ = true;
        }
    }

    public void Return(int a, GameObject obj)
    {
        //Debug.Log(a);
        craft = false;
        if (a == 1) { recipie.errorMessage._ErrorMessage("don't have the Item"); }
        if (a == 2) { recipie.errorMessage._ErrorMessage("Not enough items"); }
        if (a == 3) { recipie.errorMessage._ErrorMessage("Error!"); }
        if (a != 3)
        {
            if (obj.GetComponent<Outline>() == null)
            {
                obj.AddComponent<Outline>();
            }
            Outline outline = obj.GetComponent<Outline>();
            outline.enabled = true;
            outline.effectColor = Color.red;
            button.Add(obj);

        }
    }
   
}
