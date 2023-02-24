using IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;
using IlyfairyLib.GoCqHttpSdk.Models.MessageEvent.NoticeEvent;
using IlyfairyLib.GoCqHttpSdk.Utils;
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
        /// 创建 加好友请求 中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        public static Session UseFriendRequestMessage(this Session session, Func<FriendReuqestMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as FriendReuqestMessage)!)),
                MessageType.RequestFriend));
            return session;
        }
        /// <summary>
        /// 创建群成员减少中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseGroupDecrease(this Session session, Func<GroupDecrease, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupDecrease)!)),
                MessageType.NoticeGroupDecrease));
            return session;
        }
        /// <summary>
        /// 创建群成员增加中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseGroupIncrease(this Session session, Func<GroupIncrease, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupIncrease)!)),
                MessageType.NoticeGroupIncrease));
            return session;
        }
        /// <summary>
        /// 创建好友添加中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseFriendAdd(this Session session, Func<FriendAdd, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as FriendAdd)!)),
                MessageType.NoticeFriendAdd));
            return session;
        }
        /// <summary>
        /// 创建群成员荣誉变更中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseHonor(this Session session, Func<Honor, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as Honor)!)),
                MessageType.NoticeHonor));
            return session;
        }
        /// <summary>
        /// 创建群红包运气王中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseLuckyKing(this Session session, Func<LuckyKing, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as LuckyKing)!)),
                MessageType.NoticeLuckyKing));
            return session;
        }
        /// <summary>
        /// 创建戳一戳中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UsePoke(this Session session, Func<Poke, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as Poke)!)),
                MessageType.NoticePoke));
            return session;
        }
        /// <summary>
        /// 创建群管理员变动中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseGroupAdmin(this Session session, Func<GroupAdmin, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupAdmin)!)),
                MessageType.NoticeGroupAdmin));
            return session;
        }
        /// <summary>
        /// 创建群禁言中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseGroupBan(this Session session, Func<GroupBan, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupBan)!)),
                MessageType.NoticeGroupBan));
            return session;
        }
        /// <summary>
        /// 创建群文件上传中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseGroupUpload(this Session session, Func<GroupUpload, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupUpload)!)),
                MessageType.NoticeGroupUpload));
            return session;
        }
        /// <summary>
        /// 创建好友消息撤回中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseFriendRecall(this Session session, Func<FriendRecall, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as FriendRecall)!)),
                MessageType.NoticeFriendRecall));
            return session;
        }
        /// <summary>
        /// 创建群消息撤回中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        public static Session UseGroupRecall(this Session session, Func<GroupRecall, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupRecall)!)),
                MessageType.NoticeGroupRecall));
            return session;
        }
        /// <summary>
        /// 创建群消息中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调<br/>返回值代表是否继续向下传递</param>
        public static Session UseGroupMessage(this Session session, Func<GroupMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupMessage)!)),
                MessageType.GroupMessage));
            return session;
        }

        /// <summary>
        /// 创建私聊消息中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        public static Session UsePrivateMessage(this Session session, Func<PrivateMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as PrivateMessage)!)),
                MessageType.PrivateMessage));
            return session;
        }

        /// <summary>
        /// 创建 加群请求/被邀请入群 中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        public static Session UseGroupRequestMessage(this Session session, Func<GroupReuqestMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as GroupReuqestMessage)!)),
                MessageType.RequestGroup));
            return session;
        }
        /// <summary>
        /// 创建 群成员增加 中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调</param>
        //public static Session UserGroupMemberIncrease(this Session session, Func<GroupMemberIncrease, Task<bool>> func)
        //{

        //}
        /// <summary>
        /// 将正则表达式映射到群消息
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="func">回调<br/>返回值代表是否继续向下传递</param>
        public static Session MapGroupMessage(this Session session, [StringSyntax("Regex")] string regex, Func<GroupMessage, GroupCollection, Task> func)
        {
            session.MessageFuncs.Add((
              new(async v =>
              {
                  var msg = (v as GroupMessage);
                  Match match = Regex.Match(msg.Message.RawMessage.ToText(), regex);
                  if (match.Success)
                  {
                      await func(msg, match.Groups);
                      return false;
                  }
                  return true;
              }),
              MessageType.GroupMessage));
            return session;
        }

        /// <summary>
        /// 将正则表达式映射到群消息
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="func">回调<br/>返回值代表是否继续向下传递</param>
        public static Session MapPrivateMessage(this Session session, [StringSyntax("Regex")] string regex, Func<PrivateMessage, GroupCollection, Task> func)
        {
            session.MessageFuncs.Add((
              new(async v =>
              {
                  var msg = (v as PrivateMessage);
                  Match match = Regex.Match(msg.Message.RawMessage.ToText(), regex);
                  if (match.Success)
                  {
                      await func(msg, match.Groups);
                      return false;
                  }
                  return true;
              }),
              MessageType.PrivateMessage));
            return session;
        }

        /// <summary>
        /// 创建异常消息中间件
        /// </summary>
        /// <param name="session"></param>
        /// <param name="func"></param>
        public static Session UseException(this Session session, Func<MessageEventBase, Exception, Task<bool>> func)
        {
            session.ExceptionFuncs.Add(
              func);
            return session;
        }

        /// <summary>
        /// 创建WebSocket连接中间件
        /// </summary>
        /// <param name="session"></param>
        /// <param name="func">回调<br/>参数True代表WebSocket连接成功否则断开</param>
        public static Session UseWebSocketConnect(this Session session, Func<bool, Task<bool>> func)
        {
            session.ConnectionFuncs.Add(func);
            return session;
        }

        /// <summary>
        /// 创建生命周期息中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调<br/>返回值代表是否继续向下传递</param>
        public static Session UseLifecycle(this Session session, Func<LifecycleMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as LifecycleMessage)!)),
                MessageType.Lifecycle));
            return session;
        }

        /// <summary>
        /// 创建心跳包中间件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="func">回调<br/>返回值代表是否继续向下传递</param>
        public static Session UseHeartbeat(this Session session, Func<HeartbeatMessage, Task<bool>> func)
        {
            session.MessageFuncs.Add((
                new(v => func((v as HeartbeatMessage)!)),
                MessageType.Heartbeat));
            return session;
        }
    }
}
