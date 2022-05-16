namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 红包
/// </summary>
public sealed class RedbagChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.poke;

    /// <summary>
    /// 祝福语/口令
    /// </summary>
    public string Title { get; }

    internal RedbagChunk(string title)
    {
        Title = title;
        Data["title"] = title;
    }
}
