namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;
/// <summary>
/// 群文件上传
/// </summary>
public interface IGroupUpload
{
    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    public long UserId { get; init; }
    /// <summary>
    /// 事件发生的时间戳
    /// </summary>
    public long Time { get; init; }
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; init; }
    /// <summary>
    /// 文件信息
    /// </summary>
    public GroupUploadFile File { get; init; }
}
