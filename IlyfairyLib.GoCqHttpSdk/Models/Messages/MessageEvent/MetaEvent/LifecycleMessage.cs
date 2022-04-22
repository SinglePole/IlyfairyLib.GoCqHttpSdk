using IlyfairyLib.GoCqHttpSdk.Api;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 元消息 - 声明周期
/// </summary>
public class LifecycleMessage : MessageEventBase
{
    public override MessageType MessageType => MessageType.Lifecycle;
    internal LifecycleMessage(JToken json) : base(json)
    {

    }

}
