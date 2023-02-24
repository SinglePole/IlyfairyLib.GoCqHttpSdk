namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 好友消息撤回
/// </summary>
public interface IFriendRecall
{
    /// <summary>
    /// QQ
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 消息ID
    /// </summary>
    public int MessageId { get; init; }
}
