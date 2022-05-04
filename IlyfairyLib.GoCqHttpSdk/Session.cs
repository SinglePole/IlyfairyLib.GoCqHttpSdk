global using System;
global using System.Linq;
global using Newtonsoft.Json.Linq;
global using IlyfairyLib.GoCqHttpSdk.Api;
global using IlyfairyLib.GoCqHttpSdk.Models.Messages;

using System.Collections.Generic;
using System.Threading.Tasks;
using Websocket.Client;
using IlyfairyLib.GoCqHttpSdk.Models.MessageEvent;

namespace IlyfairyLib.GoCqHttpSdk;
/// <summary>
/// 一个GoCqHttp会话
/// </summary>
public class Session
{
    public Uri WsUrl { get; set; }
    public Uri HttpUrl { get; set; }
    internal WebsocketClient WsClient { get; private init; }
    private bool isStart;

    public long RobotQQ { get; internal set; }

    /// <summary>
    /// 初始化一个GoCqHttp会话
    /// </summary>
    /// <param name="ws">WebSocket地址<br/>ws://</param>
    /// <param name="http">Http地址<br/>http://</param>
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
        async Task T(bool isConnected)
        {
            foreach (var item in ConnectionFuncs)
            {
                try
                {
                    await item(isConnected);
                }
                catch (Exception e)
                {
                    try
                    {
                        foreach (var exFunc in this.ExceptionFuncs)
                        {
                            await exFunc(null, e);
                        }
                    }
                    catch { }
                }
            }
        }
        //连接/重新连接
        WsClient.ReconnectionHappened.Subscribe(async reInfo =>
        {
            await T(true);
        });
        //断开
        WsClient.DisconnectionHappened.Subscribe(async disInfo =>
        {
            await T(false);
        });
    }
    /// <summary>
    /// 构建连接
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
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
    /// <summary>
    /// 重新连接
    /// </summary>
    public async void ReConnect()
    {
        await WsClient.Reconnect();
    }

    internal List<(Func<MessageEventBase, Task<bool>> func, MessageType type)> MessageFuncs { get; } = new();
    internal List<Func<MessageEventBase, Exception, Task<bool>>> ExceptionFuncs { get; } = new();
    internal List<Func<bool, Task<bool>>> ConnectionFuncs { get; } = new();
}
