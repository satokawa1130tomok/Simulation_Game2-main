using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipieButton : MonoBehaviour
{
    public InventoryList inventoryList;
    public ErrorMessage errorMessage;

    public GameObject panel;
    public Text RecipeName;
    public Text Explanation;
    public GameObject ItemButton1;
    public Text ItemText1;
    public GameObject ItemButton2;
    public Text ItemText2;
    public GameObject ItemButton3;
    public Text ItemText3;
    public GameObject CraftButton;
    public GameObject ErrorMessage;
    public RecipeButtonCreate _RecipeButtonCreate;

    public static bool HandCraft;


    public string _name;
    public string name_
    {
        get { return _name; }
        set { _name = value; }
    }
    public string _name1;
    public string name1
    {
        get { return _name1; }
        set { _name1 = value; }
    }
    public int _count1;
    public int count1
    {
        get { return _count1; }
        set { _count1 = value; }
    }
    public int count__;
    public int CraftCount
    {
        get { return count__; }
        set { count__ = value; }
    }
    public int _count2;
    public int count2
    {
        get { return _count2; }
        set { _count2 = value; }
    }
    public int _count3;
    public int count3
    {
        get { return _count3; }
        set { _count3 = value; }
    }

    public string _name2;
    public string name2
    {
        get { return _name2; }
        set { _name2 = value; }
    }
    public string _name3;
    public string name3
    {
        get { return _name3; }
        set { _name3 = value; }
    }
    public GameObject _obj;
    public GameObject obj_
    {
        get { return _obj; }
        set { _obj = value; }
    }
    public int a;
    public int a_
    {
        get { return a; }
        set { a = value; }
    }
    public int _count;
    public int ButtonCount
    {
        get { return _count; }
        set { _count = value; }
    }
    public one _one;
    public one one_
    {
        get { return _one; }
        set { _one = value; }
    }
    public Two _Two;
    public Two Two_
    {
        get { return _Two; }
        set { _Two = value; }
    }
    public Three _Three;
    public Three Three_
    {
        get { return _Three; }
        set { _Three = value; }
    }
    public bool craft;

    public List<GameObject> buttonObj;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        HandCraft = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click(GameObject obj)
    {
        if (panel.activeSelf == false)
        {
            panel.SetActive(true);
        }
        RecipeButtonData recipe = obj.GetComponent<RecipeButtonData>();
        if (recipe.RecipeType == 1)
        {
            one(obj);
        }
        else if (recipe.RecipeType == 2)
        {
            two(obj);
        }
        else if (recipe.RecipeType == 3)
        {
            three(obj);
        }
    }
    public void one(GameObject obj)
    {
        RecipeButtonData recipe = obj.GetComponent<RecipeButtonData>();
        int Number = recipe.ListNumber;
        ScriptableObject scriptable_ = _RecipeButtonCreate.List[Number];
        one scriptable = (one)scriptable_;
        if (!HandCraft || (HandCraft && scriptable.HandCraft))
        {
            OneButtonText(scriptable.ItemName1, scriptable.ItemCount1);
            text(scriptable.RecipeName, scriptable.Explanation);
            obj_ = scriptable.obj;
            name_ = scriptable.RecipeName;
            a_ = a;
            ButtonCount = scriptable.ButtonCount;
            one_ = scriptable;
            CraftCount = scriptable.CarftCount;
            obj_ = scriptable.obj;
            HandCraft_(true);
            ErrorMessage.SetActive(false);
            active(scriptable.ButtonCount);

        }
        else 
        {
            text(scriptable.RecipeName, scriptable.Explanation);
            HandCraft_(false);
            ErrorMessage.SetActive(true);

        }
    }
    public void HandCraft_(bool a)
    {
        ItemButton1.SetActive(a);
        ItemButton2.SetActive(a);
        ItemButton3.SetActive(a);
        CraftButton.SetActive(a);

    }
    public void two(GameObject obj)
    {
        RecipeButtonData recipe = obj.GetComponent<RecipeButtonData>();
        int Number = recipe.ListNumber;
        ScriptableObject scriptable_ = _RecipeButtonCreate.List[Number];
        Two scriptable = (Two)scriptable_;
        if (!HandCraft || (HandCraft && scriptable.HandCraft))
        {
            TwoButtonText(scriptable.ItemName1, scriptable.ItemCount1, scriptable.ItemName2, scriptable.ItemCount2);
            text(scriptable.RecipeName, scriptable.Explanation);
            obj_ = scriptable.obj;
            name_ = scriptable.RecipeName;
            a_ = a;
            ButtonCount = scriptable.ButtonCount;
            Two_ = scriptable;
            CraftCount = scriptable.CarftCount;
            obj_ = scriptable.obj;
            HandCraft_(true);
            ErrorMessage.SetActive(false);
            active(scriptable.ButtonCount);
        }
        else
        {
            text(scriptable.RecipeName, scriptable.Explanation);
            HandCraft_(false);
            ErrorMessage.SetActive(true);

        }
    }
    public void three(GameObject obj)
    {
        RecipeButtonData recipe = obj.GetComponent<RecipeButtonData>();
        int Number = recipe.ListNumber;
        ScriptableObject scriptable_ = _RecipeButtonCreate.List[Number];
        Three scriptable = (Three)scriptable_;
        if (!HandCraft || (HandCraft && scriptable.HandCraft))
        {
            ThreeButtonText(scriptable.ItemName1, scriptable.ItemCount1, scriptable.ItemName2, scriptable.ItemCount2, scriptable.ItemName3, scriptable.ItemCount3);
            text(scriptable.RecipeName, scriptable.Explanation);
            obj_ = scriptable.obj;
            name_ = scriptable.RecipeName;
            a_ = a;
            ButtonCount = scriptable.ButtonCount;
            Three_ = scriptable;
            CraftCount = scriptable.CraftCount;
            obj_ = scriptable.obj;
            HandCraft_(true);
            ErrorMessage.SetActive(false);
            active(scriptable.ButtonCount);
        }
        else
        {
            text(scriptable.RecipeName, scriptable.Explanation);
            HandCraft_(false);
            ErrorMessage.SetActive(true);

        }
    }
    public void road()
    {
        if (ButtonCount == 1)
        {

            OneButtonText(one_.ItemName1, one_.ItemCount1);
        }
        if (ButtonCount == 2)
        {

            TwoButtonText(Two_.ItemName1, Two_.ItemCount1, Two_.ItemName2, Two_.ItemCount2);
        }
        if (ButtonCount == 3)
        {

            ThreeButtonText(Three_.ItemName1, Three_.ItemCount1, Three_.ItemName2, Three_.ItemCount2, Three_.ItemName3, Three_.ItemCount3);
        }
        //switch (a_)
        //{
        //    case 1:
        //        ButtonText(onodata.ItemName1, onodata.ItemCount1, onodata.ItemName2, onodata.ItemCount2, "", 0, onodata.ButtonCount);

        //        break;

        //    case 2:
        //        ButtonText(crafttabledata.ItemName1, crafttabledata.ItemCount1, crafttabledata.ItemName2, crafttabledata.ItemCount2, "", 0, crafttabledata.ButtonCount);

        //        break;
        //}
    }


    public void active(int count)
    {
        if (panel.activeSelf == false) { panel.SetActive(true); }
        ItemButton1.SetActive(true);
        if (count == 1)
        {
            ItemButton2.SetActive(false);
            ItemButton3.SetActive(false);
        }
        else if (count == 2)
        {
            ItemButton2.SetActive(true);
            ItemButton3.SetActive(false);
        }
        else if (count == 3)
        {
            ItemButton2.SetActive(true);
            ItemButton3.SetActive(true);
        }


    }
    public void text(string name, string expl)
    {
        RecipeName.text = name;
        Explanation.text = expl;
    }
    public void OneButtonText(string Itemname1, int Itemcount1)
    {

        int int1;
        int a = inventoryList.name_.IndexOf(Itemname1);
        if ((a == -1))
        {
            int1 = 0;
        }
        else
        {
            //Debug.Log(a);
            int1 = inventoryList.count[a];
        }
        ItemText1.text = (Itemname1 + "     " + int1 + "/" + Itemcount1);
        name1 = Itemname1;

        count1 = Itemcount1;

    }
    public void TwoButtonText(string Itemname1, int Itemcount1, string Itemname2, int ItemCount2)
    {

        int int1;
        int a = inventoryList.name_.IndexOf(Itemname1);
        if ((a == -1))
        {
            int1 = 0;
        }
        else
        {
            //Debug.Log(a);
            int1 = inventoryList.count[a];
        }
        ItemText1.text = (Itemname1 + "     " + (int1) + "/" + Itemcount1);

        int int2;
        // Debug.Log(inventoryList.name.IndexOf(Itemname2));
        a = inventoryList.name_.IndexOf(Itemname2);
        if ((a == -1))
        {
            int2 = 0;
        }
        else
        {
            //Debug.Log(a);
            int2 = inventoryList.count[a];
        }
        ItemText2.text = (Itemname2 + "     " + (int2) + "/" + ItemCount2);
        name1 = Itemname1;
        name2 = Itemname2;

        count1 = Itemcount1;
        count2 = ItemCount2;



    }
    public void ThreeButtonText(string Itemname1, int Itemcount1, string Itemname2, int ItemCount2, string Itemname3, int ItemCount3)
    {

        int int1;
        int a = inventoryList.name_.IndexOf(Itemname1);
        if ((a == -1))
        {
            int1 = 0;
        }
        else
        {
            //Debug.Log(a);
            int1 = inventoryList.count[a];
        }
        ItemText1.text = (Itemname1 + "     " + int1 + "/" + Itemcount1);

        int int2;
        a = inventoryList.name_.IndexOf(Itemname2);
        if ((a == -1))
        {
            int2 = 0;
        }
        else
        {
            //Debug.Log(a);
            int2 = inventoryList.count[a];
        }
        ItemText2.text = (Itemname2 + "     " + int2 + "/" + ItemCount2);

        int int3;
        a = inventoryList.name_.IndexOf(Itemname3);
        if ((a == -1))
        {
            int3 = 0;
        }
        else
        {
            //Debug.Log(a);
            int3 = inventoryList.count[a];
        }
        ItemText3.text = (Itemname3 + "     " + int3 + "/" + ItemCount3);
        name1 = Itemname1;
        name2 = Itemname2;
        name3 = Itemname3;

        count1 = Itemcount1;
        count2 = ItemCount2;
        count3 = ItemCount3;

    }
}
