using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("鼠标灵敏度")]
    public float mouseSensitivity = 5f;
    [Header("上下旋转最小角度")]
    public float minRotate = -70f;
    [Header("上下旋转最大角度")]
    public float maxRotate = 70f;

    //头部
    private Transform head;
    private float mouseX = 0f;
    private float mouseY = 0f;

    private void Awake()
    {
        //获取相机
        head = transform.Find("Camera");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //获取左右转动度数
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        //获取上下转动度数
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity;

        //上下转动限制范围
        mouseY = Mathf.Clamp(mouseY, minRotate, maxRotate);

        //控制相机和人物左右转动，人物上下不可动
        Quaternion quaternionX = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion quaternionY = Quaternion.AngleAxis(0, Vector3.left);
        transform.rotation = quaternionX * quaternionY;
        //控制相机上下转动
        quaternionY = Quaternion.AngleAxis(mouseY, Vector3.left);
        //head.rotation = quaternionX* quaternionY;

        //鼠标滚轮的效果
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 20)
                Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 0.5F;
        }

    }

}
