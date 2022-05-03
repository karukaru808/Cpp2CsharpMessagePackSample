using MessagePack;

[MessagePackObject]
public class MsgPackMapSampleData : IMsgPackSampleData
{
    [Key("compact")] public bool Compact { get; set; }
    [Key("schema")] public int Schema { get; set; }

    public MsgPackMapSampleData()
    {
    }

    public MsgPackMapSampleData(bool compact, int schema)
    {
        Compact = compact;
        Schema = schema;
    }

    public byte[] Serialize(IMsgPackSampleData sampleData)
    {
        return MessagePackSerializer.Serialize((MsgPackMapSampleData)sampleData);
    }

    public IMsgPackSampleData Deserialize(byte[] binaryData)
    {
        return MessagePackSerializer.Deserialize<MsgPackMapSampleData>(binaryData);
    }
}