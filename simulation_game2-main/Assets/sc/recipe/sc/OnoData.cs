using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OnoRecipe")]
public class OnoData : ScriptableObject
{
    public string RecipeName;
    public string ItemName1;
    public int ItemCount1;
    public string ItemName2;
    public int ItemCount2;
    public string Explanation;
    public bool HandCraft;
    public int ButtonCount;
    public GameObject obj;
}
