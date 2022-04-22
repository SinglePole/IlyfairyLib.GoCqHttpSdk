namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// Json消息
/// </summary>
public sealed class JsonChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.json;
    public string Json { get; }
    public JsonChunk(string json)
    {
        Json = json;
        Data["json"] = json;
    }
}
