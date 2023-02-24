namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 群禁言
/// </summary>
public interface IGroupBan
{
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 操作者 QQ 号
    /// </summary>
    public long OperatorId { get; init; }
    /// <summary>
    /// 被禁言 QQ 号 (为全员禁言时为0)
    /// </summary>
    public long QQ { get; init; }
    /// <summary>
    /// 禁言时长, 单位秒 (为全员禁言时为-1)
    /// </summary>
    public long Duration { get; init; }
}
