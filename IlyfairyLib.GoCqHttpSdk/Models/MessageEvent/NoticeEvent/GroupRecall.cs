using IlyfairyLib.GoCqHttpSdk.Api;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 通知消息 - 群消息撤回
/// </summary>
public class GroupRecall : MessageEventBase, IGroupRecall
{
    public override MessageType MessageSubType => MessageType.NoticeGroupRecall;
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
    public GroupRecall(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        OperatorId = json.Value<long>("operator_id");
        UserId = json.Value<long>("user_id");
        Time = json.Value<long>("time");
        GroupId = json.Value<long>("group_id");
        MessageId = json.Value<int>("message_id");
    }
}
