namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 戳一戳（此事件无法在手表协议上触发)
/// </summary>
public interface IPoke
{
    /// <summary>
    /// 发送者QQ号
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 提示类型
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 被戳者 QQ 号
    /// </summary>
    public long TargetId { get; init; }
    /// <summary>
    /// 发送者QQ号
    /// </summary>
    public long SenderId { get; init; }
}
