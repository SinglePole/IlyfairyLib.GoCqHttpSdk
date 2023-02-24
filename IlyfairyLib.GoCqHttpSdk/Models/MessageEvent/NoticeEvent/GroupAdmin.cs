using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Models.Shared.NoticeEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent.NoticeEvent;

public class GroupAdmin : MessageEventBase, IGroupAdmin
{
    public override MessageType MessageSubType => MessageType.NoticeGroupAdmin;
    /// <summary>
    /// 管理员QQ号
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 事件子类型, 分别表示设置和取消管理员(可能的值：set、unset)
    /// </summary>
    public string SubType { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    public GroupAdmin(Session session, JToken json) : base(session, json)
    {
        session.RobotQQ = json.Value<long>("self_id");
        UserId = json.Value<long>("user_id");
        Time = json.Value<long>("time");
        GroupId = json.Value<long>("group_id");
        SubType = json.Value<string>("sub_type");
    }
}
