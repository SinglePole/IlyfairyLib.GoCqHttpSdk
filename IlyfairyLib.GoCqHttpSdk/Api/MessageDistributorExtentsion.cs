using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Api
{
    public static class MessageDistributorExtentsion
    {
        public static void UseGroupMessage(this Session session, Func<GroupMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupMessage)!)),
                MessageType.GroupMessage,
                () => true));
        }
        public static void UsePrivateMessage(this Session session, Func<PrivateMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as PrivateMessage)!)),
                MessageType.PrivateMessage,
                () => true));
        }
    }
}
