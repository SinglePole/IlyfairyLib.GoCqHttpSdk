namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 链接分享
/// </summary>
public sealed class ShareChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.share;
    public string Url { get; }
    public string Title { get; }
    public ShareChunk(string url, string title)
    {
        Url = url;
        Title = title;
        Data["url"] = url;
        Data["title"] = title;
    }
}
