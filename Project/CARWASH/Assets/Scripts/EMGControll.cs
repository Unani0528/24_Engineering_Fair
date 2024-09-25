using System.IO.Ports;
using UnityEngine;

public class EMGControl : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600); // COM ��Ʈ�� baud rate ����
    public int RArm = 0; // ������ ������ ����

    void Start()
    {
        serialPort.Open(); // ���� ��Ʈ ����
        serialPort.ReadTimeout = 1000; // �ð� �ʰ� ����
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine(); // Arduino�κ��� �����͸� ����
                RArm = int.Parse(data); // ���� �����͸� ���������� ��ȯ
                Debug.Log("Right Arm Movement: " + RArm); // ������ �α� ���
            }
            catch (System.Exception) { }
        }
    }

    void OnApplicationQuit()
    {
        serialPort.Close(); // ���� �� ���� ��Ʈ �ݱ�
    }
}
