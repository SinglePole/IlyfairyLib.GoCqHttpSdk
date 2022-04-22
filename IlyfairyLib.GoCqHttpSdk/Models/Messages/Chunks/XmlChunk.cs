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
        Data["xml"] = xml;
    }
}
