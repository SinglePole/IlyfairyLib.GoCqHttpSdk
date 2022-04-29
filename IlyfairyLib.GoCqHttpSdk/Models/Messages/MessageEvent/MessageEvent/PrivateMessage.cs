using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 私聊消息
/// </summary>
public sealed class PrivateMessage : MessageBase<Sender>
{
    public override MessageType MessageSubType => MessageType.PrivateMessage;
    internal PrivateMessage(Session session, JToken json) : base(session,json)
    {
        Sender = Sender.Get(json["sender"]);
    }
}
