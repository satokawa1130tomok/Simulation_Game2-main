using System.Collections.Generic;
using UnityEngine;
public class CursorManager : MonoBehaviour
{
    public int max_X;
    public List<int> max_Y;
    //public GameObject[,] button;
    public Vector2 CursorPosition;
    public InputSystem _gameInputs;
    public CheckBox checkBox;
    // Start is called before the first frame update
    void Start()
    {
        _gameInputs = new InputSystem();
        _gameInputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameInputs.Player.left.WasPressedThisFrame())
        {
            if (CursorPosition.x > 0)
            {
                CursorPosition.x--;
                if (CursorPosition.y > max_Y[(int)CursorPosition.x])
                {
                    CursorPosition.y = max_Y[(int)CursorPosition.x];
                }
            }
        }
        if (_gameInputs.Player.right.WasPressedThisFrame())
        {
            if (CursorPosition.x < max_X)
            {
                CursorPosition.x++;
                if (CursorPosition.y > max_Y[(int)CursorPosition.x])
                {
                    CursorPosition.y = max_Y[(int)CursorPosition.x];
                }
            }
        }
        if (_gameInputs.Player.up.WasPressedThisFrame())
        {
            if (CursorPosition.y > 0)
            {
                CursorPosition.y--;
            }
        }
        if (_gameInputs.Player.Down.WasPressedThisFrame())
        {
            if (CursorPosition.y < max_Y[(int)CursorPosition.x])
            {
                CursorPosition.y++;
            }
        }
    }
}
