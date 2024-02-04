using UnityEngine;
using UnityEngine.UI;

public class player2 : MonoBehaviour
{
    public GameObject player;//プレイヤー
    public int speed;//移動速度
    public static bool run;//走る
    public float rotateSpeed = 0.01f;//視点移動速度
    public bool isGround;//地面
    public float upForce = 10f;//ジャンプ力
    public GameObject inventoy;//インベントリ
    public GameObject SecondInventoy;//チェストのinventory
    public IncentoryCreate _inventoryCreate;//クラス取得
    public static string HaveTool = "N";//持っているツールの種類
    public static bool a;//inndenntorinoboolstatic
    public ChestManager _chestManager;
    public GameObject Craft;
    public GameObject Recipe;
    public string name_;
    public bool MaineInventory;
    public int No;
    public GameObject EscObj;
    public int count = 0;
    public bool inventoy__;
    public bool Craft_;
    public GameObject tutorial;
    public Text name_text;
    public static int number;
    public static ObjectManager objectManager_;
    public static ItemObjData itemObjData_;
    public ObjectManager objectManager;
    public ItemObjData itemObjData;
    public static GameObject obj;
    public GameObject RunParticle;
    public static Animator anim;
    public Animator anim_;
    public Animator inve_anim;
    private bool b;
    public RecipieButton _recipieButton;
    private bool esc_;
    public bool Preview;
    public PreviewManager _previewManager;
    public InputSystem _gameInputs;
    public GameObject button;
    public RecipeButtonCreate _recipeButton;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

    }
    void Awake()
    {
        itemObjData_ = itemObjData;
        objectManager_ = objectManager;
        anim = anim_;
    }
    void Start()
    {
        speed = 10;
        inventoy.SetActive(false);
        Cursor.visible = false;
        a = false;
        EscObj.SetActive(false);
        Craft.SetActive(false);
        tutorial.SetActive(true);
        inventoy__ = false;
        Craft_ = false;
        esc_ = false;
        _gameInputs = new InputSystem();
        _gameInputs.Enable();
        button.SetActive(CheckBox.bool_d);
    }
    void Update()
    {
        Vector3 vector = this.gameObject.transform.position;
        if (vector.y <= -10)
        {
            vector.y = 10;
            this.gameObject.transform.position = vector;
        }
        Cursor.visible = true;
        player.transform.localEulerAngles = new Vector3(0, player.transform.localEulerAngles.y, 0);
        if (obj != null)
        {
            name_ = obj.GetComponent<WorldObject>()._name;
        }
        else
        {
            name_text.text = "";
        }
        name_text.text = name_;
        if (CameraControll.active_camera)
        {
            cameramove();
        }

        inventoy__ = inventoy.activeSelf;
        Craft_ = Craft.activeSelf;
        esc_ = EscObj.activeSelf;
        if (!inventoy.activeSelf && !Preview) { move(); }
        if (!esc_ && !Preview) { inventoy_(); }
        if (!esc_ && !Preview) { _Craft(); }
        if (!inventoy__ && !Craft_ && !Preview) { esc(false); }
        
        RunParticle.SetActive(run);
    }
    public void move()
    {
        Vector2 direction = _gameInputs.Player.Move.ReadValue<Vector2>();
        Vector3 vector3 = this.transform.position;
        if (direction.y >= 0.5 && _gameInputs.Player.run.IsInProgress() && run_sli.run_value > 0f)
        {
            direction.y *= 2;
            run = true;
        }
        else
        {
            run = false;
        }
        anim.SetBool("run", run);
        vector3 += this.transform.right * direction.y * speed * Time.deltaTime;
        vector3 -= this.transform.forward * direction.x * speed * Time.deltaTime;
        vector3.z -= direction.y * speed * Time.deltaTime * this.transform.forward.y;
        transform.position = vector3;
        Jump();
        if (_gameInputs.Player.Move.IsInProgress())
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }
    public void Jump()
    {
        if (_gameInputs.Player.jump.IsInProgress() && isGround)
        {
            isGround = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * upForce * 10;
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
        b = true;
    }
    public void cameramove()
    {
        Vector2 direction = _gameInputs.Player.Look.ReadValue<Vector2>();
        Vector3 angle = new Vector3(direction.x * rotateSpeed, direction.y * rotateSpeed, 0);
        this.transform.RotateAround(this.transform.position, Vector3.up, angle.x);
    }
    public void inventoy_()
    {
        if (_gameInputs.Player.inventory.WasPressedThisFrame() && (!inventoy.activeSelf) && (!EscObj.activeSelf))
        {
            inventoy__ = true;
            if(Craft.activeSelf || Recipe.activeSelf)
            {
                Recipe.SetActive(false);
                Craft.SetActive(false);
            }
            inventoy.SetActive(true);
            SecondInventoy.SetActive(false);
            Cursor.visible = true;
            CameraControll.active_camera = false;
            _inventoryCreate.InventoryCreate();
            _inventoryCreate.content.GetComponent<CursorManager>().max_X = 1;
            _inventoryCreate.content.GetComponent<CursorManager>().max_Y[1] = 0;
            a = true;
            obj = null;
            name_ = null; 
            inve_anim.SetBool("clause", true);
        }
        else if (_gameInputs.Player.inventory.WasPressedThisFrame() && (inventoy.activeSelf) && (!Craft.activeSelf) && (!EscObj.activeSelf))
        {
            _inventoryCreate.DestroyButton();
            inventoy__ = false;
            Cursor.visible = false;
            CameraControll.active_camera = true;
            _inventoryCreate.DestroyButton();
            inventoy.SetActive(false);
            inve_anim.SetBool("clause", false);
            name_ = null;
        }
    }
    public void _Craft()
    {
        if (_gameInputs.Player.craft.WasPressedThisFrame() && (!Craft.activeSelf) && (!EscObj.activeSelf))
        {
            Craft_ = true;
            Craft.SetActive(true);
            Recipe.SetActive(false);
            if (_recipeButton.CreateButton == false) { _recipeButton.create(); }
            if (inventoy.activeSelf)
            {
                _inventoryCreate.DestroyButton();
                inventoy.SetActive(false);

            }
            Cursor.visible = true;
            CameraControll.active_camera = false;
            Craft_ = true;
        }
        else if (_gameInputs.Player.craft.WasPressedThisFrame() && (Craft.activeSelf) && (!inventoy.activeSelf) && (!EscObj.activeSelf))
        {
            Recipe.SetActive(false);
            Craft.SetActive(false);
            Craft_ = false;
            Cursor.visible = false;
            CameraControll.active_camera = true;
        }
    }
    public void esc(bool button)
    {
        if (!Craft.activeSelf && !inventoy.activeSelf && !button)
        {
            if (_gameInputs.Player.escape.WasPressedThisFrame())
            {
                count += 1;
                if (count % 2 == 1)
                {
                    esc_ = true;
                    EscObj.SetActive(true);
                    Cursor.visible = true;
                    CameraControll.active_camera = false;
                }
                else
                {
                    esc_ = false;
                    EscObj.SetActive(false);
                    count = 0;
                    Cursor.visible = false;
                    CameraControll.active_camera = true;
                }
            }


        }
        if (button)
        {
            esc_ = false;
            EscObj.SetActive(false);
            count = 0;
            Cursor.visible = false;
            CameraControll.active_camera = true;
        }
    }





}
