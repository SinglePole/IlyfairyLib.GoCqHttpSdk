using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 私聊消息
/// </summary>
public sealed class PrivateMessage : MessageBase<Sender>
{
    /// <summary>
    /// 私聊消息类型<br/>始终是MessageType.PrivateMessage
    /// </summary>
    public override MessageType MessageSubType => MessageType.PrivateMessage;
    internal PrivateMessage(Session session, JToken json) : base(session,json)
    {
        Sender = Sender.Get(json["sender"]);
    }
}
