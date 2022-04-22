namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 音乐卡片
/// </summary>
public sealed class MusicChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.music;
    public MusicType MusicType { get; }
    public long ID { get; }
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
}

/// <summary>
/// 音乐类型
/// </summary>
public enum MusicType
{
    QQMusic,
    Netease,
    XiaMi,
}
