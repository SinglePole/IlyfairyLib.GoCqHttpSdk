using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 图片消息
/// </summary>
public sealed class ImageChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.image;
    public string File { get; }
    public string Url { get; internal set; }
    public bool IsFlash { get; }
    public ImageChunk(string file, bool isFlash = false, bool isCache = true, bool isProxy = true, int timeout = 10)
    {
        this.Data["file"] = file;
        IsFlash = isFlash;
        if (isFlash) Data["type"] = "flash";
        if (!isCache) Data["cache"] = 0;
        if (!isProxy) Data["proxy"] = 0;
        if (timeout >= 0) this.Data["timeout"] = timeout;
    }
    internal ImageChunk(string file, string url, bool isFlash)
    {
        File = file;
        Url = url;
        IsFlash = isFlash;
    }

    public static new ImageChunk? Parse(JToken json)
    {
        var data = json["data"];
        var image = new ImageChunk(data.Value<string>("file"), data.Value<string>("url"), data.Value<bool>("flash"));
        image.Data = data as JObject;
        return image;
    }
}
