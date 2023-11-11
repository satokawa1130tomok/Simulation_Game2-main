using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public GameObject mainCamera;              //���C���J�����i�[�p
    public GameObject playerObject;            //��]�̒��S�ƂȂ�v���C���[�i�[�p
    public float rotateSpeed = 2.0f;            //��]�̑���
    public static bool active_camera;
    public float max = 180.0f;


    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {

        //���C���J�����ƃ��j�e�B���������ꂼ��擾
        //mainCamera = Camera.main.gameObject;
        //playerObject = GameObject.Find("unitychan");
        active_camera = true;
    }


    //�P�ʎ��Ԃ��ƂɎ��s�����֐�
    void Update()
    {
        //rotateCamera�̌Ăяo��
        if (active_camera == true)
        {
            rotateCamera();

        }
        Max();




    }

    //�J��������]������֐�
    private void rotateCamera()
    {
        // //Vector3��X,Y�����̉�]�̓x�������`
        // Vector3 angle = new Vector3(0, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        // //transform.RotateAround()�����悤���ă��C���J��������]������
        //// mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        // mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.forward, angle.y);
        Transform myTransform = mainCamera.transform;
        Vector3 worldAngle = myTransform.eulerAngles;
        float MouseY = Input.GetAxis("Mouse Y") * rotateSpeed * -1;
        worldAngle.x += MouseY;
        myTransform.eulerAngles = worldAngle;

    }
    private void Max()
    {



    }
}