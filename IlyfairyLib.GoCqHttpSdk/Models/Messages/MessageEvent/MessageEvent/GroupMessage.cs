using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 群聊消息
/// </summary>
public sealed class GroupMessage : MessageBase<GroupSender>
{
    public override MessageType MessageSubType => MessageType.GroupMessage;
    public long GroupId { get; init; }
    public Anonymous Anonymous { get; init; }

    internal GroupMessage(Session session, JToken json) : base(session,json)
    {
        Sender = GroupSender.Get(json["sender"]);
        GroupId = json.Value<long>("group_id");
    }
}
