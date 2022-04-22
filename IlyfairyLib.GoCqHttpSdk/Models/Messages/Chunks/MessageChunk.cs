using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 消息块基类
/// </summary>
public abstract class MessageChunk
{
    public abstract MessageChunkType Type { get; }
    public virtual JObject Data { get; }
    public MessageChunk()
    {
        Data = new JObject();
    }

    internal MessageChunk(JObject json)
    {
        Data = json;
    }

    public JObject ToJson()
    {
        JObject json = new();
        json["type"] = Type.ToString();
        json["data"] = Data;
        return json;
    }

    public static implicit operator MessageChunk(string text)
    {
        return new TextChunk(text);
    }

    public static MessageBuilder operator +(MessageChunk chunk1, MessageChunk chunk2)
    {
        return new() { chunk1, chunk2 };
    }
    public static MessageBuilder operator *(MessageChunk chunk, int count)
    {
        if (count <= 0)
        {
            return new();
        }
        List<MessageChunk> chunks = new();
        for (int i = 0; i < count; i++)
        {
            chunks.Add(chunk);
        }
        return new(chunks);
    }

    public override string ToString()
    {
        return ToJson().ToString();
    }

    internal static MessageChunk? Parse(JToken json)
    {
        return json.Value<string>("type") switch
        {
            "at" => AtChunk.Parse(json),
            "text" => TextChunk.Parse(json),
            _ => null,
        };
    }
}
