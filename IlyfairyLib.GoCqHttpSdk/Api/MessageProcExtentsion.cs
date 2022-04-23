using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Api;

internal static class MessageProcExtentsion
{
    internal static void Process(this Session client)
    {
        client.WsClient.MessageReceived.Subscribe(async message =>
        {
            MessageEventBase? msg = null;

            try
            {
                JObject json = JObject.Parse(message.Text);

                msg = json.Value<string>("post_type") switch
                {
                    "meta_event" => json.Value<string>("meta_event_type") switch
                    {
                        "lifecycle" => new LifecycleMessage(json),
                        "heartbeat" => new HeartbeatMessage(json),
                        _ => null,
                    },
                    "message" => json.Value<string>("message_type") switch
                    {
                        "private" => new PrivateMessage(json),
                        "group" => new GroupMessage(json),
                        _ => null,
                    },
                    "notice" => json.Value<string>("notice_type") switch
                    {
                        "group_upload" => null,
                        "group_admin" => null,
                        "group_decrease" => null,
                        "group_increase" => null,
                        "group_ban" => json.Value<string>("sub_type") switch
                        {
                            "ban" => null,
                            "lift_ban" => null,
                            _ => null,
                        },
                        "friend_add" => null,
                        "group_recall" => null,
                        "friend_recall" => null,
                        "notify" => json.Value<string>("sub_type") switch
                        {
                            "poke" => null,
                            "lucky_king" => null,
                            "honor" => null,
                            _ => null,
                        },
                        _ => null,
                    },
                    "request" => json.Value<string>("request_type") switch
                    {
                        "friend" => null,
                        "group" => json.Value<string>("request_type") switch
                        {
                            "add" => null,
                            "invite" => null,
                            _ => null,
                        },
                        _ => null,
                    },
                    _ => null
                };

                if (msg == null)
                {
                    return;
                }
                else
                {

                }


            }
            catch { }

            if (msg != null)
            {
                await client.Distribution(msg);
            }
        });
    }


    internal static async Task Distribution(this Session session, MessageEventBase message)
    {
        await Task.Run(async () =>
        {
            foreach (var msgFunc in session.MessageFuncs.Where(v => v.type == message.MessageType))
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
                        foreach (var exFunc in session.ExceptionFuncs.Where(v => v.type == MessageType.Exception))
                        {
                            await exFunc.func(message, e);
                        }
                    }
                    catch { }
                }
            }
        });
    }

}
