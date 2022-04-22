namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 掷骰子魔法表情
/// </summary>
public sealed class DiceChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.dice;

    public DiceChunk()
    {
    }

}
