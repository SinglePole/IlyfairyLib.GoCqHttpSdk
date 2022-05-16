namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 戳一戳 <br/>仅群聊
/// </summary>
public sealed class PokeChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.poke;

    public long QQ { get; }

    public PokeChunk(long qq)
    {
        QQ = qq;
        Data["qq"] = qq;
    }

    internal PokeChunk(string name, int pokeType, int id)
    {
        //this.PokeType = pokeType;
        //this.ID = id;
        //Name = name;
    }

    /// <summary>
    /// 艾特QQ是否相等
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(PokeChunk left,PokeChunk right)
    {
        return left.QQ == right.QQ;
    }
    
    /// <summary>
    /// 艾特QQ是否相等
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(PokeChunk left,PokeChunk right)
    {
        return left.QQ != right.QQ;
    }
}
