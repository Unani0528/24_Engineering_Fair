using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스 입력에 따라 카메라를 회전시키고 싶다.
// 필요 속성: 현재 각도, 마우스 감도
public class CamRotate : MonoBehaviour
{
    // 현재 각도
    Vector3 angle;
    // 마우스 감도
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
