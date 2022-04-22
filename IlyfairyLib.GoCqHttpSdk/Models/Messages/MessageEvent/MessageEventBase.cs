using IlyfairyLib.GoCqHttpSdk.Api;
using Newtonsoft.Json.Linq;
using System;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 所有消息事件的基类
/// </summary>
public abstract class MessageEventBase : IMessageEvent
{
    public PostEventType MessageEventType { get; internal set; }
    public abstract MessageType MessageType { get; }
    public long RobotQQ { get; internal set; }
    public DateTime DateTime { get; internal set; }

    protected MessageEventBase(JToken json)
    {
        string? eventType = json.Value<string>("post_type");
        long time = json.Value<long>("time");
        long robotQQ = json.Value<long>("self_id");

        RobotQQ = robotQQ;
        DateTime = DateTimeOffset.FromUnixTimeSeconds(time).DateTime;
        MessageEventType = eventType switch
        {
            "meta_event" => PostEventType.MetaEvent,
            "message" => PostEventType.Message,
            "notice" => PostEventType.Notice,
            "request" => PostEventType.Request,
            _ => throw new Exception("Post消息类型不受支持")
        };
    }
}
