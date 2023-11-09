using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Two")]
public class Two : ScriptableObject
{
    public string RecipeName;
    public string ItemName1;
    public int ItemCount1;
    public string ItemName2;
    public int ItemCount2;
    public string Explanation;
    public bool HandCraft;
    public int ButtonCount = 2;
    public int CarftCount = 1;
    public GameObject obj;

}
