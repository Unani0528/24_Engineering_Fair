using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTransparencyController : MonoBehaviour
{
    public float cleaningSpeed = 0.002f; // 수건에 닿았을 때 알파 값이 감소하는 속도. 값이 높아질수록 빨라짐
    private float currentAlpha = 1.0f; // 현재 알파 값 (처음에는 불투명)
    private Material dustMaterial; // 먼지 오브젝트의 재질
    private bool isCleaning = false; // 수건이 닿았는지 여부를 확인하는 변수

    private void Start()
    {
        // 먼지 오브젝트의 재질을 가져옴
        dustMaterial = GetComponent<Renderer>().material;

        // 초기 알파 값 설정
        Color color = dustMaterial.color;
        color.a = currentAlpha;
        dustMaterial.color = color;
    }

    private void Update()
    {
        // 수건이 닿아있는 동안 알파 값을 감소시킴
        if (isCleaning && currentAlpha > 0f)
        {
            currentAlpha -= cleaningSpeed * Time.deltaTime;
            currentAlpha = Mathf.Clamp01(currentAlpha); // 알파 값이 0 이하로 떨어지지 않도록
            Color color = dustMaterial.color;
            color.a = currentAlpha;
            dustMaterial.color = color;

            Debug.Log("현재 알파 값: " + currentAlpha); // 디버깅 메시지
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 이름이 "towel"인지 확인
        if (other.gameObject.name == "towel")
        {
            isCleaning = true;
            Debug.Log("수건이 먼지에 닿음"); // 디버깅 메시지
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 충돌이 끝난 오브젝트의 이름이 "towel"인지 확인
        if (other.gameObject.name == "towel")
        {
            isCleaning = false;
            Debug.Log("수건이 먼지에서 떨어짐"); // 디버깅 메시지
        }
    }
}
