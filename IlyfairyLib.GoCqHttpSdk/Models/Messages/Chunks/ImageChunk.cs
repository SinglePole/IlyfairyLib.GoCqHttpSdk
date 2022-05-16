using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 图片消息
/// </summary>
public sealed class ImageChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.image;
    /// <summary>
    /// 图片缓存文件名
    /// </summary>
    public string File { get; }
    /// <summary>
    /// 图片子类型(只出现在群聊)
    /// </summary>
    public ImageSubType SubType { get;private set; } = ImageSubType.正常图片;
    /// <summary>
    /// 图片特效ID
    /// </summary>
    public ImageId Id { get; } = ImageId.普通;
    /// <summary>
    /// 图片类型
    /// </summary>
    public ImageType ImageType { get; } = ImageType.Default;
    public string Url { get; internal set; }
    public ImageChunk(string file, bool isCache = true, ImageType type = ImageType.Default, ImageId id = ImageId.普通,ImageSubType subType = ImageSubType.正常图片)
    {
        this.Data["file"] = file;
        Data["type"] = type switch
        {
            ImageType.Default => "",
            ImageType.Flash => "flash",
            ImageType.Show => "show",
            _ => "",
        };
        Data["id"] = (int)id;
        Data["subType"] = (int)subType;
        if (!isCache) Data["cache"] = 0;
    }
    internal ImageChunk(string file, string url)
    {
        File = file;
        Url = url;
    }

    public static new ImageChunk? Parse(JToken json)
    {
        var data = json["data"];
        var image = new ImageChunk(data.Value<string>("file"), data.Value<string>("url"));
        image.Data = data as JObject;
        image.SubType = (ImageSubType)data.Value<int>("subType");
        return image;
    }
}

/// <summary>
/// 图片子类型
/// </summary>
public enum ImageSubType
{
    正常图片 = 0,
    表情包 = 1,
    热图 = 2,
    斗图 = 3,
    智图 = 4,
    贴图 = 7,
    自拍 = 8,
    贴图广告 = 9,
    未知 = 10, //有待测试
    热搜图 = 13,
}

/// <summary>
/// 图片特效ID
/// </summary>
public enum ImageId
{
    普通 = 40000,
    幻影 = 40001,
    抖动 = 40002,
    生日 = 40003,
    爱你 = 40004,
    征友 = 40005,
}

/// <summary>
/// 图片类型
/// </summary>
public enum ImageType
{
    /// <summary>
    /// 默认图片
    /// </summary>
    Default,
    /// <summary>
    /// 闪照
    /// </summary>
    Flash,
    /// <summary>
    /// 秀图
    /// </summary>
    Show,
}