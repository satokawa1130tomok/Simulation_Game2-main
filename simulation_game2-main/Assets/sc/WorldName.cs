using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class WorldName : MonoBehaviour
{
    public InputField inputField;
    public static string text;
    public static bool road;
    public GameObject fast;
    public GameObject second;
    public GameObject second_r;
    public GameObject settings;
    private string[] road_List;
    public GameObject CloneButton;
    public GameObject panel;
    private List<GameObject> but;
    public CursorManager _CursorManager;
    // Start is called before the first frame update
    void Start()
    {
        fast.SetActive(true);
        second.SetActive(false);
        second_r.SetActive(false);
        inputField = inputField.GetComponent<InputField>();
        settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;

        //Debug.Log(text);
        if (road == false)
        {
            text = inputField.text;
        }
    }
    public void OnClick(bool road_)
    {
        fast.SetActive(false);
        if (road_)
        {
            second_r.SetActive(true);
            NameList();

        }
        else
        {
            second.SetActive(true);
        }
        road = road_;
    }
    public void back()
    {
        fast.SetActive(true);
        second.SetActive(false);
        second_r.SetActive(false);
        settings.SetActive(false);
    }
    public void setting()
    {
        fast.SetActive(false);
        second.SetActive(false);
        second_r.SetActive(false);
        settings.SetActive(true);
    }
    public void NameList()
    {
        but = new List<GameObject>();

        road_List = File.ReadAllLines("save/FileManager.txt");
        int i = 0;
        foreach (string a in road_List)
        {
            if (i != 0)
            {

                GameObject cloneButton = Instantiate(CloneButton) as GameObject;
                cloneButton.transform.SetParent(panel.transform, false);
                cloneButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(i - 4) * 60);

                GameObject textObj = cloneButton.transform.Find("Text (Legacy)").gameObject;
                Text _text = textObj.GetComponent<Text>();


                _text.text = a;

                but.Add(cloneButton);
                cloneButton.SetActive(true);
                buttonCursor cursor = cloneButton.GetComponent<buttonCursor>();
                cursor.ListNumber_X = 1;
                cursor.ListNumber_Y = i - 1;
            }

            i++;


        }
        _CursorManager.max_Y[1] = i - 2;
    }
    public void DestroyButton()
    {
        foreach (GameObject a in but)
        {
            Destroy(a);
        }
    }
    public void ButtonClick(Text t)
    {
        if (text == t.text)
        {
            text = "";
        }
        else
        {
            text = t.text;
        }

        //Debug.Log(text);
    }
}
