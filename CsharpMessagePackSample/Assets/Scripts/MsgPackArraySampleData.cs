using MessagePack;

[MessagePackObject]
public class MsgPackArraySampleData : IMsgPackSampleData
{
    [Key(0)] public bool Compact { get; set; }
    [Key(1)] public int Schema { get; set; }

    public MsgPackArraySampleData()
    {
    }

    public MsgPackArraySampleData(bool compact, int schema)
    {
        Compact = compact;
        Schema = schema;
    }

    public byte[] Serialize(IMsgPackSampleData sampleData)
    {
        return MessagePackSerializer.Serialize((MsgPackArraySampleData)sampleData);
    }

    public IMsgPackSampleData Deserialize(byte[] binaryData)
    {
        return MessagePackSerializer.Deserialize<MsgPackArraySampleData>(binaryData);
    }
}