using System.IO.Ports;
using UnityEngine;

public class EMGControl : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600); // COM 포트와 baud rate 설정
    public int RArm = 0; // 오른팔 움직임 상태

    void Start()
    {
        serialPort.Open(); // 직렬 포트 열기
        serialPort.ReadTimeout = 1000; // 시간 초과 설정
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine(); // Arduino로부터 데이터를 받음
                RArm = int.Parse(data); // 받은 데이터를 정수형으로 변환
                Debug.Log("Right Arm Movement: " + RArm); // 데이터 로그 출력
            }
            catch (System.Exception) { }
        }
    }

    void OnApplicationQuit()
    {
        serialPort.Close(); // 종료 시 직렬 포트 닫기
    }
}
