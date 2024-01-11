using UnityEngine;

public class player_animation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (CameraControll.active_camera == true)
        {
            walkandran();

        }
        if (!CameraControll.active_camera == true)
        {
            anim.SetBool("player", false);
            anim.SetBool("player_r", false);


        }



    }
    public void walkandran()
    {

        if (player_.Run == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("player", true);


            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("player", false);
            }
        }
        anim.SetBool("player_r", player_.Run);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && player_.sli_val >= 0)
        {
            player_.sli_val = player_.sli_val - 0.01f;
        }

        else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            player_.sli_val = player_.sli_val + 0.005f;
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            player_.sli_val = player_.sli_val + 0.005f;
        }
        else if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            player_.sli_val = player_.sli_val + 0.005f;
        }



    }

}
