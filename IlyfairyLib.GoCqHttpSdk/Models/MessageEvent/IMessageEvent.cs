using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using Newtonsoft.Json.Linq;
using System;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

public interface IMessageEvent
{
    DateTime DateTime { get; }
    PostEventType MessageEventType { get; }
    long RobotQQ { get; }
}
