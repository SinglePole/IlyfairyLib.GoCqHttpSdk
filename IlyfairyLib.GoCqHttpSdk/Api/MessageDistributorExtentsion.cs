using System.Text.RegularExpressions;
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

        public static void MapGroup(this Session session, string regex, Func<GroupMessage, GroupCollection, Task> func)
        {
            session.MessageFuncs.Add((
              new(async v =>
              {
                  var msg = (v as GroupMessage);
                  Match match = Regex.Match(msg.RawMessage, regex);
                  if (match.Success)
                  {
                      await func(msg, match.Groups);
                  }
                  return true;
              }),
              MessageType.GroupMessage,
              () => true));
        }
    }
}
