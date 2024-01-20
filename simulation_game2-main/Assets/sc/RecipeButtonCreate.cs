using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeButtonCreate : MonoBehaviour
{
    public List<ScriptableObject> List;
    public GameObject CloneButton;
    public GameObject content;
    public RecipieButton _recipieButton;
    public one one;
    public Two Two;
    public Three Three;

    public bool CreateButton;
    // Start is called before the first frame update
    void Start()
    {
        CreateButton = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void create()
    {

        int i = 0;
        foreach (ScriptableObject a in List)
        {
            Vector3 vector = new Vector3(0, 0, 0);
            GameObject CloneObj = Instantiate(CloneButton);
            CloneButton.SetActive(true);
            CloneObj.transform.SetParent(content.transform, false);
            CloneObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,   (i * 100)-30);
            int int1 = 0;
            try
            {
                one = (one)a;
                int1 = 1;
            }
            catch
            {
                try
                {
                    Two = (Two)a;
                    int1 = 2;
                }
                catch
                {
                    Three = (Three)a;
                    int1 = 3;
                }
            }
            string NameText = "";
            if (int1 == 1)
            {
                NameText = one.RecipeName;
            }
            else if (int1 == 2)
            {
                NameText = Two.RecipeName;
            }
            else if (int1 == 3)
            {
                NameText = Three.RecipeName;
            }
            RecipeButtonData recipieButton = CloneObj.AddComponent<RecipeButtonData>();
            recipieButton.ListNumber = i;
            recipieButton.RecipeType = int1;
            GameObject textObj = CloneObj.transform.Find("clonetext").gameObject;
            textObj.GetComponent<Text>().text = NameText;


            i++;
        }
        CreateButton = true;
        CloneButton.SetActive(false);
    }
    public void Destroy()
    {

    }

}
