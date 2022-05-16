namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 礼物
/// </summary>
public sealed class GiftChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.gift;

    public GiftId Id { get; }

    public GiftChunk(GiftId id)
    {
        Id = id;
        Data["qq"] = (int)id;
    }

    internal GiftChunk(string name, int pokeType, int id)
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
    public static bool operator ==(GiftChunk left, GiftChunk right)
    {
        return left.Id == right.Id;
    }
    
    /// <summary>
    /// 艾特QQ是否相等
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(GiftChunk left, GiftChunk right)
    {
        return left.Id != right.Id;
    }
}

public enum GiftId
{
    甜Wink = 0,
    快乐肥宅水 = 1,
    幸运手链 = 2,
    卡布奇诺 = 3,
    猫咪手表 = 4,
    绒绒手套 = 5,
    彩虹糖果 = 6,
    坚强 = 7,
    告白话筒 = 8,
    牵你的手 = 9,
    可爱猫咪 = 10,
    神秘面具 = 11,
    我超忙的 = 12,
    爱心口罩 = 13,
}