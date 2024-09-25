using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DirtManager : MonoBehaviour
{
    public Material black; // 자동차에 적용된 Material
    public Texture2D dirtTexture; // 더러움 텍스처
    private float dirtiness = 1f; // 초기 더러움 정도 (0: 깨끗함, 1: 매우 더러움)

    void Start()
    {
        // 초기 더러움 텍스처를 설정
        black.SetTexture("_MainTex", dirtTexture);
        UpdateDirtiness();
    }

    public void Clean(float amount)
    {
        dirtiness -= amount;
        if (dirtiness < 0) dirtiness = 0;
        UpdateDirtiness();
    }

    private void UpdateDirtiness()
    {
        // 더러움 정도에 따라 알파 값을 조절
        Color color = black.color;
        color.a = dirtiness;
        black.color = color;
    }
}

