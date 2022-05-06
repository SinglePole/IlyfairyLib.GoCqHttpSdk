using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Utils;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 群消息和私聊消息的基类
/// </summary>
/// <typeparam name="TSender"></typeparam>
public abstract class MessageBase<TSender> : MessageEventBase where TSender : Sender
{
    /// <summary>
    /// 发送者
    /// </summary>
    public TSender? Sender { get; init; }
    /// <summary>
    /// 发送者QQ
    /// </summary>
    public long QQ { get; init; }
    /// <summary>
    /// 字体
    /// </summary>
    public int Font { get; init; }
    /// <summary>
    /// 聊天消息内容
    /// </summary>
    public ReadOnlyMessage Message { get; init; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="session"></param>
    /// <param name="json"></param>
    protected MessageBase(Session session, JToken json) : base(session, json)
    {
        Font = json.Value<int>("font");
        QQ = json.Value<long>("user_id");

        Message = new(session, json);
    }
}
