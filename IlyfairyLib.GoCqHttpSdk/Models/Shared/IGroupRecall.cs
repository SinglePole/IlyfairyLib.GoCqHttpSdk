namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 群消息撤回
/// </summary>
public interface IGroupRecall
{
    /// <summary>
    /// 操作QQ
    /// </summary>
    public long OperatorId { get; init; }
    /// <summary>
    /// 被操作QQ
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 消息ID
    /// </summary>
    public int MessageId { get; init; }
}
