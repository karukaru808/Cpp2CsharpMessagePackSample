using MessagePack;

public interface IMsgPackSampleData
{
    public bool Compact { get; set; }
    public int Schema { get; set; }

    public byte[] Serialize(IMsgPackSampleData sampleData);
    public IMsgPackSampleData Deserialize(byte[] binaryData);
}