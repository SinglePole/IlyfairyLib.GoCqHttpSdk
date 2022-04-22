using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 私聊消息
/// </summary>
public sealed class PrivateMessage : MessageBase<Sender>
{
    public override MessageType MessageType => MessageType.PrivateMessage;
    internal PrivateMessage(JToken json) : base(json)
    {
        Sender = Sender.Get(json["sender"]);
    }
}
