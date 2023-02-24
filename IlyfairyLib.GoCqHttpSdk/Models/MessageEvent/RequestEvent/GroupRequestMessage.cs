using IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 加群请求/被邀请加群 事件
/// </summary>
public class GroupRequestMessage : MessageEventBase, IGroupInfo
{
    public override MessageType MessageSubType => MessageType.RequestGroup;
    /// <summary>
    /// 请求类型
    /// </summary>
    public GroupRequestType RequestType { get; init; }
    
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 请求 flag
    /// </summary>
    public string Flag { get; init; }
    /// <summary>
    /// 验证信息
    /// </summary>
    public string Comment { get; set; }

    /// <summary>
    /// 目标QQ
    /// </summary>
    public long QQ { get; set; }

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

    /// <summary>
    /// 同意 加群请求/被邀请入群
    /// </summary>
    /// <returns>返回操作是否成功</returns>
    public async Task<bool> Agree()
    {
        return await session.AgreeGroupRequestAsync(Flag, RequestType, true);
    }

    /// <summary>
    /// 拒绝 加群请求/被邀请入群
    /// </summary>
    /// <param name="reason">拒绝理由</param>
    /// <returns>返回操作是否成功</returns>
    public async Task<bool> Refuse(string reason = null)
    {
        return await session.AgreeGroupRequestAsync(Flag, RequestType, false, reason);
    }

    GroupInfo IGroupInfo.GroupInfo { get => GroupInfo; init => groupInfo = value; }

    public GroupRequestMessage(Session session, JToken json) : base(session, json)
    {
        GroupId = json.Value<long>("group_id");
        Flag = json.Value<string>("flag");
        Comment = json.Value<string>("comment");
        QQ = json.Value<long>("user_id");

        RequestType = json.Value<string>("sub_type") switch
        {
            "add" => GroupRequestType.Add,
            "invite" => GroupRequestType.Invite,
            _ => GroupRequestType.Add,
        };
    }
}
