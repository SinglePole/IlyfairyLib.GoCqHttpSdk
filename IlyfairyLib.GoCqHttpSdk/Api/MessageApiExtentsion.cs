using Flurl.Http;
using IlyfairyLib.GoCqHttpSdk.Models.Api;
using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static IlyfairyLib.GoCqHttpSdk.Models.MessageApiExtentsion;

namespace IlyfairyLib.GoCqHttpSdk.Api;

public static partial class MessageApiExtentsion
{
    private static MediaTypeHeaderValue JsonContentType { get; } = new MediaTypeHeaderValue("application/json");
    private static async Task<string> SendApiAsync(this Session server, string text)
    {
        var content = new StringContent(text);
        content.Headers.ContentType = JsonContentType;
        return await server.HttpUrl.SendAsync(HttpMethod.Post, content).ReceiveString();
    }
    private static async Task<string> SendApiAsync(Session server, ApiActionType action, JObject @params)
    {
        JObject json = new();
        json["action"] = action.ToString();
        json["params"] = @params;
        return await SendApiAsync(server, json.ToString());
    }

    internal static async Task<MessageApiResult> SendApiMessageAsync(Session server, ApiActionType action, JObject @params)
    {
        var result = await SendApiAsync(server, action, @params);

#if DEBUG
        Console.WriteLine($"api result: \n{result}");
#endif

        try
        {
            var json = JObject.Parse(result);
            var data = json["data"] as JObject;
            var ret = json.Value<int>("ret");
            var wording = json.Value<string>("wording") ?? "";
            return new MessageApiResult(data, ret, wording);
        }
        catch (Exception)
        {
            return new MessageApiResult(null, -1, string.Empty);
        }
    }

    /// <summary>
    /// 发送群消息
    /// </summary>
    /// <param name="server"></param>
    /// <param name="groupId">群ID</param>
    /// <param name="message">消息</param>
    /// <returns>成功返回消息id,否则为null</returns>
    public static async Task<int?> SendGroupMessageAsync(this Session server, long groupId, params MessageChunk[] message)
    {
        return await SendGroupMessageAsync(server, groupId, new MessageBuilder(message));
    }
    /// <summary>
    /// 发送群消息
    /// </summary>
    /// <param name="server"></param>
    /// <param name="groupId">群ID</param>
    /// <param name="message">消息</param>
    /// <returns>成功返回消息id,否则为null</returns>
    public static async Task<int?> SendGroupMessageAsync(this Session server, long groupId, MessageBuilder message)
    {
        var json = JsonEx.Create()
            .Set("group_id", groupId)
            .Set("message", message.ToJArray());

        var result = await SendApiMessageAsync(server, ApiActionType.SendGroupMessage, json);
        if (result.Success)
        {
            return result.Data?.Value<int>("message_id");
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// 发送私聊消息
    /// </summary>
    /// <param name="server"></param>
    /// <param name="qq">QQ</param>
    /// <param name="message">消息</param>
    /// <returns>成功返回消息id,否则为null</returns>
    public static async Task<int?> SendPrivateMessageAsync(this Session server, long qq, MessageBuilder message)
    {
        var json = JsonEx.Create()
            .Set("user_id", qq)
            .Set("message", message.ToJArray());

        var result = await SendApiMessageAsync(server, ApiActionType.SendPrivateMessage, json);
        if (result.Success)
        {
            return result.Data?.Value<int>("message_id");
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// 发送消息 <br/>会根据参数自动判断发送到私聊还是群组
    /// </summary>
    /// <param name="server"></param>
    /// <param name="group">群ID</param>
    /// <param name="qq">QQ</param>
    /// <param name="message">消息</param>
    /// <returns>成功返回消息id,否则为null</returns>
    public static async Task<int?> SendMessageAsync(this Session server, long group, long qq, MessageBuilder message)
    {

        var json = JsonEx.Create()
            .Set("group_id", group)
            .Set("user_id", qq)
            .Set("message", message.ToJArray());

        var result = await SendApiMessageAsync(server, ApiActionType.DeleteMessage, json);
        if (result.Success)
        {
            return result.Data?.Value<int>("message_id");
        }
        else
        {
            return null;
        }
    }



    /// <summary>
    /// 撤回消息
    /// </summary>
    /// <param name="server"></param>
    /// <param name="messageId">消息ID</param>
    /// <returns></returns>
    public static async Task DeleteMessageAsync(this Session server, int messageId)
    {
        JObject json = new();
        json["message_id"] = messageId;

        await SendApiMessageAsync(server, ApiActionType.SendMessage, json);
    }

    /// <summary>
    /// 获取消息
    /// </summary>
    /// <param name="client"></param>
    /// <param name="messageId">消息ID</param>
    /// <returns></returns>
    internal static async Task GetMessage(this Session client, int messageId)
    {
        JObject json = new();
        json["message_id"] = messageId;
        var result = await SendApiMessageAsync(client, ApiActionType.GetMessage, json);
        if (result.Success)
        {
            //return result.Data;
        }
    }

    /// <summary>
    /// 发送赞
    /// </summary>
    /// <param name="client"></param>
    /// <param name="qq"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static async Task SendLike(this Session client, long qq,int count)
    {
        var json = new JObject();
        json["user_id"] = qq;
        json["times"] = count;
        await SendApiMessageAsync(client, ApiActionType.GetMessage, json);
    }
}
