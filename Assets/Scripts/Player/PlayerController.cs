using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 4;
    public float Vs = 1;
    public float Hs = 1;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        /*// ˮƽ�ƶ� ���ص�ֵ�Ǹ����� ����[-1,1]����A��-1 ��D��1�����ö�Ӧ����
        float h = Input.GetAxisRaw("Horizontal");
        // ��ֱ�ƶ� ���ص�ֵ�Ǹ����� ����[-1,1]����S��-1 ��W��1�����ö�Ӧ����
        float v = Input.GetAxisRaw("Vertical");
        cc.SimpleMove(new Vector3(h, 0, v) * speed);*/
        Vector3 trans = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            trans += transform.forward;
            //transform.Translate(Vector3.forward * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            trans +=  -transform.forward;
            //transform.Translate(Vector3.back * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            trans +=  -transform.right;
            //transform.Translate(Vector3.left * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            trans += transform.right;
            //transform.Translate(Vector3.right * speed, Space.Self);
        }

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(x) > 0.1f || Mathf.Abs(y) > 0.1)
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Hs);
            //transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Vs);
            Debug.Log(transform.forward);
            //transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Vs);
            //transform.LookAt(targetDir + transform.position);
        }

        cc.SimpleMove(trans * speed);

        
    }

}

