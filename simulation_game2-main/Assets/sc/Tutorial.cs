using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public int step;
    public GameObject slider_Obj;
    public Slider slider_sli;
    public Text quest;
    public GameObject quest_obj;
    public GameObject tutorial_obj;

    public player2 _player2;

    public static bool ray;
    //public CheckBox _checkBox;
    // Start is called before the first frame update
    void Start()
    {

        if (CheckBox.bool_t)
        {
            tutorial_obj.SetActive(true);
            quest_obj.SetActive(true);

            slider_sli.value = 0;
            step = 1;
            Debug.Log("A");
            CameraControll.active_camera = false;
            _player2.inventoy__ = false;
            _player2.Craft_ = false;
            ray = false;
        }
        else
        {

            quest_obj.SetActive(false);
            tutorial_obj.SetActive(false);

            step = 0;
            //Debug.Log("B");
            CameraControll.active_camera = true;
            _player2.inventoy__ = true;
            _player2.Craft_ = true;
            ray = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (step == 1)
        {

            slider_Obj.SetActive(true);
            quest.text = "WASDを押して移動しよう";
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
            {
                slider_sli.value += 0.05f;
                if (slider_sli.value == 10)
                {
                    step = 2;
                    slider_sli.value = 0;
                }

            }
        }
        if (step == 2)
        {
            CameraControll.active_camera = true;
            slider_Obj.SetActive(true);
            quest.text = "マウスで視点を移動しよう";
            float a = Input.GetAxis("Mouse Y") * -1 + Input.GetAxis("Mouse X") * -1;


            if (a != 0)
            {
                slider_sli.value += 0.05f;
                if (slider_sli.value == 10)
                {
                    step = 3;
                }
            }

        }
        if (step == 3)
        {
            _player2.inventoy__ = true;
            slider_Obj.SetActive(false);
            quest.text = "Eを押して持ち物を見よう";

            if (_player2.inventoy.activeSelf)
            {

                step = 4;

            }
        }
        if (step == 4)
        {
            slider_Obj.SetActive(false);
            quest.text = "Eをもう一度押して閉じよう";

            if (!_player2.inventoy.activeSelf)
            {

                step = 5;

            }
        }
        if (step == 5)
        {
            _player2.Craft_ = true;
            slider_Obj.SetActive(false);
            quest.text = "Cを押してクラフト画面を開こう";

            if (_player2.Craft.activeSelf)
            {

                step = 6;

            }
        }
        if (step == 6)
        {
            slider_Obj.SetActive(false);
            quest.text = "Cを押してクラフト画面を閉じよう";

            if (!_player2.Craft.activeSelf)
            {

                step = 7;

            }
        }
        if (step == 7)
        {
            ray = true;
            slider_Obj.SetActive(false);
            quest.text = "アイテムに視点を合わせよう";
            if (Ray_.a == 1)
            {
                step = 8;
            }
        }
        if (step == 8)
        {
            slider_Obj.SetActive(false);
            quest.text = "クリアしよう";
            float a = Input.GetAxis("Mouse Y") * -1 + Input.GetAxis("Mouse X") * -1;
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (a != 0))
            {
                quest_obj.SetActive(false);
                tutorial_obj.SetActive(false);
            }
        }



    }

}
