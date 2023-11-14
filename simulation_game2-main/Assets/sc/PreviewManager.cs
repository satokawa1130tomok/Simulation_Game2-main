using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreviewManager : MonoBehaviour
{
    public GameObject ImageObject;
    public GameObject image_;
    public GameObject UIObject;
    public bool preview;
    public player2 _player2;
    public InventoryList _inventoryList;
    public Text NameText;
    public GameObject CloneButton;
    public List<GameObject> button;
    private bool a_;
    private HouseRecipe scriptable;
    // Start is called before the first frame update
    void Start()
    {
        active(false);
        if (button.Count > 0)
        {
            button.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (preview == true && Input.GetKeyDown(KeyCode.P))
        {
            active(false);
            Cursor.visible = false;
            CameraControll.active_camera = true;
        }
        if (a_ == true)
        {
            if (!Input.GetKey(KeyCode.P))
            {
                preview = false;
                a_ = false;
        }   }

        if (!preview && !_player2.inventoy__ && !_player2.Craft_ && Input.GetKeyDown(KeyCode.P))
        {
            Cursor.visible = true;
            active(true);
            Cursor.visible = true;
            CameraControll.active_camera = false;
        } 
    }   
    //SceneManager.LoadScene("preview");

      // SceneManager.LoadSceneAsync("preview", LoadSceneMode.Single);
            // SceneManager.UnloadScene("game");
        
    public void active(bool a)
    {
       // Debug.Log(a);
        if (a == false)
        {
            a_ = true;
        }
        if(a)
        {
            preview = a;
        }

        _player2.Preview = a;
        if(a == true)
        {
            NameText.text = "";
        }

        DestroyButton();
        
        ImageObject.SetActive(a);
        UIObject.SetActive(a);
    }
    public void image(Sprite texture)
    {
        Image image = image_.gameObject.GetComponent<Image>();
        image.sprite = texture;
    }
    public void Clone(HouseRecipe scriptable_)
    {
        DestroyButton();

        NameText.text = scriptable_.RecipeName;
        int int1 = 0;
        foreach(string a in scriptable_.ItemName)
        {
            Vector3 vector3 = new Vector3(240, 370 - 30*int1, 0);
          GameObject CloneObject = Instantiate(CloneButton, vector3, Quaternion.identity);
           CloneObject.transform.parent = GameObject.Find("clone").transform;
            GameObject textObj = CloneObject.transform.Find("clonetext").gameObject;
            Text text = textObj.gameObject.GetComponent<Text>();
            int c = _inventoryList.name.IndexOf(a);
            if(c == -1)
            {
                c = 0;
            }
            else
            {
                Debug.Log(c + "" + int1);
                c = _inventoryList.count[c];
            }
            string b = (a + "" + scriptable_.ItemCount[int1] +"/"+c);
            text.text = b;
            button.Add(CloneObject);
            int1 +=1;
        }
       
        scriptable = scriptable_;
    }
    public void DestroyButton()
    {
        if (button.Count > 0)
        {
            foreach (GameObject b in button)
            {
                Destroy(b);
            }
            button.Clear();
        }
    }
    public void Craft()
    {
        int int1 = 0;
        bool HaveItem = false;
        foreach(string a in scriptable.ItemName)
        {
            int b = _inventoryList.name.IndexOf(a);
            if (b == -1)
            {
                HaveItem = true;
            }
            else if (_inventoryList.count[b] <= scriptable.ItemCount[int1])
            {
                   HaveItem = true;
            }

            if (HaveItem)
            {
                button[int1].GetComponent<Outline>().enabled = true;
            }
            else
            {
                button[int1].GetComponent<Outline>().enabled = false;
            }

            int1++;
        }
    }
}
