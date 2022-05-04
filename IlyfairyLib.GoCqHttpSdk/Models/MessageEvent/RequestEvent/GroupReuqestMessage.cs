using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.MessageEvent
{
    public class GroupReuqestMessage : MessageEventBase
    {
        public override MessageType MessageSubType => MessageType.RequestGroup;
        public GroupReuqestMessage(Session session, JToken json) : base(session, json)
        {

        }

    }
}
