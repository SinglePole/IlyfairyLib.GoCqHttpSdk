namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 群红包运气王提示
/// </summary>
public interface ILuckyKing
{
    /// <summary>
    /// 红包发送者QQ
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
    /// 运气王QQ
    /// </summary>
    public long TargetId { get; init; }
}
