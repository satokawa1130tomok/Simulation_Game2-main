using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void start()
    {
        SceneManager.LoadScene("start");
    }
    public void play()
    {
        //Debug.Log(WorldName.text);
        if (WorldName.text != "")
        {
            SceneManager.LoadScene("game");
            //Debug.Log("A");
        }
    }
    public void goal()
    {
        SceneManager.LoadScene("goal");
    }
}
