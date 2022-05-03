using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class MsgPackSampleToUdp : MonoBehaviour
{
    [SerializeField] private string ipAddress = "127.0.0.1";
    [SerializeField] private uint port = 1234;

    private UdpClient udpClient;
    private IPEndPoint endPoint;
    private bool isRunningSender;

    private void Start()
    {
        endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), (int)port);
        udpClient = new UdpClient();
        udpClient.Connect(endPoint);
        isRunningSender = true;
    }

    private void Update()
    {
        if (!isRunningSender)
        {
            return;
        }

        var sampleData = new MsgPackSampleData(true, 0);
        var data = MsgPackSampleData.Serialize(sampleData);
        udpClient.Send(data, data.Length);
    }

    private void OnDestroy()
    {
        if (!isRunningSender)
        {
            return;
        }

        if (udpClient != null)
        {
            udpClient.Close();
            udpClient.Dispose();
        }

        isRunningSender = false;
    }
}