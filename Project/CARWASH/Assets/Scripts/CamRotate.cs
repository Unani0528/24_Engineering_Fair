using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���콺 �Է¿� ���� ī�޶� ȸ����Ű�� �ʹ�.
// �ʿ� �Ӽ�: ���� ����, ���콺 ����
public class CamRotate : MonoBehaviour
{
    // ���� ����
    Vector3 angle;
    // ���콺 ����
    public float sensitivity = 700.0f;
    float rotationX;
    float rotationY;

    void Update()
    {

        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");
        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        rotationY %= 360;
        rotationX %= 360;

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
   

    }
}
