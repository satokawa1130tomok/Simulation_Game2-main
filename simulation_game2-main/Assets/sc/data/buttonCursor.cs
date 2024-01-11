using UnityEngine;
using UnityEngine.UI;
public class buttonCursor : MonoBehaviour
{

    public int ListNumber_X;
    public int ListNumber_Y;
    public bool hit;
    public bool Toggle;
    public CursorManager _CursorManager;
    public Button button;
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        // _CursorManager.button[ListNumber_X, ListNumber_Y] = this.gameObject.GetComponent<buttonCursor>();
        if (!Toggle && button == null)
        {
            button = this.gameObject.GetComponent<Button>();
        }
        else if (Toggle && toggle == null)
        {
            toggle = this.gameObject.GetComponent<Toggle>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        hit = (_CursorManager.CursorPosition.x == ListNumber_X && _CursorManager.CursorPosition.y == ListNumber_Y);
        if (_CursorManager.CursorPosition.x == ListNumber_X && _CursorManager.CursorPosition.y == ListNumber_Y)
        {
            // Debug.Log(ListNumber_X + " " + ListNumber_Y);
            if (!Toggle)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = Color.gray;
                button.colors = colors;
            }
            else
            {
                toggle.image.color = new Color32(200, 200, 200, 255);
            }


            if (_CursorManager._gameInputs.Player.decision.WasPressedThisFrame())
            {

                if (!Toggle)
                {
                    if (button != null)
                    {
                        button.onClick.Invoke();
                    }
                }
                else
                {
                    bool a = toggle.isOn;
                    if (a)
                    {
                        toggle.isOn = false;
                    }
                    else
                    {
                        toggle.isOn = true;
                    }
                }

            }
        }
        else
        {
            if (!Toggle)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = Color.white;
                button.colors = colors;

            }
            else
            {
                toggle.image.color = new Color32(255, 255, 255, 255);

            }
        }
    }
}
