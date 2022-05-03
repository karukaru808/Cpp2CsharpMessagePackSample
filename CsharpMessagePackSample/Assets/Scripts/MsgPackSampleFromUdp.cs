using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MsgPackSampleFromUdp : MonoBehaviour
{
    [SerializeField] private MsgPackFormatFamily.FormatFamily formatFamily = MsgPackFormatFamily.FormatFamily.Array;
    [SerializeField] private uint port = 1234;

    private UdpClient udpClient;
    private IPEndPoint endPoint;
    private bool isRunningReceiver;

    private CancellationTokenSource tokenSource;

    private void Start()
    {
        endPoint = new IPEndPoint(IPAddress.Any, (int)port);
        udpClient = new UdpClient(endPoint);

        tokenSource = new CancellationTokenSource();

        Task.Run(() => Receive(tokenSource.Token), tokenSource.Token);

        isRunningReceiver = true;
    }

    private void OnDestroy()
    {
        if (!isRunningReceiver)
        {
            return;
        }

        if (udpClient != null)
        {
            udpClient.Close();
            udpClient.Dispose();
        }

        if (tokenSource != null)
        {
            tokenSource.Cancel();
            tokenSource.Dispose();
        }

        isRunningReceiver = false;
    }

    private async Task Receive(CancellationToken token)
    {
        IMsgPackSampleData sampleData = formatFamily switch
        {
            MsgPackFormatFamily.FormatFamily.Array => new MsgPackArraySampleData(),
            MsgPackFormatFamily.FormatFamily.Map => new MsgPackMapSampleData(),
            _ => throw new ArgumentOutOfRangeException()
        };

        while (!token.IsCancellationRequested)
        {
            var data = await udpClient.ReceiveAsync();
            if (data.Buffer == null)
            {
                continue;
            }

            try
            {
                sampleData = sampleData.Deserialize(data.Buffer);
                Debug.Log($"{sampleData.Compact}, {sampleData.Schema}");
            }
            catch (Exception e)
            {
                // parse error
                Debug.LogError("Parse Error!");
            }
        }
    }
}