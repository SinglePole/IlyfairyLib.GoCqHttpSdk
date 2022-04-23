using IlyfairyLib.GoCqHttpSdk.Models.Messages;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 消息块基类
/// </summary>
public abstract class MessageChunk
{
    public abstract MessageChunkType Type { get; }
    public virtual JObject Data { get; protected set; }
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
        if (json == null) return null;
        var type = json.Value<string>("type");
        return type switch
        {
            "text" => TextChunk.Parse(json),
            "image" => ImageChunk.Parse(json),
            "at" => AtChunk.Parse(json),
            //"video" => VideoChunk.Parse(json),
            //"rps" => RpsChunk.Parse(json),
            //"dice" => DiceChunk.Parse(json),
            //"shake" => ShakeChunk.Parse(json),
            //"poke" => PokeChunk.Parse(json),
            //"share" => ShareChunk.Parse(json),
            //"contact" => ContactChunk.Parse(json),
            //"location" => LocationChunk.Parse(json),
            //"music" => MusicChunk.Parse(json),
            //"reply" => ReplyChunk.Parse(json),
            //"forward" => ForwardChunk.Parse(json),
            //"node" => NodeChunk.Parse(json),
            //"xml" => XmlChunk.Parse(json),
            "json" => JsonChunk.Parse(json),
            //"tts" => TtsChunk.Parse(json),
            _ => null,
        };
    }
}
