using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTransparencyController : MonoBehaviour
{
    public float cleaningSpeed = 0.002f; // ���ǿ� ����� �� ���� ���� �����ϴ� �ӵ�. ���� ���������� ������
    private float currentAlpha = 1.0f; // ���� ���� �� (ó������ ������)
    private Material dustMaterial; // ���� ������Ʈ�� ����
    private bool isCleaning = false; // ������ ��Ҵ��� ���θ� Ȯ���ϴ� ����

    private void Start()
    {
        // ���� ������Ʈ�� ������ ������
        dustMaterial = GetComponent<Renderer>().material;

        // �ʱ� ���� �� ����
        Color color = dustMaterial.color;
        color.a = currentAlpha;
        dustMaterial.color = color;
    }

    private void Update()
    {
        // ������ ����ִ� ���� ���� ���� ���ҽ�Ŵ
        if (isCleaning && currentAlpha > 0f)
        {
            currentAlpha -= cleaningSpeed * Time.deltaTime;
            currentAlpha = Mathf.Clamp01(currentAlpha); // ���� ���� 0 ���Ϸ� �������� �ʵ���
            Color color = dustMaterial.color;
            color.a = currentAlpha;
            dustMaterial.color = color;

            Debug.Log("���� ���� ��: " + currentAlpha); // ����� �޽���
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �̸��� "towel"���� Ȯ��
        if (other.gameObject.name == "towel")
        {
            isCleaning = true;
            Debug.Log("������ ������ ����"); // ����� �޽���
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �浹�� ���� ������Ʈ�� �̸��� "towel"���� Ȯ��
        if (other.gameObject.name == "towel")
        {
            isCleaning = false;
            Debug.Log("������ �������� ������"); // ����� �޽���
        }
    }
}
