namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 短视频
/// </summary>
public sealed class VideoChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.video;
    public string File { get; }
    public string Url { get; internal set; }
    public VideoChunk(string file, bool isCache = true, bool isProxy = true, int timeout = 10)
    {
        this.Data["file"] = file;
        if (!isCache) Data["cache"] = 0;
        if (!isProxy) Data["proxy"] = 0;
        if (timeout >= 0) this.Data["timeout"] = timeout;
    }
    internal VideoChunk(string file, string url)
    {
        File = file;
        Url = url;
    }
}
