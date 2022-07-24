namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 合并转发
/// </summary>
public sealed class ForwardChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.forward;
    /// <summary>
    /// 合并转发节点 ID
    /// </summary>
    public int ID { get; }
    public ForwardChunk(int id)
    {
        ID = id;
        Data["id"] = id;
    }
}
