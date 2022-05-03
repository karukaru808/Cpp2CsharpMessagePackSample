using MessagePack;

[MessagePackObject]
public class MsgPackSampleData
{
    [Key(0)] public bool Compact { get; set; }
    [Key(1)] public uint Schema { get; set; }

    public MsgPackSampleData()
    {
    }

    public MsgPackSampleData(bool compact, uint schema)
    {
        Compact = compact;
        Schema = schema;
    }

    public static byte[] Serialize(MsgPackSampleData sampleData)
    {
        return MessagePackSerializer.Serialize(sampleData);
    }

    public static MsgPackSampleData Deserialize(byte[] data)
    {
        return MessagePackSerializer.Deserialize<MsgPackSampleData>(data);
    }
}