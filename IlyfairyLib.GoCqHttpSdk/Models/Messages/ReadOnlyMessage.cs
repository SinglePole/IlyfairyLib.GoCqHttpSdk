using IlyfairyLib.GoCqHttpSdk.Models.Chunks;
using IlyfairyLib.GoCqHttpSdk.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IlyfairyLib.GoCqHttpSdk.Models.Messages;

/// <summary>
/// 只读消息
/// </summary>
public class ReadOnlyMessage : IEnumerable<MessageChunk>
{
    private readonly Session _session;
    private readonly MessageBuilder _builder;
    /// <summary>
    /// 消息块
    /// </summary>
    public ReadOnlyCollection<MessageChunk> Chunks { get; }

    /// <summary>
    /// 原始消息
    /// </summary>
    public string RawMessage { get; init; }
    /// <summary>
    /// 去除了[]&amp;转义的消息
    /// </summary>
    public string Text { get; init; }
    /// <summary>
    /// 仅文本消息
    /// </summary>
    public string TextOnly { get; init; }
    /// <summary>
    /// 消息ID
    /// </summary>
    public int MessageId { get; init; } = -1;

    private bool? isAtRobot;
    /// <summary>
    /// 是否艾特了机器人
    /// </summary>
    public bool IsAtRobot 
    {
        get 
        {
            if (isAtRobot == null)
            {
                isAtRobot = Chunks.Where(v => v.Type is MessageChunkType.at).Any(v => (v as AtChunk)?.QQ == _session.RobotQQ);
            }
            return isAtRobot.Value;
        } 
    }

    /// <summary>
    /// 获取消息中所有艾特的qq
    /// </summary>
    /// <returns></returns>
    public IEnumerable<AtChunk> GetAllAt()
    {
        return _builder.Where(v => v.Type == MessageChunkType.at).Cast<AtChunk>();
    }

    internal ReadOnlyMessage(Session session, JToken json)
    {
        var builder = MessageBuilder.Parse(json["message"] as JArray);
        var rawMessage = json.Value<string>("raw_message");
        var messageId = json.Value<int>("message_id");

        this._session = session;
        this._builder = new(builder);
        this.Chunks = new(builder);
        
        MessageId = messageId;
        RawMessage = rawMessage;
        Text = RawMessage.ToText();
        TextOnly = string.Join("", builder.Where(v => v.Type == MessageChunkType.text));
    }

    public IEnumerator<MessageChunk> GetEnumerator()
    {
        return _builder.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
