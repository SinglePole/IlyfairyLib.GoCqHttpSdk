using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent.RequestEvent
{
    /// <summary>
    /// 好友请求事件
    /// </summary>
    public class FriendRequestMessage : MessageEventBase
    {
        public override MessageType MessageSubType => MessageType.RequestFriend;

        /// <summary>
        /// 发送请求的QQ号
        /// </summary>
        public long QQ { get; init; }
        /// <summary>
        /// 请求 flag, 在调用处理请求的 API 时需要传入
        /// </summary>
        public string Flag { get; init; }
        /// <summary>
        /// 验证信息
        /// </summary>
        public string Comment { get; set; }

        public async Task<bool> Agree()
        {
            return await session.AgreeFriendRequest(Flag, true);
        }
        public FriendRequestMessage(Session session, JToken json) : base(session, json)
        {
            QQ = json.Value<long>("user_id");
            Flag = json.Value<string>("flag");
            Comment = json.Value<string>("comment");
        }
    }
}
