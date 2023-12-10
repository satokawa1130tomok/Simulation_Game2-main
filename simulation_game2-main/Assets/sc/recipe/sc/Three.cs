using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Three")]
public class Three : ScriptableObject
{
    public string RecipeName;
    public string ItemName1;
    public int ItemCount1;
    public string ItemName2;
    public int ItemCount2;
    public string ItemName3;
    public int ItemCount3;
    public string Explanation;
    public bool HandCraft;
    public int CraftCount = 1;
    public int ButtonCount = 3;
    public GameObject obj;

}
