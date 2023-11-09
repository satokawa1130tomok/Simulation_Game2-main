using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "one")]
public class one : ScriptableObject
{
    public string RecipeName;
    public string ItemName1;
    public int ItemCount1;
    public string Explanation;
    public bool HandCraft;
    public int ButtonCount = 1;
    public int CarftCount = 1;
    public GameObject obj;
}
