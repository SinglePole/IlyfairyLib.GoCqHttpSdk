using IlyfairyLib.GoCqHttpSdk.Api;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 通知消息 - 好友消息撤回
/// </summary>
public class FriendRecall : MessageEventBase, IFriendRecall
{
    public override MessageType MessageSubType => MessageType.NoticeFriendRecall;
    /// <summary>
    /// QQ
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 消息ID
    /// </summary>
    public int MessageId { get; init; }
    public FriendRecall(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        UserId = json.Value<long>("user_id");
        Time = json.Value<long>("time");
        MessageId = json.Value<int>("message_id");
    }
}
