using IlyfairyLib.GoCqHttpSdk.Api;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 元消息 - 心跳包
/// </summary>
public class HeartbeatMessage : MessageEventBase
{
    public override MessageType MessageType => MessageType.Heartbeat;
    internal HeartbeatMessage(JToken json) : base(json)
    {

    }
}
