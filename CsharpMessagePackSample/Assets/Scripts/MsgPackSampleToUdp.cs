using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class MsgPackSampleToUdp : MonoBehaviour
{
    [SerializeField] private MsgPackFormatFamily.FormatFamily formatFamily = MsgPackFormatFamily.FormatFamily.Array;
    [SerializeField] private string ipAddress = "127.0.0.1";
    [SerializeField] private uint port = 1234;

    private IMsgPackSampleData sampleData;

    private UdpClient udpClient;
    private IPEndPoint endPoint;
    private bool isRunningSender;

    private void Start()
    {
        sampleData = formatFamily switch
        {
            MsgPackFormatFamily.FormatFamily.Array => new MsgPackArraySampleData(true, 0),
            MsgPackFormatFamily.FormatFamily.Map => new MsgPackMapSampleData(true, 0),
            _ => throw new ArgumentOutOfRangeException()
        };

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

        var data = sampleData.Serialize(sampleData);
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