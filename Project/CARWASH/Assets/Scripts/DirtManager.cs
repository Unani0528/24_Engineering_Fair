using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DirtManager : MonoBehaviour
{
    public Material black; // �ڵ����� ����� Material
    public Texture2D dirtTexture; // ������ �ؽ�ó
    private float dirtiness = 1f; // �ʱ� ������ ���� (0: ������, 1: �ſ� ������)

    void Start()
    {
        // �ʱ� ������ �ؽ�ó�� ����
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
        // ������ ������ ���� ���� ���� ����
        Color color = black.color;
        color.a = dirtiness;
        black.color = color;
    }
}

