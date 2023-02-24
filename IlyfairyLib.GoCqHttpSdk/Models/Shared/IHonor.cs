namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 群成员荣誉变更提示
/// </summary>
public interface IHonor
{
    /// <summary>
    /// 时间
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 成员id
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 荣誉类型 （talkative:龙王 performer:群聊之火 emotion:快乐源泉）
    /// </summary>
    public string HonorType { get; init; }
}
