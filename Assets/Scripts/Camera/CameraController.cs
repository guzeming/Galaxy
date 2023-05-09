using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("���������")]
    public float mouseSensitivity = 5f;
    [Header("������ת��С�Ƕ�")]
    public float minRotate = -70f;
    [Header("������ת���Ƕ�")]
    public float maxRotate = 70f;

    //ͷ��
    private Transform head;
    private float mouseX = 0f;
    private float mouseY = 0f;

    private void Awake()
    {
        //��ȡ���
        head = transform.Find("Camera");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //��ȡ����ת������
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        //��ȡ����ת������
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity;

        //����ת�����Ʒ�Χ
        mouseY = Mathf.Clamp(mouseY, minRotate, maxRotate);

        //�����������������ת�����������²��ɶ�
        Quaternion quaternionX = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion quaternionY = Quaternion.AngleAxis(0, Vector3.left);
        transform.rotation = quaternionX * quaternionY;
        //�����������ת��
        quaternionY = Quaternion.AngleAxis(mouseY, Vector3.left);
        //head.rotation = quaternionX* quaternionY;

        //�����ֵ�Ч��
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
