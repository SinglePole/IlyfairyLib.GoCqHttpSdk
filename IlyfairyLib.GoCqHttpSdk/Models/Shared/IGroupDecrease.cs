namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 群成员增加
/// </summary>
public interface IGroupDecrease
{
    /// <summary>
    /// 加入者QQ号
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 事件子类型 （leave、kick、kick_me 分别表示主动退群、成员被踢、登录号被踢）
    /// </summary>
    public string SubType { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 操作者 QQ 号 ( 如果是主动退群, 则和 user_id 相同 )
    /// </summary>
    public long OperatorId { get; init; }
}
