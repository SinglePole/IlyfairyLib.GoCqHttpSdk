namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 窗口抖动
/// </summary>
public sealed class ShakeChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.shake;

    public ShakeChunk()
    {
    }

}
