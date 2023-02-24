namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 群成员增加
/// </summary>
public interface IGroupIncrease
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
    /// 事件子类型 （approve、invite 分别表示管理员已同意入群、管理员邀请入群）
    /// </summary>
    public string SubType { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 操作者 QQ 号
    /// </summary>
    public long OperatorId { get; init; }
}
