using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Api
{
    /// <summary>
    /// 消息分发扩展类
    /// </summary>
    public static class MessageDistributorExtentsion
    {
        /// <summary>
        /// 创建群消息中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调<br/>返回值代表是否继续向下传递</param>
        public static void UseGroupMessage(this Session session, Func<GroupMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupMessage)!)),
                MessageType.GroupMessage));
        }

        /// <summary>
        /// 创建私聊消息中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        public static void UsePrivateMessage(this Session session, Func<PrivateMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as PrivateMessage)!)),
                MessageType.PrivateMessage));
        }

        /// <summary>
        /// 将正则表达式映射到群消息
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="func">回调<br/>返回值代表是否继续向下传递</param>
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
                      return false;
                  }
                  return true;
              }),
              MessageType.GroupMessage));
        }

                /// <summary>
        /// 将正则表达式映射到群消息
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="func">回调<br/>返回值代表是否继续向下传递</param>
        public static void MapPrivate(this Session session, string regex, Func<PrivateMessage, GroupCollection, Task> func)
        {
            session.MessageFuncs.Add((
              new(async v =>
              {
                  var msg = (v as PrivateMessage);
                  Match match = Regex.Match(msg.RawMessage, regex);
                  if (match.Success)
                  {
                      await func(msg, match.Groups);
                      return false;
                  }
                  return true;
              }),
              MessageType.PrivateMessage));
        }

        /// <summary>
        /// 创建异常消息中间件
        /// </summary>
        /// <param name="session"></param>
        /// <param name="func"></param>
        public static void UseException(this Session session, Func<MessageEventBase, Exception, Task<bool>> func)
        {
            session.ExceptionFuncs.Add((
              func,
              MessageType.Exception));
        }
    }
}
