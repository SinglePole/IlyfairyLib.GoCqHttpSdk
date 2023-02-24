using IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using IlyfairyLib.GoCqHttpSdk.Models.MessageEvent.NoticeEvent;

namespace IlyfairyLib.GoCqHttpSdk.Api;

internal static class MessageProcExtentsion
{
    internal static void Process(this Session session)
    {
        session.WsClient.MessageReceived.Subscribe(async message =>
        {
            MessageEventBase? msg = null;
            try
            {
                JObject json = JObject.Parse(message.Text);
                msg = json.Value<string>("post_type") switch
                {
                    "meta_event" => json.Value<string>("meta_event_type") switch
                    {
                        "lifecycle" => new LifecycleMessage(session, json),
                        "heartbeat" => new HeartbeatMessage(session, json),
                        _ => null,
                    },
                    "message" => json.Value<string>("message_type") switch
                    {
                        "private" => new PrivateMessage(session, json),
                        "group" => new GroupMessage(session, json),
                        _ => null,
                    },
                    "notice" => json.Value<string>("notice_type") switch
                    {
                        "group_upload" => new GroupUpload(session, json),
                        "group_admin" => new GroupAdmin(session, json),
                        "group_decrease" => new GroupDecrease(session, json),
                        "group_increase" => new GroupIncrease(session, json),
                        "group_ban" => json.Value<string>("sub_type") switch
                        {
                            "ban" => new GroupBan(session, json),
                            "lift_ban" => new GroupBan(session, json),
                            _ => null,
                        },
                        "friend_add" => new FriendAdd(session, json),
                        "group_recall" => new GroupRecall(session, json),
                        "friend_recall" => new FriendRecall(session, json),
                        "notify" => json.Value<string>("sub_type") switch
                        {
                            "poke" => new Poke(session, json),
                            "lucky_king" => new LuckyKing(session, json),
                            "honor" => new Honor(session, json),
                            _ => null,
                        },
                        _ => null,
                    },
                    "request" => json.Value<string>("request_type") switch
                    {
                        "friend" => new FriendReuqestMessage(session, json),
                        "group" => json.Value<string>("sub_type") switch
                        {
                            "add" => new GroupReuqestMessage(session, json),
                            "invite" => new GroupReuqestMessage(session, json),
                            _ => null,
                        },
                        _ => null,
                    },
                    _ => null
                };

            }
            catch { }

            if (msg != null)
            {
                await session.Distribution(msg);
            }
        });
    }

    internal static async Task Distribution(this Session session, MessageEventBase message)
    {
        foreach (var msgFunc in session.MessageFuncs.Where(v => v.type == message.MessageSubType))
        {
            try
            {
                var isContinue = msgFunc.func(message);
                if (!await isContinue) break;
            }
            catch (Exception e)
            {
                try
                {
                    foreach (var exFunc in session.ExceptionFuncs)
                    {
                        await exFunc(message, e);
                    }
                }
                catch { }
            }
        }
    }
}
