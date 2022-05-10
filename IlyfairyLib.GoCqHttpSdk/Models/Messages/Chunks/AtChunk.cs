using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 艾特QQ
/// </summary>
public sealed class AtChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.at;

    private long qq;

    /// <summary>
    /// 被艾特的QQ
    /// </summary>
    public long QQ
    {
        get { return qq; }
        set { qq = value; Data["qq"] = value; }
    }

    /// <summary>
    /// 初始化艾特消息块
    /// </summary>
    /// <param name="qq">要艾特的qq</param>
    public AtChunk(long qq)
    {
        if (qq < 0) qq = 0;
        QQ = qq;
    }
    internal AtChunk()
    {
    }

    /// <summary>
    /// 艾特所有人
    /// </summary>
    public static AtChunk All
    {
        get
        {
            AtChunk at = new();
            at.qq = -1;
            at.Data["qq"] = "all";
            return at;
        }
    }

    /// <summary>
    /// 是否艾特所有人
    /// </summary>
    public bool IsAtAll { get => qq is -1; }

    public static new AtChunk? Parse(JToken json)
    {
        AtChunk? result = null;
        if (json["data"]?.Value<string>("qq") is string qq)
        {
            if (qq == "all")
            {
                result = All;
                result.QQ = -1;
            }
            else
            {
                result = new AtChunk(long.Parse(qq));
            }
            result.Data = json as JObject;
        }
        return result;
    }

    /// <summary>
    /// 判断两个at是否相等
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(AtChunk left, AtChunk right)
    {
        return left.qq == right.QQ;
    }

    /// <summary>
    /// 判断两个at是否不相等
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(AtChunk left, AtChunk right)
    {
        return !(left == right);
    }
}
