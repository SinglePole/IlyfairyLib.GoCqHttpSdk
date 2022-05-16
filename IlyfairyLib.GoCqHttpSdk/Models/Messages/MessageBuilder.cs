using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using IlyfairyLib.GoCqHttpSdk.Utils;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 消息构造器
/// </summary>
public class MessageBuilder : List<MessageChunk>
{
    public MessageBuilder()
    {

    }
    public MessageBuilder(IEnumerable<MessageChunk> messageChunks)
    {
        AddRange(messageChunks);
    }

    /// <summary>
    /// 将两个消息段连起来
    /// </summary>
    /// <param name="messageBuilder1"></param>
    /// <param name="messageBuilder2"></param>
    /// <returns></returns>
    public static MessageBuilder operator +(MessageBuilder messageBuilder1, MessageBuilder messageBuilder2)
    {
        foreach (var chunk in messageBuilder2)
        {
            messageBuilder1.Add(chunk);
        }
        return messageBuilder1;
    }

    /// <summary>
    /// 将消息块添加到MessageBuilder
    /// </summary>
    /// <param name="messageBuilder"></param>
    /// <param name="chunk"></param>
    /// <returns></returns>
    public static MessageBuilder operator +(MessageBuilder messageBuilder, MessageChunk chunk)
    {
        messageBuilder.Add(chunk);
        return messageBuilder;
    }

    /// <summary>
    /// 复制消息段
    /// </summary>
    /// <param name="messageBuilder"></param>
    /// <param name="count">倍数</param>
    /// <returns></returns>
    public static MessageBuilder operator *(MessageBuilder messageBuilder, int count)
    {
        if (count <= 0)
        {
            messageBuilder.Clear();
            return messageBuilder;
        }
        List<MessageChunk> chunks = new();
        for (int i = 0; i < count; i++)
        {
            foreach (var chunk in messageBuilder.ToArray())
            {
                chunks.Add(chunk);
            }
        }
        messageBuilder.Clear();
        messageBuilder.AddRange(chunks);
        return messageBuilder;
    }

    /// <summary>
    /// 获取消息段的JArray
    /// </summary>
    /// <returns></returns>
    public JArray ToJson()
    {
        return this.ToJArray();
    }

    /// <summary>
    /// 获取获取消息段的Json字符串
    /// </summary>
    /// <returns></returns>
    public string ToJsonString()
    {
        return ToJson().ToString();
    }

    /// <summary>
    /// 获取获取消息段的Json字符串
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return ToJsonString();
    }

    internal static MessageBuilder? Parse(JArray? array)
    {
        if (array == null) return null;
        var builder = new MessageBuilder();
        foreach (var item in array)
        {
            var chunk = MessageChunk.Parse(item);
            if (chunk == null) continue;
            builder.Add(chunk);
        }
        return builder;
    }
}

