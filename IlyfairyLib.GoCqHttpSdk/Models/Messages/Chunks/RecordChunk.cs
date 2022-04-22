namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 语音消息
/// </summary>
public sealed class RecordChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.video;
    public string File { get; }
    public string Url { get; internal set; }
    public bool IsMagic { get; }
    public RecordChunk(string file, bool isMagic = false, bool isCache = true, bool isProxy = true, int timeout = 10)
    {
        this.Data["file"] = file;
        IsMagic = isMagic;
        if (IsMagic) Data["type"] = "flash";
        if (!isCache) Data["cache"] = 0;
        if (!isProxy) Data["proxy"] = 0;
        if (timeout >= 0) this.Data["timeout"] = timeout;
    }
    internal RecordChunk(string file, string url, bool isMagic)
    {
        File = file;
        Url = url;
        IsMagic = isMagic;
    }
}
