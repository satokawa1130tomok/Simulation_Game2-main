using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    public string ItemName;
    public int ItemCount;
    private float time;
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        //ItemName = "";
        //ItemCount = 0;
        t = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      
        t.text = (ItemName + "+" + ItemCount);

        time += Time.deltaTime;
        if (time >= 2f)
        {
           Destroy(this.gameObject);
        }
    }
}
