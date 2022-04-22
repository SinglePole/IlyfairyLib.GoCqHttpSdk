namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 回复
/// </summary>
public sealed class ReplyChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.reply;
    /// <summary>
    /// 消息ID
    /// </summary>
    public int ID { get; }
    public ReplyChunk(int id)
    {
        ID = id;
        Data["id"] = id;
    }
}
