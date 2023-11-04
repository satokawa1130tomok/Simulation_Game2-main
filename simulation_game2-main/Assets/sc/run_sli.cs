using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class run_sli : MonoBehaviour
{
    public static float run_value;
    public Slider run_slider;
    public float value_speed = 0.1f;
    public Image sliderImage;
    // Start is called before the first frame update
    void Start()
    {

        run_slider = GetComponent<Slider>();
        run_slider.value = 100f;
        sliderImage.color = new Color32(0, 255, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (player2.run)
        {
            run_slider.value -= value_speed;
        }
        else if ((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift)) || (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.W)))
            run_slider.value += value_speed * 1.2f;

        run_value = run_slider.value;
        if (run_value >= 60)
        {
            sliderImage.color = new Color32(0, 255, 0, 255);
        }
        if (run_value >= 30 && run_value < 60)
        {
            sliderImage.color = new Color32(255, 255, 0, 255);
        }
        if (run_value < 30 && run_value > 0)
        {
            sliderImage.color = new Color32(255, 0, 0, 255);
        }
        if (run_value == 0) { sliderImage.color = new Color32(255, 0, 0, 0); }
    }
}
