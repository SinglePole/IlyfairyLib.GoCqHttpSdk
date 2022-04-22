namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 推荐好友/群
/// </summary>
public sealed class ContactChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.contact;

    public ContactType ContactType { get; }
    public int ID { get; }

    public ContactChunk(ContactType contactType, int id)
    {
        ContactType = contactType;
        ID = id;
        Data["type"] = contactType switch
        {
            ContactType.QQ => "qq",
            ContactType.Group => "group",
            _ => "",
        };
        Data["id"] = id;
    }
}

/// <summary>
/// 推荐类型
/// </summary>
public enum ContactType
{
    /// <summary>
    /// 推荐QQ
    /// </summary>
    QQ,
    /// <summary>
    /// 推荐群
    /// </summary>
    Group
}
