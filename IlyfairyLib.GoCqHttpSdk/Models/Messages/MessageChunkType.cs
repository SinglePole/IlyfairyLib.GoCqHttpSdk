namespace IlyfairyLib.GoCqHttpSdk.Models.Chunks;

/// <summary>
/// 消息块类型
/// </summary>
public enum MessageChunkType
{
    /// <summary>
    /// 文本消息
    /// </summary>
    text,
    /// <summary>
    /// 图片消息
    /// </summary>
    image,
    /// <summary>
    /// 艾特消息
    /// </summary>
    at,
    /// <summary>
    /// 视频消息
    /// </summary>
    video,
    rps,
    dice,
    shake,
    poke,
    share,
    contact,
    /// <summary>
    /// 位置消息
    /// </summary>
    location,
    music,
    reply,
    forward,
    node,
    /// <summary>
    /// Xml消息
    /// </summary>
    xml,
    /// <summary>
    /// Json消息
    /// </summary>
    json,
    /// <summary>
    /// 语音转文本消息
    /// </summary>
    tts,
}
