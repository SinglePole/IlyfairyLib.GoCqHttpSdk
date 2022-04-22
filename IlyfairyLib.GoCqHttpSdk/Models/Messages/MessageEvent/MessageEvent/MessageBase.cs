using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

public abstract class MessageBase<TSender> : MessageEventBase where TSender : Sender
{
    public TSender Sender { get; init; }
    public long QQ { get; init; }
    public int Font { get; init; }
    public string RawMessage { get; init; }
    public int MessageId { get; init; }
    public MessageBuilder Message { get; init; }

    protected MessageBase(JToken json) : base(json)
    {
        Font = json.Value<int>("font");
        RawMessage = json.Value<string>("raw_message");
        QQ = json.Value<long>("user_id");
        MessageId = json.Value<int>("message_id");
        Message = MessageBuilder.Parse(json["message"] as JArray);
    }
}
