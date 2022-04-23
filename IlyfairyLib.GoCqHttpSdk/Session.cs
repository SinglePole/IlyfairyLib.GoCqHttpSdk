
global using System;
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
        WsClient.DisconnectionHappened.Subscribe(disInfo =>
        {
            //Console.WriteLine("Disconnect");
        });
        //连接/重新连接
        WsClient.ReconnectionHappened.Subscribe(reInfo =>
        {
            //Console.WriteLine($"Reconnect {reInfo.Type}");
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

    internal List<(Func<MessageEventBase, Task<bool>> func, MessageType type, Func<bool> isCall)> MessageFuncs { get; } = new();
}
