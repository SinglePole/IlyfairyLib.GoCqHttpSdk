using IlyfairyLib.GoCqHttpSdk.Models.Shared;
using IlyfairyLib.GoCqHttpSdk.Utils;

namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 合并转发消息节点
/// </summary>
public sealed class NodeChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.node;
    /// <summary>
    /// 转发消息ID
    /// </summary>
    public int ID { get; }
    /// <summary>
    /// 发送者显示名字
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// 发送者QQ号
    /// </summary>
    public long QQ { get; set; }
    public MessageBuilder Content { get; set; }

    internal NodeChunk(MessageBuilder content, string name, long qq)
    {
        Data["name"] = name;
        Data["uin"] = qq;
        Data["content"] = content.ToJson();
        QQ = qq;
        Name = name;
        Content = content;
    }

    public NodeChunk(string name, long qq, params MessageChunk[] chunks) : this(new MessageBuilder(chunks), name, qq)
    {

    }
}

/// <summary>
/// 自定义合并转发节点 未完成
/// </summary>
internal sealed class CustomNodeChunk : MessageChunk
{
    public override MessageChunkType Type => MessageChunkType.node;
}
