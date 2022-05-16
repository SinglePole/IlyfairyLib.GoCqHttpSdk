using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages
{
    public record HistoryMessage
    {
        /// <summary>
        /// 消息真实id
        /// </summary>
        public int RealId { get; }
        /// <summary>
        /// 发送者
        /// </summary>
        public Sender? sender { get; }
        /// <summary>
        /// 消息序列
        /// </summary>
        public int MessageSeq { get; }
        public ReadOnlyMessage Message { get; }
        public DateTime DateTime { get; }

        public HistoryMessage(Session session, JObject json)
        {
            Message = ReadOnlyMessage.Parse(session, json);
            sender = Sender.Get(json["sender"]);
            MessageSeq = json.Value<int>("message_seq");
            RealId = json.Value<int>("real_id");
            DateTime = DateTimeOffset.FromUnixTimeSeconds(json.Value<long>("time")).DateTime;
        }

        internal static HistoryMessage? Parse(Session session, JToken json)
        {
            if (json is JObject obj)
            {
                return new(session, obj);
            }
            else
            {
                return null;
            }
        }
    }
}
