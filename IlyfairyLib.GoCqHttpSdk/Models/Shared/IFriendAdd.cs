namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 好友添加
/// </summary>
public interface IFriendAdd
{
    /// <summary>
    /// 发送者QQ号
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 时间戳
    /// </summary>
    public long Time { get; init; }
}
