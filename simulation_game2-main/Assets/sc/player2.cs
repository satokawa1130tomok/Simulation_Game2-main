using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player2 : MonoBehaviour
{

    public GameObject player;//�v���C���[
    public Rigidbody rb;//�v���C���[�̓����蔻��
    public int speed;//�ړ����x
    public static bool run;//����
    public float rotateSpeed = 1.0f;//���_�ړ����x
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
    public string name;
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
    //public Animation jump;
    private bool b;
    public RecipieButton _recipieButton;
    private bool esc_;
    public bool Preview;
    public PreviewManager _previewManager;
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
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.localEulerAngles = new Vector3(0,player.transform.localEulerAngles.y,0);
        name_text.text = name;
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

        Debug.Log(esc_ + "" + Preview);
        if (!esc_ && !Preview) { inventoy_(); }
        if (!esc_ && !Preview) { _Craft(); }
        chest();
        if (!inventoy__ && !Craft_ && !Preview) { esc(false); }
        RunParticle.SetActive(run);
       // Debug.Log(!_previewManager.preview +""+inventoy__ + "" + Craft_ + "" + esc_ + "" + Input.GetKeyUp(KeyCode.P)) ;
       
    }
    public void move()
    {

        if (Input.GetKey(KeyCode.W) && !run)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            anim.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", true);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", false);
        }
        if (Input.GetKey(KeyCode.S)) { transform.position -= transform.right * speed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A)) { transform.position += transform.forward * speed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.D)) { transform.position -= transform.forward * speed * Time.deltaTime; }
        if (run) { transform.position += transform.right * speed * 2 * Time.deltaTime; }

        anim.SetBool("run", run);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && run_sli.run_value > 0f)
        {

            run = true;
        }
        else
            run = false;

        if (Input.GetKey(KeyCode.Space) && isGround)
        {

            isGround = false;
            rb.velocity = Vector3.up * upForce * 10;
            anim.SetBool("jump", true);
            b = true;
        }

        if (isGround && b)
        {
            anim.SetBool("jump", false);
            b = false;
        }

        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W))
        {
            anim.SetBool("jump", true);
            anim.SetBool("walk", true);
        }


    }
    public void cameramove()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);
        player.transform.RotateAround(player.transform.position, Vector3.up, angle.x);
    }
    public void inventoy_()
    {
        if (Input.GetKeyDown(KeyCode.E) && (!inventoy.activeSelf) && (!Craft.activeSelf) && (!EscObj.activeSelf))
        {
            inventoy__ = true;
            //  Debug.Log("a");
            inventoy.SetActive(true);
            //  _inventoryCreate.CloneButton.SetActive(false);
            Cursor.visible = true;
            CameraControll.active_camera = false;
            _inventoryCreate.InventoryCreate();
            name = "";
            a = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && (inventoy.activeSelf) && (!Craft.activeSelf) && (!EscObj.activeSelf))
        {

            _inventoryCreate.DestroyButton();
            inventoy__ = false ;
            Cursor.visible = false;
            CameraControll.active_camera = true;
            _inventoryCreate.DestroyButton();
            //  _inventoryCreate.CloneButton.SetActive(true);
            inventoy.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && (!inventoy.activeSelf) && (Craft.activeSelf) && (!EscObj.activeSelf))
        {
            inventoy__ = true;
            Recipe.SetActive(false);
            Craft.SetActive(false);
            inventoy.SetActive(true);
            // _inventoryCreate.CloneButton.SetActive(false);
            Cursor.visible = true;
            CameraControll.active_camera = false;
            _inventoryCreate.InventoryCreate();
            a = true;
        }



    }
    public void _Craft()
    {
        if (Input.GetKeyDown(KeyCode.C) && (!Craft.activeSelf) && (!inventoy.activeSelf) && (!EscObj.activeSelf))
        {
            Craft_ = true;
            Craft.SetActive(true);
            Recipe.SetActive(false);
            Cursor.visible = true;
            CameraControll.active_camera = false;
            RecipieButton.HandCraft = true;
            _recipieButton.HnadCraft();
        }
        else if (Input.GetKeyDown(KeyCode.C) && (Craft.activeSelf) && (!inventoy.activeSelf) && (!EscObj.activeSelf))
        {
            Recipe.SetActive(false);
            Craft.SetActive(false);
            Craft_ = false;
            Cursor.visible = false;
            CameraControll.active_camera = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && (!Craft.activeSelf) && (inventoy.activeSelf) && (!EscObj.activeSelf))
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
            if (Input.GetKeyDown(KeyCode.Escape))
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
