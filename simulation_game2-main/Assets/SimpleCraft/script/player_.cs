using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_ : MonoBehaviour
{

    public float speed = 2.0f;

    public GameObject mainCamera;              //ƒƒCƒ“ƒJƒƒ‰Ši”[—p
    public GameObject playerObject;            //‰ñ“]‚Ì’†S‚Æ‚È‚éƒvƒŒƒCƒ„[Ši”[—p
    public float rotateSpeed = 1.0f;            //‰ñ“]‚Ì‘¬‚³
    public static bool Run = false;
    public Rigidbody rb;
    public float upForce = 5f;
    public bool isGround;

    public static bool run_tf;
    public Slider runslider;
    public int max;
    public int crruent;

    [SerializeField]
    public static float sli_val;

    //sli

    public Image sli_bk;

    //slider
    [SerializeField]
    public Slider slier_;
    public bool run;

    //  public float slier_n;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        runslider.value = 5;
        runslider.maxValue = 5;
        sli_bk = GetComponent<Image>();
        //  sli_bk.color = new Color(255f, 255f, 255f,1f);
        sli_val = 0f;
    }
    // Update is called once per frame

    void Update()
    {

        if (CameraControll.active_camera == true)
        {
            camera_();
            Move();
            slider();
            Ray_();
        }


        //jump();

        // UnityEditor.EditorApplication.isPaused = false;

    }
    public void Ray_()
    {

    }
    public void slider()
    {
        slier_.value = sli_val;
        if (run == false)
        {
            sli_val = sli_val + 1f;
            if (sli_val >= 101)
            {
                sli_val = 100;
            }
            //Debug.Log("abc");
        }
        else
        {
            sli_val = sli_val - 0.5f;
            if (sli_val <= 0)
            {
                sli_val = 0;
            }
            Debug.Log("abcd");
        }
        //Debug.Log(sli_bk.color);
        //if (
        //    Key(KeyCode.K))
        //{
        //    sli_bk.color = new Color(255f, 255f, 255f);
        //}

    }






    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = Vector3.up * upForce;
            isGround = false;
        }
    }
    public void camera_()
    {

        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);
        playerObject.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
    }
    public void Move()

    {
        if (this.transform.position.y < -10)
        {
            this.transform.position = new Vector3(0, 10, 0);
        }
        Transform myTransform = this.transform;
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        Run = Input.GetKey(KeyCode.LeftShift) && sli_val > 0.0f;
        if (Input.GetKey(KeyCode.W))
        {


            if (Run && sli_val != 0)
            {

                transform.position += transform.right * (speed * 2) * Time.deltaTime;
                run_tf = true;
                run = true;


            }
            else
            {
                transform.position += transform.right * speed * Time.deltaTime;
                run_tf = true;
                run = false;

            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        Vector3 worldAngle = myTransform.eulerAngles;
        if (Input.GetKey(KeyCode.LeftShift))//‰ñ“]
        {
            if (Input.GetKey(KeyCode.Q))
            {
                worldAngle.y -= 5.0f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                worldAngle.y += 5.0f;
            }
        }
        myTransform.eulerAngles = worldAngle;
        if (!Input.GetKey(KeyCode.W))
        {
            run = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
