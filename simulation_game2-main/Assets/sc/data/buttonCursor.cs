using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonCursor : MonoBehaviour
{
    
    public int ListNumber_X;
    public int ListNumber_Y;
    public bool Toggle;
    public CursorManager _CursorManager;
    // Start is called before the first frame update
    void Start()
    {
       // _CursorManager.button[ListNumber_X, ListNumber_Y] = this.gameObject.GetComponent<buttonCursor>();
    }

    // Update is called once per frame
    void Update()
    {
      if(_CursorManager.CursorPosition.x == ListNumber_X && _CursorManager.CursorPosition.y == ListNumber_Y)
      {
            Debug.Log(ListNumber_X + " " + ListNumber_Y);
            if (!Toggle)
            {
                this.gameObject.GetComponent<Button>().image.color = new Color32(200, 200, 200, 255);
            }
            else
            {
               this.gameObject.GetComponent<Toggle>().image.color = new Color32(200, 200, 200, 255);
            }
            
          
            if (_CursorManager._gameInputs.Player.decision.WasPressedThisFrame())
            {
                
                if (!Toggle)
                {
                    Button buttonComponent = this.gameObject.GetComponent<Button>();

                    // null チェック
                    if (buttonComponent != null)
                    {
                        buttonComponent.onClick.Invoke();
                    }
                }
                else
                {
                    bool a = this.gameObject.GetComponent<Toggle>().isOn;
                    if (a)
                    {
                        this.gameObject.GetComponent<Toggle>().isOn = false;
                    }
                    else
                    {
                        this.gameObject.GetComponent<Toggle>().isOn = true;
                    }
                }
              

            }
        }
      else
      {
            if (!Toggle)
            {
                this.gameObject.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);

            }
            else
            {
                this.gameObject.GetComponent<Toggle>().image.color = new Color32(255, 255, 255, 255);

            }
        }
    }
}
