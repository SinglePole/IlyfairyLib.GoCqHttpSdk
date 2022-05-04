using IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;
using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent
{
    /// <summary>
    /// 加群请求事件
    /// </summary>
    public class GroupReuqestMessage : MessageEventBase, IGroupInfo
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
        /// 同意加群请求
        /// </summary>
        public void Agree()
        {
            session.AgreeGroupRequest(Flag, RequestType, true);
        }

        /// <summary>
        /// 拒绝加群请求
        /// </summary>
        /// <param name="reason">拒绝理由</param>
        public void Refuse(string reason = null)
        {
            session.AgreeGroupRequest(Flag, RequestType, false, reason);
        }

        GroupInfo IGroupInfo.GroupInfo { get => GroupInfo; init => groupInfo = value; }

        public GroupReuqestMessage(Session session, JToken json) : base(session, json)
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
}
