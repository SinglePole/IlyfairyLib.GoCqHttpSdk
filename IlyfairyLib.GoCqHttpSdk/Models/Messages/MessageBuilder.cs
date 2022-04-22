using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public static MessageBuilder operator +(MessageBuilder messageBuilder1, MessageBuilder messageBuilder2)
    {
        foreach (var chunk in messageBuilder2)
        {
            messageBuilder1.Add(chunk);
        }
        return messageBuilder1;
    }
    public static MessageBuilder operator +(MessageBuilder messageBuilder, MessageChunk chunk)
    {
        messageBuilder.Add(chunk);
        return messageBuilder;
    }
    public static MessageBuilder operator *(MessageBuilder messageBuilder, int count)
    {
        if (count <= 0)
        {
            messageBuilder.Clear();
            return messageBuilder;
        }
        List<MessageChunk> chunks = new List<MessageChunk>();
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

    public JArray ToJson()
    {
        return this.ToJArray();
    }

    public string ToJsonString()
    {
        return ToJson().ToString();
    }

    public override string ToString()
    {
        return ToJsonString();
    }

    internal static MessageBuilder Parse(JArray array)
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

