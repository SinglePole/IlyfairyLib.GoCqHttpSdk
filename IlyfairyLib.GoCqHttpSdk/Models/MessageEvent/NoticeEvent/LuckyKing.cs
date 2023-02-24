using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent.NoticeEvent;
/// <summary>
/// 通知消息 - 群红包运气王
/// </summary>
public class LuckyKing : MessageEventBase, ILuckyKing
{
    public override MessageType MessageSubType => MessageType.NoticeLuckyKing;
    /// <summary>
    /// 红包发送者QQ
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 提示类型
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 运气王QQ
    /// </summary>
    public long TargetId { get; init; }
    public LuckyKing(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        UserId = json.Value<long>("user_id");
        Time = json.Value<long>("time");
        GroupId = json.Value<long>("group_id");
        TargetId = json.Value<long>("target_id");
    }
}
