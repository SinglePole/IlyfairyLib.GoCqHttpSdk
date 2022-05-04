using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 群聊消息
/// </summary>
public sealed class GroupMessage : MessageBase<GroupSender>, IGroupInfo
{
    public override MessageType MessageSubType => MessageType.GroupMessage;
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 匿名消息
    /// </summary>
    public Anonymous Anonymous { get; init; }

    private GroupInfo? groupInfo;
    /// <summary>
    /// 群信息
    /// </summary>
    public GroupInfo? GroupInfo
    {
        get
        {
            if (groupInfo == null) groupInfo = session.GetGroupInfoAsync(GroupId, true).GetAwaiter().GetResult();
            return groupInfo;
        }
    }

    GroupInfo IGroupInfo.GroupInfo { get => GroupInfo; init => groupInfo = value; }

    /// <summary>
    /// 刷新群信息
    /// </summary>
    /// <returns></returns>
    public GroupInfo? RefreshGroupInfo()
    {
        groupInfo = session.GetGroupInfoAsync(GroupId, false).GetAwaiter().GetResult();
        return groupInfo;
    }


    internal GroupMessage(Session session, JToken json) : base(session, json)
    {
        Sender = GroupSender.Get(json["sender"]);
        GroupId = json.Value<long>("group_id");
    }
}
