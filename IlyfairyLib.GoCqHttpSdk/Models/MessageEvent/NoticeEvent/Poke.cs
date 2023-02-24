using IlyfairyLib.GoCqHttpSdk.Api;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 通知消息 - 戳一戳
/// </summary>
public class Poke : MessageEventBase, IPoke
{
    public override MessageType MessageSubType => MessageType.NoticePoke;
    /// <summary>
    /// 发送者QQ号
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
    /// 被戳者 QQ 号
    /// </summary>
    public long TargetId { get; init; }
    /// <summary>
    /// 发送者QQ号
    /// </summary>
    public long SenderId { get; init; }
    public Poke(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        UserId = json.Value<long>("user_id");
        Time = json.Value<long>("time");
        GroupId = json.Value<long>("group_id");
        TargetId = json.Value<int>("target_id");
        SenderId = json.Value<int>("sender_id");
    }
}
