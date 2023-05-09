using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移动速度")]
    public float speed = 2f;
    [Header("检测范围")]
    public float checkRadius = 0.5f;
    [Header("检测层级")]
    public LayerMask checkLayout;
    [Header("跳跃高度")]
    public float jumpHeight = 5f;
    [Header("重力")]
    public float gravity = 9.8f;

    //角色控制组件
    private CharacterController characterController;
    //碰撞检测体
    private Transform checkGround;
    //是否接触地面
    private bool isGround;
    //用于计算下降的速度，x和z没什么用，默认为0
    private Vector3 velocity;

    private void Awake()
    {
        //获取角色控制组件
        characterController = GetComponent<CharacterController>();
        //获取碰撞检测体
        checkGround = transform.Find("CheckGround");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //球型检测 checkRadius检测半径尽量调小一点，太大了会出现连跳的情况
        isGround = Physics.CheckSphere(checkGround.position, checkRadius, checkLayout);
        //如果触碰地面并且下降速度小于0，速度就不在变化，小编亲测:给小于0的值会比给0效果更好
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //左右移动变化值
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //上下移动变化值
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //算出移动方向向量
        Vector3 moveDir = transform.forward * vertical + transform.right * horizontal;
        //人物移动
        this.transform.LookAt(moveDir);
        characterController.Move(moveDir);
        

        //如果接触地面并且按下空格键，就给一个向上的速度，实现跳跃。
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }
        //在重力作用下，速度不断减小，为负数时开始下降，这样赋值感觉更为真实
        velocity.y -= gravity * Time.deltaTime;
        //只完成向下的移动
        characterController.Move(velocity * Time.deltaTime);
    }


}

