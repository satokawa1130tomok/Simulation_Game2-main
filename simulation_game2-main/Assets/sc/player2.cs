using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class player2 : MonoBehaviour
{

    public GameObject player;//�v���C���[
    public Rigidbody rb;//�v���C���[�̓����蔻��
    public int speed;//�ړ����x
    public static bool run;//����
    public float rotateSpeed = 0.01f;//���_�ړ����x
    public bool isGround;//�n��
    public float upForce = 10f;//�W�����v��
    public GameObject inventoy;//�C���x���g��
    public GameObject SecondInventoy;//�`�F�X�g��inventory
    public IncentoryCreate _inventoryCreate;//�N���X�擾
    public static char HaveTool = 'N';//�����Ă���c�[���̎��
    public static bool a;//inndenntorinoboolstatic
    public ChestManager _chestManager;
    // public buttanData _buttondata;

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
    //public Animation jump;
    private bool b;
    public RecipieButton _recipieButton;
    private bool esc_;
    public bool Preview;
    public PreviewManager _previewManager;
    public InputSystem _gameInputs;
    public GameObject button;

    // Start is called before the first frame update

    //�����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject);
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

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        player.transform.localEulerAngles = new Vector3(0, player.transform.localEulerAngles.y, 0);
        name_text.text = name_;
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    inventoy.SetActive(true);
        //}
        if (CameraControll.active_camera == true)
        {
            cameramove();

        }

        inventoy__ = inventoy.activeSelf;
        Craft_ = Craft.activeSelf;
        esc_ = EscObj.activeSelf;

        if (!inventoy.activeSelf && !Preview) { move(); }

       ;// Debug.Log(esc_ + "" + Preview);
        if (!esc_ && !Preview) { inventoy_(); }
        if (!esc_ && !Preview) { _Craft(); }
        chest();
        if (!inventoy__ && !Craft_ && !Preview) { esc(false); }
        RunParticle.SetActive(run);
        // Debug.Log(!_previewManager.preview +""+inventoy__ + "" + Craft_ + "" + esc_ + "" + Input.GetKeyUp(KeyCode.P)) ;

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


        //if (Input.GetKey(KeyCode.W) && !run)
        //{
        //    transform.position += transform.right * speed * Time.deltaTime;
        //    anim.SetBool("walk", true);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    anim.SetBool("walk", true);
        //}
        //if (!Input.GetKey(KeyCode.W))
        //{
        //    anim.SetBool("walk", false);
        //}
        //if (Input.GetKey(KeyCode.S)) { transform.position -= transform.right * speed * Time.deltaTime; }
        //if (Input.GetKey(KeyCode.A)) { transform.position += transform.forward * speed * Time.deltaTime; }
        //if (Input.GetKey(KeyCode.D)) { transform.position -= transform.forward * speed * Time.deltaTime; }
        //if (run) { transform.position += transform.right * speed * 2 * Time.deltaTime; }

        //anim.SetBool("run", run);

        //if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && run_sli.run_value > 0f)
        //{

        //    run = true;
        //}
        //else
        //    run = false;

        //if (Input.GetKey(KeyCode.Space) && isGround)
        //{

        //    //isGround = false;
        //    //rb.velocity = Vector3.up * upForce * 10;
        //    //anim.SetBool("jump", true);
        //    //b = true;
        //}

        //if (isGround && b)
        //{
        //    anim.SetBool("jump", false);
        //    b = false;
        //}

        //if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W))
        //{
        //    anim.SetBool("jump", true);
        //    anim.SetBool("walk", true);
        //}


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
        if (_gameInputs.Player.inventory.WasPressedThisFrame() && (!inventoy.activeSelf) && (!Craft.activeSelf) && (!EscObj.activeSelf))
        {
            inventoy__ = true;
            //  Debug.Log("a");
            inventoy.SetActive(true);
            //  _inventoryCreate.CloneButton.SetActive(false);
            Cursor.visible = true;
            CameraControll.active_camera = false;
            _inventoryCreate.InventoryCreate();
            _inventoryCreate.content.GetComponent<CursorManager>().max_X = 1;
            _inventoryCreate.content.GetComponent<CursorManager>().max_Y[1] = 0;
            _inventoryCreate.content.GetComponent<CursorManager>().CursorPosition = new Vector2(0, 0);
            name_ = "";
            a = true;
            inve_anim.SetBool("clause", true);
        }
        else if (_gameInputs.Player.inventory.WasPressedThisFrame() && (inventoy.activeSelf) && (!Craft.activeSelf) && (!EscObj.activeSelf))
        {

            _inventoryCreate.DestroyButton();
            inventoy__ = false;
            Cursor.visible = false;
            CameraControll.active_camera = true;
            _inventoryCreate.DestroyButton();
            //  _inventoryCreate.CloneButton.SetActive(true);
            inventoy.SetActive(false);
            inve_anim.SetBool("clause", false);
        }
        else if (_gameInputs.Player.inventory.WasPressedThisFrame() && (!inventoy.activeSelf) && (Craft.activeSelf) && (!EscObj.activeSelf))
        {
            inventoy__ = true;
            Recipe.SetActive(false);
            Craft.SetActive(false);
            inventoy.SetActive(true);
            // _inventoryCreate.CloneButton.SetActive(false);
            Cursor.visible = true;
            CameraControll.active_camera = false;
            _inventoryCreate.InventoryCreate();
            _inventoryCreate.content.GetComponent<CursorManager>().max_X = 1;
            _inventoryCreate.content.GetComponent<CursorManager>().max_Y[1] = 0;
            a = true;
            inve_anim.SetBool("clause", true);
        }



    }
    public void _Craft()
    {
        if (_gameInputs.Player.craft.WasPressedThisFrame() && (!Craft.activeSelf) && (!inventoy.activeSelf) && (!EscObj.activeSelf))
        {
            Craft_ = true;
            Craft.SetActive(true);
            Recipe.SetActive(false);
            Cursor.visible = true;
            CameraControll.active_camera = false;
            RecipieButton.HandCraft = true;
            _recipieButton.HnadCraft();
        }
        else if (_gameInputs.Player.craft.WasPressedThisFrame() && (Craft.activeSelf) && (!inventoy.activeSelf) && (!EscObj.activeSelf))
        {
            Recipe.SetActive(false);
            Craft.SetActive(false);
            Craft_ = false;
            Cursor.visible = false;
            CameraControll.active_camera = true;
        }
        else if (_gameInputs.Player.craft.WasPressedThisFrame() && (!Craft.activeSelf) && (inventoy.activeSelf) && (!EscObj.activeSelf))
        {
            RecipieButton.HandCraft = true;
            Craft.SetActive(true);
            Recipe.SetActive(false);
            _inventoryCreate.DestroyButton();
            _recipieButton.HnadCraft();
            Cursor.visible = true;
            CameraControll.active_camera = false;
            // _inventoryCreate.DestroyButton();
            inventoy.SetActive(false);
            Craft_ = true;
        }



    }
    public void chest()
    {


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
