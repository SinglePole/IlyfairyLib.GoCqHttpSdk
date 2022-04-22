namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 合并转发节点
/// </summary>
internal sealed class NodeChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.node;
    /// <summary>
    /// 合并转发 ID
    /// </summary>
    public int ID { get; }
    public NodeChunk(int id)
    {
        ID = id;
        Data["id"] = id;
    }
}

/// <summary>
/// 自定义合并转发节点 未完成
/// </summary>
internal sealed class CustomNodeChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.node;
}
