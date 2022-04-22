namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 文本转语音
/// </summary>
public sealed class TtsChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.tts;

    public string Text { get; }

    public TtsChunk(string text)
    {
        Text = text;
        Data["text"] = text;
    }

}
