using IlyfairyLib.GoCqHttpSdk.Api;
using Newtonsoft.Json.Linq;
using System;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 所有消息事件的基类
/// </summary>
public abstract class MessageEventBase : IMessageEvent
{
    internal Session session;
    /// <summary>
    /// 事件类型
    /// </summary>
    public PostEventType MessageEventType { get; internal set; }
    /// <summary>
    /// 事件类型
    /// </summary>
    public abstract MessageType MessageSubType { get; }
    /// <summary>
    /// 机器人QQ
    /// </summary>
    public long RobotQQ { get; internal set; }
    /// <summary>
    /// 消息时间
    /// </summary>
    public DateTime DateTime { get; internal set; }

    protected MessageEventBase(Session session, JToken json)
    {
        this.session = session;
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
