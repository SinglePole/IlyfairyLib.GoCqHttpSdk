using Newtonsoft.Json.Linq;

namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 文本消息
/// </summary>
public sealed class TextChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.text;
    private string text;

    public string Text
    {
        get { return text; }
        set { text = value; Data["text"] = text; }
    }

    public TextChunk(string text)
    {
        Text = text;
    }

    public override string ToString()
    {
        return Text;
    }

    public static implicit operator TextChunk(string text)
    {
        return new TextChunk(text);
    }

    public static new MessageChunk? Parse(JToken json)
    {
        if (json["data"]?.Value<string>("text") is string text)
        {
            return new TextChunk(text);
        }
        return null;
    }
}
