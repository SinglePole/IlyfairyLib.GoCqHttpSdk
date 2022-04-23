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
        Data["data"] = json;
    }

    public static new JsonChunk? Parse(JToken json)
    {
        var data = json["data"];
        var jsonChunk = new JsonChunk(data.Value<string>("data"));
        jsonChunk.Data = data as JObject;
        return jsonChunk;
    }
}
