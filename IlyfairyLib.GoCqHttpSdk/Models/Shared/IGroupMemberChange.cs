using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;

public interface IGroupMemberChange
{
    public long time { get; init; }
    /// <summary>
    /// 收到事件的机器人 QQ 号
    /// </summary>
    public long self_id { get; init; }
    /// <summary>
    /// 上报类型(可能值:notice)
    /// </summary>
    public string post_type { get; init; }
    /// <summary>
    /// 通知类型(可能值:group_increase)
    /// </summary>
    public string notice_type { get; init; }
    /// <summary>
    /// 事件子类型, 分别表示管理员已同意入群、管理员邀请入群(可能值:approve、invite )
    /// </summary>
    public string sub_type { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 操作者 QQ 号
    /// </summary>
    public long operator_id { get; init; }
    /// <summary>
    /// 加入者 QQ 号
    /// </summary>
    public long QQ { get; init; }
}
