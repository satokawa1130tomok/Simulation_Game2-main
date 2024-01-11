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
        text.text = "�Z�[�u��";
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= repeatSpan)
        {
            timeElapsed = 0f;
            if (text.text == "�Z�[�u��")
            {

                text.text = "�Z�[�u���E";

            }
            else if (text.text == "�Z�[�u���E")
            {
                text.text = "�Z�[�u���E�E";
            }
            else if (text.text == "�Z�[�u���E�E")
            {
                text.text = "�Z�[�u���E�E�E";
            }
            else if (text.text == "�Z�[�u���E�E�E")
            {
                text.text = "�Z�[�u��";
            }
        }
    }
}
