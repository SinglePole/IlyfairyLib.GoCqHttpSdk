using IlyfairyLib.GoCqHttpSdk.Api;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 群成员减少
/// </summary>
public class GroupDecrease : MessageEventBase, IGroupDecrease
{
    public override MessageType MessageSubType => MessageType.NoticeGroupDecrease;
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
    public GroupDecrease(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        OperatorId = json.Value<long>("operator_id");
        UserId = json.Value<long>("user_id");
        Time = json.Value<long>("time");
        GroupId = json.Value<long>("group_id");
        SubType = json.Value<string>("sub_type") ?? "";
    }
}
