namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 群管理员变动
/// </summary>
public interface IGroupAdmin
{
    /// <summary>
    /// 管理员QQ号
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 事件子类型, 分别表示设置和取消管理员(可能的值：set、unset)
    /// </summary>
    public string SubType { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
}
