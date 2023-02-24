using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Models.Shared.NoticeEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent.NoticeEvent;
/// <summary>
/// 通知消息 - 群成员荣誉变更提示
/// </summary>
public class Honor : MessageEventBase, IHonor
{
    public override MessageType MessageSubType => MessageType.NoticeHonor;
    /// <summary>
    /// 时间
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 成员id
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 荣誉类型 （talkative:龙王 performer:群聊之火 emotion:快乐源泉）
    /// </summary>
    public string HonorType { get; init; }
    public Honor(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        UserId = json.Value<long>("user_id");
        Time = json.Value<long>("time");
        GroupId = json.Value<long>("group_id");
        HonorType = json.Value<string>("honor_type") ?? "";
    }
}
