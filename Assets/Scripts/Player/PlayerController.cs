using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�ƶ��ٶ�")]
    public float speed = 2f;
    [Header("��ⷶΧ")]
    public float checkRadius = 0.5f;
    [Header("���㼶")]
    public LayerMask checkLayout;
    [Header("��Ծ�߶�")]
    public float jumpHeight = 5f;
    [Header("����")]
    public float gravity = 9.8f;

    //��ɫ�������
    private CharacterController characterController;
    //��ײ�����
    private Transform checkGround;
    //�Ƿ�Ӵ�����
    private bool isGround;
    //���ڼ����½����ٶȣ�x��zûʲô�ã�Ĭ��Ϊ0
    private Vector3 velocity;

    private void Awake()
    {
        //��ȡ��ɫ�������
        characterController = GetComponent<CharacterController>();
        //��ȡ��ײ�����
        checkGround = transform.Find("CheckGround");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���ͼ�� checkRadius���뾶������Сһ�㣬̫���˻�������������
        isGround = Physics.CheckSphere(checkGround.position, checkRadius, checkLayout);
        //����������沢���½��ٶ�С��0���ٶȾͲ��ڱ仯��С���ײ�:��С��0��ֵ��ȸ�0Ч������
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //�����ƶ��仯ֵ
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //�����ƶ��仯ֵ
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //����ƶ���������
        Vector3 moveDir = transform.forward * vertical + transform.right * horizontal;
        //�����ƶ�
        this.transform.LookAt(moveDir);
        characterController.Move(moveDir);
        

        //����Ӵ����沢�Ұ��¿ո�����͸�һ�����ϵ��ٶȣ�ʵ����Ծ��
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }
        //�����������£��ٶȲ��ϼ�С��Ϊ����ʱ��ʼ�½���������ֵ�о���Ϊ��ʵ
        velocity.y -= gravity * Time.deltaTime;
        //ֻ������µ��ƶ�
        characterController.Move(velocity * Time.deltaTime);
    }


}

