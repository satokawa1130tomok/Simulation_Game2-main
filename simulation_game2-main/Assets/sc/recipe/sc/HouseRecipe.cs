using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "HouseRecipe")]

public class HouseRecipe : ScriptableObject
{
    public string RecipeName;
    public List<string> ItemName;
    public List<int> ItemCount;
    public GameObject obj;

}
