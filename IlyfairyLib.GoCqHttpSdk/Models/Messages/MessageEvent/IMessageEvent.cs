using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using Newtonsoft.Json.Linq;
using System;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

public interface IMessageEvent
{
    DateTime DateTime { get; }
    PostEventType MessageEventType { get; }
    long RobotQQ { get; }
}
