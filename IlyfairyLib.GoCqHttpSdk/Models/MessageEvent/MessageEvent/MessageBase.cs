using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Utils;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

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
    public ReadOnlyMessage Message { get; init; }

    protected MessageBase(Session session, JToken json) : base(session, json)
    {
        Font = json.Value<int>("font");
        QQ = json.Value<long>("user_id");

        Message = new(session, json);
    }
}
