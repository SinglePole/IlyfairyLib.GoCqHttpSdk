namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 猜拳魔法表情
/// </summary>
public sealed class RpsChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.rps;

    public RpsChunk()
    {
    }

}
