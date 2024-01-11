using UnityEngine;
using UnityEngine.UI;

public class SaveText : MonoBehaviour
{
    public float repeatSpan;
    private float timeElapsed;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;
        text.text = "セーブ中";
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= repeatSpan)
        {
            timeElapsed = 0f;
            if (text.text == "セーブ中")
            {

                text.text = "セーブ中・";

            }
            else if (text.text == "セーブ中・")
            {
                text.text = "セーブ中・・";
            }
            else if (text.text == "セーブ中・・")
            {
                text.text = "セーブ中・・・";
            }
            else if (text.text == "セーブ中・・・")
            {
                text.text = "セーブ中";
            }
        }
    }
}
