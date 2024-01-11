using UnityEngine;

public class ActiveSelf : MonoBehaviour
{

    public GameObject targetGameobject;
    public static bool inv_activeSelf;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ///Debug.Log("1"+targetGameobject.gameObject.activeSelf);
        //Debug.Log("2"+targetGameobject.gameObject.activeInHierarchy);
        inv_activeSelf = targetGameobject.gameObject.activeSelf;


    }
}
