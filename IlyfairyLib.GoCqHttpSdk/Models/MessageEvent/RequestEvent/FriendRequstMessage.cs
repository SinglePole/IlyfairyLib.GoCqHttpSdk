using IlyfairyLib.GoCqHttpSdk.Api;
using IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

/// <summary>
/// 加好友请求 事件
/// </summary>
public class FriendRequstMessage : MessageEventBase, IFriendInfo
{
    public override MessageType MessageSubType => MessageType.RequestFriend;
    /// <summary>
    /// 发送请求的QQ号
    /// </summary>
    public long QQ { get; init; }
    /// <summary>
    /// 验证信息
    /// </summary>
    public string Comment { get; init; }
    /// <summary>
    /// 请求 flag, 在调用处理请求的 API 时需要传入
    /// </summary>
    public string Flag { get; init; }
    /// <summary>
    /// 陌生人信息
    /// </summary>
    private StrangerInfo? strangerInfo;
    /// <summary>
    /// 陌生人信息
    /// </summary>
    public StrangerInfo? StrangerInfo
    {
        get
        {
            if (strangerInfo == null) strangerInfo = session.GetStrangerInfoAsync(QQ, true).GetAwaiter().GetResult();
            return strangerInfo;
        }
    }
    /// <summary>
    /// 同意 加好友请求
    /// </summary>
    /// <returns>返回操作是否成功</returns>
    public async Task<bool> Agree()
    {
        return await session.AgreeFriendRequestAsync(Flag, true);
    }

    /// <summary>
    /// 拒绝 加好友请求
    /// </summary>
    /// <param name="reason">拒绝理由</param>
    /// <returns>返回操作是否成功</returns>
    public async Task<bool> Refuse(string reason = null)
    {
        return await session.AgreeFriendRequestAsync(Flag, false, reason);
    }

    StrangerInfo IFriendInfo.StrangerInfo { get => StrangerInfo; init => strangerInfo = value; }

    public FriendRequstMessage(Session session, JToken json) : base(session, json)
    {
        Flag = json.Value<string>("flag");
        Comment = json.Value<string>("comment");
        QQ = json.Value<long>("user_id");
    }
}
