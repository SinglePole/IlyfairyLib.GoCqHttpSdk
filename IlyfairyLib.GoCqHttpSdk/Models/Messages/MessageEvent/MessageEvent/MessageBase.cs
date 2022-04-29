using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Utils;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

public abstract class MessageBase<TSender> : MessageEventBase where TSender : Sender
{
    /// <summary>
    /// 发送者
    /// </summary>
    public TSender Sender { get; init; }
    /// <summary>
    /// 发送者QQ
    /// </summary>
    public long QQ { get; init; }
    /// <summary>
    /// 字体
    /// </summary>
    public int Font { get; init; }
    /// <summary>
    /// 原始消息
    /// </summary>
    public string RawMessage { get; init; }
    /// <summary>
    /// 去除了[]&amp;转义的消息
    /// </summary>
    public string Text { get; init; }
    /// <summary>
    /// 仅文本消息
    /// </summary>
    public string TextOnly { get; init; }
    /// <summary>
    /// 消息ID
    /// </summary>
    public int MessageId { get; init; }
    /// <summary>
    /// 消息块
    /// </summary>
    public MessageBuilder Message { get; init; }

    protected MessageBase(JToken json) : base(json)
    {
        Font = json.Value<int>("font");
        QQ = json.Value<long>("user_id");
        MessageId = json.Value<int>("message_id");
        RawMessage = json.Value<string>("raw_message");
        Text = RawMessage.ToText();
        Message = MessageBuilder.Parse(json["message"] as JArray);
        TextOnly = string.Join("", Message.Where(v => v.Type == MessageChunkType.text));
    }
}
