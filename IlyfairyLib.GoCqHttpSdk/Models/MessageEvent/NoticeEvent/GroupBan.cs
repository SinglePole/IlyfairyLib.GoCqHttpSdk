using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Models.Shared.NoticeEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent.NoticeEvent;

public class GroupBan : MessageEventBase, IGroupBan
{
    public override MessageType MessageSubType => MessageType.NoticeGroupBan;
    /// <summary>
    /// 禁言类型
    /// </summary>
    public GroupBanType BanType { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 操作者 QQ 号
    /// </summary>
    public long OperatorId { get; init; }
    /// <summary>
    /// 被禁言 QQ 号 (为全员禁言时为0)
    /// </summary>
    public long QQ { get; init; }
    /// <summary>
    /// 禁言时长, 单位秒 (为全员禁言时为-1)
    /// </summary>
    public long Duration { get; init; }
    public GroupBan(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        GroupId = json.Value<long>("group_id");
        OperatorId = json.Value<long>("operator_id");
        QQ = json.Value<long>("user_id");
        Duration = json.Value<long>("duration");
        BanType = json.Value<string>("sub_type") switch
        {
            "ban" => GroupBanType.Ban,
            "lift_ban" => GroupBanType.LiftBan,
            _ => GroupBanType.Ban
        };
    }
}
