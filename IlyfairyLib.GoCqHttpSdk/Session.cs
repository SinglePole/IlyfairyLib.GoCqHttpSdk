
global using System;
global using System.Linq;
global using Newtonsoft.Json.Linq;
global using IlyfairyLib.GoCqHttpSdk.Models;
global using IlyfairyLib.GoCqHttpSdk.Api;
global using IlyfairyLib.GoCqHttpSdk.Models.Messages;

using System.Collections.Generic;
using System.Threading.Tasks;
using Websocket.Client;


namespace IlyfairyLib.GoCqHttpSdk;
public class Session
{
    public Uri WsUrl { get; set; }
    public Uri HttpUrl { get; set; }
    internal WebsocketClient WsClient { get; private init; }
    private bool isStart;

    public Session(string ws, string http)
    {
        WsUrl = new(ws);
        HttpUrl = new(http);
        WsClient = new(WsUrl);
        WsClient.ErrorReconnectTimeout = TimeSpan.FromSeconds(10);
        WebSocketSubscribeInit();
    }

    private void WebSocketSubscribeInit()
    {
        //断开
        WsClient.DisconnectionHappened.Subscribe(async disInfo =>
        {
            foreach (var item in ConnectionFuncs)
            {
                try
                {
                    await item.func(false);
                }
                catch (Exception e)
                {
                    try
                    {
                        foreach (var exFunc in this.ExceptionFuncs.Where(v => v.type == MessageType.Exception))
                        {
                            await exFunc.func(null, e);
                        }
                    }
                    catch { }
                }
            }
        });
        //连接/重新连接
        WsClient.ReconnectionHappened.Subscribe(async reInfo =>
        {
            foreach (var item in ConnectionFuncs)
            {
                try
                {
                    await item.func(true);
                }
                catch (Exception e)
                {
                    try
                    {
                        foreach (var exFunc in this.ExceptionFuncs.Where(v => v.type == MessageType.Exception))
                        {
                            await exFunc.func(null, e);
                        }
                    }
                    catch { }
                }
            }
        });
    }
    public async void Build()
    {
        lock (WsClient)
        {
            if (!isStart) isStart = true;
            else throw new InvalidOperationException();
        }
        this.Process();
        await WsClient.Start();
    }
    public async void ReConnect()
    {
        await WsClient.Reconnect();
    }

    internal List<(Func<MessageEventBase, Task<bool>> func, MessageType type)> MessageFuncs { get; } = new();
    internal List<(Func<MessageEventBase, Exception, Task<bool>> func, MessageType type)> ExceptionFuncs { get; } = new();
    internal List<(Func<bool, Task<bool>> func, MessageType type)> ConnectionFuncs { get; } = new();
}
