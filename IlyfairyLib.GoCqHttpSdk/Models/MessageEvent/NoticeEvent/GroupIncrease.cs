using IlyfairyLib.GoCqHttpSdk.Api;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 群成员增加
/// </summary>
public class GroupIncrease : MessageEventBase, IGroupIncrease
{
    public override MessageType MessageSubType => MessageType.NoticeGroupIncrease;
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
    public GroupIncrease(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        OperatorId = json.Value<long>("operator_id");
        UserId = json.Value<long>("user_id");
        Time = json.Value<long>("time");
        GroupId = json.Value<long>("group_id");
        SubType = json.Value<string>("sub_type") ?? "";
    }
}
