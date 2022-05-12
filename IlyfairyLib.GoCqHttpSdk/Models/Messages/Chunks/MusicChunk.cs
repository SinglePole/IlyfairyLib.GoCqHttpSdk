namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 音乐卡片
/// </summary>
public sealed class MusicChunk : MessageChunk , ICustomMusic
{
    public override MessageChunkType Type => MessageChunkType.music;
    /// <summary>
    /// 音乐类型
    /// </summary>
    public MusicType MusicType { get; }
    /// <summary>
    /// 音乐ID
    /// </summary>
    public long ID { get; }

    /// <summary>
    /// 自定义音乐卡片跳转链接
    /// </summary>
    public string? Url { get; private set; }
    /// <summary>
    /// 自定义音乐卡片音频链接
    /// </summary>
    public string? AudioUrl { get; private set; }
    /// <summary>
    /// 自定义音乐卡片标题
    /// </summary>
    public string? Title { get; private set; }
    /// <summary>
    /// 自定义音乐卡片内容描述
    /// </summary>
    public string? Content { get; private set; }
    /// <summary>
    /// 自定义音乐卡片封面图像链接
    /// </summary>
    public string? Image { get; private set; }

    /// <summary>
    /// 初始化音乐卡片
    /// </summary>
    /// <param name="type">音乐类型<br/>非Custom</param>
    /// <param name="id">音乐ID</param>
    public MusicChunk(MusicType type, long id)
    {
        MusicType = type;
        ID = id;
        Data["type"] = MusicType switch
        {
            MusicType.QQMusic => "qq",
            MusicType.Netease => "163",
            MusicType.XiaMi => "xm",
            _ => "",
        };
        Data["id"] = id;
    }

    /// <summary>
    /// 初始化自定义音乐卡片
    /// </summary>
    /// <param name="url">跳转链接</param>
    /// <param name="audioUrl">音频链接</param>
    /// <param name="title">标题</param>
    /// <param name="content">内容描述</param>
    /// <param name="imageUrl">封面链接</param>
    public MusicChunk(string url, string audioUrl, string title, string content, string imageUrl)
    {
        Data["type"] = "custom";
        Data["url"] = url;
        Data["audio"] = audioUrl;
        Data["title"] = title;
        Data["content"] = content;
        Data["image"] = imageUrl;

        this.Url = url;
        this.AudioUrl = audioUrl;
        this.Title = title;
        this.Content = content;
        this.Image = imageUrl;
    }
}

/// <summary>
/// 音乐类型
/// </summary>
public enum MusicType
{
    /// <summary>
    /// 自定义
    /// </summary>
    Custom,
    /// <summary>
    /// QQ音乐
    /// </summary>
    QQMusic,
    /// <summary>
    /// 网易云音乐
    /// </summary>
    Netease,
    /// <summary>
    /// 虾米音乐
    /// </summary>
    XiaMi,
}

/// <summary>
/// 自定义音乐接口
/// </summary>
public interface ICustomMusic
{
    /// <summary>
    /// 跳转链接
    /// </summary>
    public string Url { get; }
    /// <summary>
    /// 音频链接
    /// </summary>
    public string AudioUrl { get; }
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; }
    /// <summary>
    /// 内容描述
    /// </summary>
    public string Content { get; }
    /// <summary>
    /// 封面图片链接
    /// </summary>
    public string Image { get; }
}