using IlyfairyLib.GoCqHttpSdk.Api;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 元消息 - 声明周期
/// </summary>
public class LifecycleMessage : MessageEventBase
{
    public override MessageType MessageSubType => MessageType.Lifecycle;
    internal LifecycleMessage(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
    }

}
