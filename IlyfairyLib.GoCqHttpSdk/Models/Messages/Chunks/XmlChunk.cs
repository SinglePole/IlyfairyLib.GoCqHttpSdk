namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// Xml消息
/// </summary>
public sealed class XmlChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.xml;
    public string Xml { get; }
    public XmlChunk(string xml)
    {
        Xml = xml;
        Data["data"] = xml;
    }

    public static new XmlChunk? Parse(JToken json)
    {
        var data = json["data"];
        var xmlChunk = new XmlChunk(data.Value<string>("data"));
        xmlChunk.Data = data as JObject;
        return xmlChunk;
    }
}
